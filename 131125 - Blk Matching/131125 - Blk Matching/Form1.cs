using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;

namespace _131125___Blk_Matching
{
    public partial class Form1 : Form
    {

        Image<Gray, Byte> imgCurrent, imgPrevious,imgFD,imgDF,imgDFD;
        Image<Gray, float> fImgPreviousMatchResult; 

        public Form1()
        {
            InitializeComponent();
            comboBoxSequence.SelectedIndex = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (comboBoxSequence.SelectedIndex == 0)
            {
                imgCurrent = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Foreman Sequences\CIF BMP\foreman_cif_3.bmp");
                imgPrevious = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Foreman Sequences\CIF BMP\foreman_cif_2.bmp");
            }
            else if (comboBoxSequence.SelectedIndex == 1)
            {
                imgCurrent = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Waterfall Sequence\waterfall_cif_3.bmp");
                imgPrevious = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Waterfall Sequence\waterfall_cif_2.bmp");
            }
            else
            {
                imgCurrent = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Stefan Sequence\stefan_cif_3.bmp");
                imgPrevious = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Stefan Sequence\stefan_cif_2.bmp");
            }
            
            int iSearchRange = trackbarSearchRange.Value;
            int iBlkSize = int.Parse(tbBlkSize.Text);
            int iFrameHeight = imgPrevious.Height;
            int iFrameWidth = imgPrevious.Width;
            int iNunberofPixels = iFrameHeight * iFrameWidth;
            int iRunX = iFrameWidth/iBlkSize;
            int iRunY = iFrameHeight/iBlkSize;

            int iPadLength = iSearchRange;

            //display
            listBox1.Items.Add("SearchRanece:" + iSearchRange.ToString() + " BlkSize:" + iBlkSize.ToString());



            //image padding
            Image<Gray,Byte> imgPreviousPad = new Image<Gray,Byte>(iFrameWidth +2*iPadLength,iFrameHeight+2*iPadLength);
            CvInvoke.cvCopyMakeBorder(imgPrevious.Ptr, imgPreviousPad.Ptr , new Point(iPadLength,iPadLength), Emgu.CV.CvEnum.BORDER_TYPE.REPLICATE, new MCvScalar(0f)); 
            
            //preparing DF 

            imgDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight,new Gray(0f));

            //to float conversion
            Image<Gray, float> fImgCurrent = imgCurrent.Convert<Gray, Single>();
            Image<Gray, float> fImgPrevious = imgPrevious.Convert<Gray, Single>();
            Image<Gray, float> fImgPreviousPad = imgPreviousPad.Convert<Gray, Single>();
            fImgPreviousMatchResult = fImgPreviousPad.Copy();
            Image<Gray, float> fImgFD = fImgCurrent - fImgPrevious;
            imgFD = (fImgFD + 127).Convert<Gray, Byte>();//for display

            //decaring vector array 
            Matrix<int> VectorArrayX = new Matrix<int>(iRunX, iRunY);
            Matrix<int> VectorArrayY = new Matrix<int>(iRunX, iRunY);

            //Get Subpixel accuracy image stack
            Image<Gray, Byte>[] imgPreviousSbpxStack = new Image<Gray, byte>[16];

            for (int iSbpxOffsetX = 0; iSbpxOffsetX <= 3; iSbpxOffsetX += 1)
            {
                for (int iSbpxOffsetY = 0; iSbpxOffsetY <= 3; iSbpxOffsetY += 1)  
                {
                    Image<Gray, Byte> imgPreviousSbpx = new Image<Gray, byte>(imgPreviousPad.Size);
                    CvInvoke.cvGetRectSubPix(imgPreviousPad.Ptr, imgPreviousSbpx.Ptr, new PointF((float)imgPreviousPad.Width / 2 + iSbpxOffsetX * 0.25f, (float)imgPreviousPad.Height / 2 + iSbpxOffsetY * 0.25f));
                    imgPreviousSbpxStack[iSbpxOffsetX * 4 + iSbpxOffsetY] = imgPreviousSbpx;
                }
            }

            //Block Matching
            for (int iFramePointerY = 0; iFramePointerY < iFrameHeight; iFramePointerY += iBlkSize)
            {
                for (int iFramePointerX = 0; iFramePointerX < iFrameWidth; iFramePointerX += iBlkSize)
                {
                    //define ROI
                    Rectangle recSearchWindow = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize + 2 * iSearchRange, iBlkSize + 2 * iSearchRange);
                    
                    fImgCurrent.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize, iBlkSize);
                    fImgPreviousPad.ROI = recSearchWindow;
                    fImgPreviousMatchResult.ROI = recSearchWindow;

                    Image<Gray, float> tm = fImgPreviousPad.MatchTemplate(fImgCurrent, Emgu.CV.CvEnum.TM_TYPE.CV_TM_SQDIFF);

                    double minval = 0, maxval = 0;
                    Point minPoint = new Point(0, 0);
                    Point maxPoint = new Point(0, 0);
                    IntPtr i = IntPtr.Zero;
                    CvInvoke.cvMinMaxLoc(tm.Ptr, ref minval, ref maxval, ref maxPoint, ref minPoint, IntPtr.Zero);

                    fImgPreviousMatchResult.Draw(new Rectangle(maxPoint, new Size(iBlkSize, iBlkSize)), new Gray(0), 1);
                    
                    //convert minium point to motio nvector
                    int iShiftX = maxPoint.X - iSearchRange ;
                    int iShiftY = maxPoint.Y - iSearchRange ;





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
                    

                    //rethrive vector motion array
                    int iShiftX =  VectorArrayX.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize];
                    int iShiftY = VectorArrayY.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize];
                 
                    //define ROIs
                    imgPreviousPad.ROI = new Rectangle(iFramePointerX + iSearchRange + iShiftX, iFramePointerY + iSearchRange + iShiftY, iBlkSize, iBlkSize);
                    imgDF.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize, iBlkSize);

                    //transfer block
                    imgPreviousPad.CopyTo(imgDF);
                    
                    //reset ROIs
                    imgPreviousPad.ROI = Rectangle.Empty;
                    imgDF.ROI = Rectangle.Empty;

                }
            }

            //Obtain DFD
            Image<Gray,float> fImgDF = imgDF.Convert<Gray, Single>();
            Image<Gray, float> fImgDFD = fImgCurrent - fImgDF;
            imgDFD = (fImgDFD + 127).Convert<Gray, Byte>();//for display

            //Square DFD element wise
            Image<Gray, float> fSquaredDFD = fImgDFD.Copy();
            fSquaredDFD._Mul(fImgDFD);
            double MSE = fSquaredDFD.GetSum().Intensity / (float)iNunberofPixels;

            listBox1.Items.Add("MSE: " + MSE.ToString("###.00"));
            imageBox2.Image = fImgPreviousMatchResult;
            imageBox1.Image = fImgCurrent;
            comboboxLeft.SelectedIndex = 1;
            comboboxLeft.Enabled = true;
            comboBoxRight.SelectedIndex = 1;
            comboBoxRight.Enabled = true;
        }

        private void trackbarSearchRange_Scroll(object sender, EventArgs e)
        {

            toolTip1.SetToolTip(trackbarSearchRange, trackbarSearchRange.Value.ToString());
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
        }

        private void comboBoxRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRight.SelectedIndex == 1)
            {
                imageBox2.Image = fImgPreviousMatchResult;
            }
            else if (comboBoxRight.SelectedIndex == 0)
            {
                imageBox2.Image = imgFD;
            }
            else if (comboBoxRight.SelectedIndex == 2)
            {
                imageBox2.Image = imgDF ;
            }
            else if (comboBoxRight.SelectedIndex == 3)
            {
                imageBox2.Image = imgDFD;
            }

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            FormTest1 formtest = new FormTest1();
            formtest.Show();
        }


        
    }
}
