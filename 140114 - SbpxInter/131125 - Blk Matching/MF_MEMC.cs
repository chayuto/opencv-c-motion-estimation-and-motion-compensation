using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;

namespace _131125___Blk_Matching
{
    public partial class Form1 : Form
    {

        Image<Gray, Byte> imgCurrent, imgPrevious,imgNext,imgFD,imgDF,imgDFD;
        Image<Gray, float> fImgPreviousMatchResult;
        Boolean blConExeEnabled = false;
        

        public Form1()
        {
            InitializeComponent();
            comboBoxSequence.SelectedIndex = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            MEandMC();
        }
        private void continuousExecute(object sender, EventArgs e)
        {
            MEandMC();
            //update frame No. for next frame
            UpdateFrameNo();
        }
        private void MEandMC()
        {
            int iFrameNo = trackBarFrameNo.Value;
            string strFileLoc = "";
            if (comboBoxSequence.SelectedIndex == 0)
            {
                //strFileLoc = @"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Foreman Sequences\CIF BMP\foreman_cif_";
                strFileLoc = @".\Foreman Sequences\CIF BMP\foreman_cif_";
            }
            else if (comboBoxSequence.SelectedIndex == 1)
            {
                strFileLoc = @".\Waterfall Sequence\waterfall_cif_";   
            }
            else
            {
                strFileLoc = @".\Stefan Sequence\stefan_cif_";          
            }

            imgCurrent = new Image<Gray, Byte>(strFileLoc + iFrameNo.ToString() + ".bmp");
            imgPrevious = new Image<Gray, Byte>(strFileLoc + (iFrameNo - 1).ToString() + ".bmp");
            imgNext = new Image<Gray, Byte>(strFileLoc + (iFrameNo + 1).ToString() + ".bmp");


            int iSearchRange = trackbarSearchRange.Value;
            int iBlkSize = 1 << (trackBarBlkSize.Value + 1);
            Size sizeBlk = new Size(iBlkSize, iBlkSize);

            int iFrameHeight = imgPrevious.Height;
            int iFrameWidth = imgPrevious.Width;
            int iNunberofPixels = iFrameHeight * iFrameWidth;
            int iRunX = iFrameWidth / iBlkSize;
            int iRunY = iFrameHeight / iBlkSize;

            int iPadLength = iSearchRange;

            


            //image padding
            Image<Gray, Byte> imgPreviousPad = new Image<Gray, Byte>(iFrameWidth + 2 * iPadLength, iFrameHeight + 2 * iPadLength);
            CvInvoke.cvCopyMakeBorder(imgPrevious.Ptr, imgPreviousPad.Ptr, new Point(iPadLength, iPadLength), Emgu.CV.CvEnum.BORDER_TYPE.REPLICATE, new MCvScalar(0f));
           
            //preparing DF 

            imgDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight, new Gray(0f));
           

            //to float conversion
            Image<Gray, float> fImgCurrent = imgCurrent.Convert<Gray, Single>();
            Image<Gray, float> fImgPrevious = imgPrevious.Convert<Gray, Single>();
            Image<Gray, float> fImgPreviousPad = imgPreviousPad.Convert<Gray, Single>();

            fImgPreviousMatchResult = fImgPreviousPad.Copy();

            //Frame difference
            Image<Gray, float> fImgFD = fImgCurrent - fImgPrevious;
            imgFD = (fImgFD + 127).Convert<Gray, Byte>();//for display

            //decaring vector array 
            Matrix<int> VectorArrayX = new Matrix<int>(iRunX, iRunY);
            Matrix<int> VectorArrayY = new Matrix<int>(iRunX, iRunY);


            //Block Matching
            for (int iFramePointerY = 0; iFramePointerY < iFrameHeight; iFramePointerY += iBlkSize)
            {
                for (int iFramePointerX = 0; iFramePointerX < iFrameWidth; iFramePointerX += iBlkSize)
                {
                    //define ROI
                    fImgCurrent.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize, iBlkSize);
                    fImgPreviousPad.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize + 2 * iSearchRange, iBlkSize + 2 * iSearchRange);
                    fImgPreviousMatchResult.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize + 2 * iSearchRange, iBlkSize + 2 * iSearchRange);


                    Image<Gray, float> tm = fImgPreviousPad.MatchTemplate(fImgCurrent, Emgu.CV.CvEnum.TM_TYPE.CV_TM_SQDIFF);

                    double minval = 0, maxval = 0;
                    Point minPoint = new Point(0, 0);
                    Point maxPoint = new Point(0, 0);
                    IntPtr i = IntPtr.Zero;
                    CvInvoke.cvMinMaxLoc(tm.Ptr, ref minval, ref maxval, ref maxPoint, ref minPoint, IntPtr.Zero);

                    fImgPreviousMatchResult.Draw(new Rectangle(maxPoint, new Size(iBlkSize, iBlkSize)), new Gray(0), 1);

                    //convert minium point to motio nvector
                    int iShiftX = maxPoint.X - iSearchRange;
                    int iShiftY = maxPoint.Y - iSearchRange;

                    //store result vector into vector array
                    VectorArrayX.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize] = iShiftX;
                    VectorArrayY.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize] = iShiftY;

                    //reset ROIs
                    fImgPreviousMatchResult.ROI = Rectangle.Empty;
                    fImgPreviousPad.ROI = Rectangle.Empty;
                    fImgCurrent.ROI = Rectangle.Empty;
                }
            }


            //Displaceing Frame
            for (int iFramePointerY = 0; iFramePointerY < iFrameHeight; iFramePointerY += iBlkSize)
            {
                for (int iFramePointerX = 0; iFramePointerX < iFrameWidth; iFramePointerX += iBlkSize)
                {
                    //varible declaration
                    int iBlkPointerX = iFramePointerX / iBlkSize;
                    int iBlkPointerY = iFramePointerY / iBlkSize;

                    Rectangle recBlk = new Rectangle(new Point(iFramePointerX, iFramePointerY), sizeBlk);

                    Image<Gray, Byte> blkPrevious = new Image<Gray, byte>(sizeBlk);
                    

                    //full-pixels

                    //Previous
                    //rethrive vector motion array
                    int iShiftX = VectorArrayX.Data[iBlkPointerX, iBlkPointerY];
                    int iShiftY = VectorArrayY.Data[iBlkPointerX, iBlkPointerY];

                    //obtain blk Previous
                    imgPreviousPad.ROI = new Rectangle(
                        iFramePointerX + iSearchRange + iShiftX,
                        iFramePointerY + iSearchRange + iShiftY,
                        iBlkSize, iBlkSize);
                    imgPreviousPad.CopyTo(blkPrevious);

                    



                    //set ROI for placement
                    imgDF.ROI = recBlk;
                    

                    //block placement
                    blkPrevious.CopyTo(imgDF);
                   



                   

                }
            }

            //reset ROIs
            imgDF.ROI = Rectangle.Empty;
            

            //Obtain DFD
            Image<Gray, float> fImgDF = imgDF.Convert<Gray, Single>();
            Image<Gray, float> fImgDFD = fImgCurrent - fImgDF;
            imgDFD = (fImgDFD + 127).Convert<Gray, Byte>();//for display
            

            

            //Square FD element wise
            Image<Gray, float> fSquaredFD = fImgFD.Copy();
            fSquaredFD._Mul(fImgFD);
            double FDMSE = fSquaredFD.GetSum().Intensity / (float)iNunberofPixels;

            //Square DFD element wise
            Image<Gray, float> fSquaredDFD = fImgDFD.Copy();
            fSquaredDFD._Mul(fImgDFD);
            double MSE = fSquaredDFD.GetSum().Intensity / (float)iNunberofPixels;
            
           

            //update text box
            tbLog.AppendText("Frame:" + iFrameNo + Environment.NewLine);
            tbLog.AppendText("SearchRanece:" + iSearchRange.ToString() + Environment.NewLine + "BlkSize:" + iBlkSize.ToString() + Environment.NewLine);
            tbLog.AppendText("Frame Diff MSE: " + FDMSE.ToString("###.00") + Environment.NewLine);
            tbLog.AppendText("MSE: " + MSE.ToString("###.00") + Environment.NewLine);
          


            //update image display
            imageBox2.Image = fImgPreviousMatchResult;
            imageBox1.Image = fImgCurrent;
            if (comboboxLeft.Enabled == false)
            {
                comboboxLeft.SelectedIndex = 1;
                comboboxLeft.Enabled = true;
            }
            else
            {
                comboboxLeft_SelectedIndexChanged(null,null);
            }
            if (comboBoxRight.Enabled == false)
            {
                comboBoxRight.SelectedIndex = 0;
                comboBoxRight.Enabled = true;
            }
            else
            {
                comboBoxRight_SelectedIndexChanged(null, null);
            }

            //chart1.Series["Series2"].ChartType = SeriesChartType.Line;
            //chart1.Series["Series2"].Points.AddY(20);
            //chart1.Series["Series2"].Points.AddY(30);
            //chart1.Series["Series2"].Points.AddY(40);


            
            chart1.Series["FD"].Points.AddY(MSE);
            chart1.Series["Previous"].Points.AddY(FDMSE);

        }

        private void UpdateFrameNo()
        {
            if (trackBarFrameNo.Value < trackBarFrameNo.Maximum )
            {
                trackBarFrameNo.Value++;
            }
            else
            { 
                trackBarFrameNo.Value = trackBarFrameNo.Minimum ;
                Application.Idle -= continuousExecute;
                blConExeEnabled = false;
                btnConExe.Text = "Continuous Execuition";
            }

        }
       

        private void comboboxLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxLeft.SelectedIndex == 1)
            {
                imageBox1.Image = imgCurrent;
            }
            else if (comboboxLeft.SelectedIndex == 0)
            {
                imageBox1.Image = imgPrevious;
            }
            else if (comboboxLeft.SelectedIndex == 2)
            {
                imageBox1.Image = imgNext;
            }
        }

        private void comboBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRight.SelectedIndex == 0)
            {
                imageBox2.Image = fImgPreviousMatchResult;
            }
            else if (comboBoxRight.SelectedIndex == 1)
            {
                imageBox2.Image = imgDF;
            }
            
            else if (comboBoxRight.SelectedIndex == 2)
            {
                imageBox2.Image = imgFD;
            }
            else if (comboBoxRight.SelectedIndex == 3)
            {
                imageBox2.Image = imgDFD;
            }
           

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            tbLog.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxRight.SelectedIndex != 3)
            {
                comboBoxRight.SelectedIndex += 1;
            }
            else { comboBoxRight.SelectedIndex = 0; }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (comboBoxRight.SelectedIndex != 0)
            {
                comboBoxRight.SelectedIndex -= 1;
            }
            else { comboBoxRight.SelectedIndex = 3; }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboboxLeft.SelectedIndex  != 2)
            {
                comboboxLeft.SelectedIndex += 1;
            }
            else { comboboxLeft.SelectedIndex = 0; }    
        }

        private void btnPrevious1_Click(object sender, EventArgs e)
        {
            if (comboboxLeft.SelectedIndex != 0)
            {
                comboboxLeft.SelectedIndex -= 1;
            }
            else { comboboxLeft.SelectedIndex = 2; }    
        }

        private void trackbarSearchRange_Scroll(object sender, EventArgs e)
        {

            toolTip1.SetToolTip(trackbarSearchRange, trackbarSearchRange.Value.ToString());
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarBlkSize, (1 << (trackBarBlkSize.Value + 1)).ToString());
        
        }

        private void trackBarFrameNo_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarFrameNo, trackBarFrameNo.Value.ToString());
        
        }

        private void comboBoxSequence_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSequence.SelectedIndex == 0) //if foreman
            {
                trackBarFrameNo.Maximum = 298;
                
            }
            else if (comboBoxSequence.SelectedIndex == 1) //if water fall
            {
                trackBarFrameNo.Maximum = 258;
                if (trackBarFrameNo.Value > trackBarFrameNo.Maximum)
                {
                    trackBarFrameNo.Value = trackBarFrameNo.Maximum;
                }
            }
            else if (comboBoxSequence.SelectedIndex == 2) //if stefan
            {
                trackBarFrameNo.Maximum = 88;
                if (trackBarFrameNo.Value > trackBarFrameNo.Maximum)
                {
                    trackBarFrameNo.Value = trackBarFrameNo.Maximum;
                }
            }
        }

        private void btnConExe_Click(object sender, EventArgs e)
        {
            if (blConExeEnabled == false)
            {
                Application.Idle += continuousExecute;
                blConExeEnabled = true;
                btnConExe.Text = "Stop";
            }
            else
            {
                Application.Idle -= continuousExecute;
                blConExeEnabled = false;
                btnConExe.Text = "Continuous Execuition";
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnClearGraph_Click(object sender, EventArgs e)
        {
            chart1.Series["FD"].Points.Clear();
            chart1.Series["Previous"].Points.Clear();
        }
    }
}
