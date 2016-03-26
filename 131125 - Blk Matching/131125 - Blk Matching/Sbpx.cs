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

        Image<Gray, Byte> imgCurrent, imgPrevious,imgFD,imgDF,imgDFD,imgSbpxDF,imgSbpxDFD;
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
            imgSbpxDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight, new Gray(0f));

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

            //decaring Sbpx vector array 
            Matrix<float> VectorArraySbpxX = new Matrix<float>(iRunX, iRunY);
            Matrix<float> VectorArraySbpxY = new Matrix<float>(iRunX, iRunY);



            //Get Subpixel accuracy image stack
            Image<Gray, Byte>[] imgPreviousSbpxStack = new Image<Gray, byte>[16];

            

            //Block Matching
            for (int iFramePointerY = 0; iFramePointerY < iFrameHeight; iFramePointerY += iBlkSize)
            {
                for (int iFramePointerX = 0; iFramePointerX < iFrameWidth; iFramePointerX += iBlkSize)
                {

                    double[] minValStack = new double[16];
                    Point[] minPointStack = new Point[16];

                    //define ROI
                    Rectangle recSearchWindow = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize + 2 * iSearchRange, iBlkSize + 2 * iSearchRange);
                    
                    fImgCurrent.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize, iBlkSize);
                    fImgPreviousMatchResult.ROI = recSearchWindow;
                    fImgPreviousPad.ROI = recSearchWindow;


                    double  minValSearch = 999999999999.9f;
                    int minValIndex = 0;

                    for (int iSbpxOffsetX = 0; iSbpxOffsetX <= 3; iSbpxOffsetX ++)
                    {
                        for (int iSbpxOffsetY = 0; iSbpxOffsetY <= 3; iSbpxOffsetY ++)
                        {
                            int iFrameIndex = iSbpxOffsetX * 4 + iSbpxOffsetY;
                            float fSbpxOffsetX  = iSbpxOffsetX * 0.25f;
                            float fSbpxOffsetY  = iSbpxOffsetY * 0.25f;

                            Image<Gray, Single> fBlkSbpx = new Image<Gray, float>(recSearchWindow.Size);
                            CvInvoke.cvGetRectSubPix(fImgPreviousPad.Ptr, fBlkSbpx.Ptr, new PointF((float)(recSearchWindow.Width - 1.0f) / 2 + fSbpxOffsetX, (float)(recSearchWindow.Height - 1.0f) / 2 + fSbpxOffsetY));
                    
                           

                            Image<Gray, float> tm = fBlkSbpx.MatchTemplate(fImgCurrent, Emgu.CV.CvEnum.TM_TYPE.CV_TM_SQDIFF);

                            double minval = 0, maxval = 0;
                            Point minPoint = new Point(0, 0);
                            Point maxPoint = new Point(0, 0);
                            IntPtr i = IntPtr.Zero;
                            CvInvoke.cvMinMaxLoc(tm.Ptr, ref minval, ref maxval, ref minPoint, ref maxPoint, IntPtr.Zero);
                            
                            
                            minValStack[iFrameIndex] = minval;
                            minPointStack[iFrameIndex] = minPoint;

                            if (minval < minValSearch)
                            {
                                minValSearch = minval;
                                minValIndex = iFrameIndex;
                            }

                            if (iFrameIndex == 0)
                            {
                                fImgPreviousMatchResult.Draw(new Rectangle(minPoint, new Size(iBlkSize, iBlkSize)), new Gray(0), 1);
                                fImgPreviousMatchResult.Draw(new LineSegment2D(new Point(minPoint.X  + iBlkSize / 2, minPoint.Y+ iBlkSize / 2), new Point(iSearchRange + iBlkSize / 2, iSearchRange+ iBlkSize / 2)), new Gray(255), 1);
                                    
                            }

                        }
                    }

                    //full pixels
                    //convert minium point to motio nvector
                    int iShiftX = minPointStack[0].X - iSearchRange;
                    int iShiftY = minPointStack[0].Y - iSearchRange;

                    //store result vector into vector array
                    VectorArrayX.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize] = iShiftX;
                    VectorArrayY.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize] = iShiftY;


                    //Sub-pixels
                    //convert minium point to motio nvector
                    float fShiftX = minPointStack[minValIndex].X - iSearchRange + (minValIndex / (int)4) * 0.25f;
                    float fShiftY = minPointStack[minValIndex].Y - iSearchRange + (minValIndex % (int)4) * 0.25f; 

                    //store result vector into vector array
                    VectorArraySbpxX.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize] = fShiftX;
                    VectorArraySbpxY.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize] = fShiftY;


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
                    Rectangle recBlk = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize, iBlkSize);
                    //full-pixels

                    //rethrive vector motion array
                    int iShiftX =  VectorArrayX.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize];
                    int iShiftY = VectorArrayY.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize];
                 
                    //define ROIs
                    imgPreviousPad.ROI = new Rectangle(iFramePointerX + iSearchRange + iShiftX, iFramePointerY + iSearchRange + iShiftY, iBlkSize, iBlkSize);
                    imgDF.ROI = recBlk;

                    //transfer block
                    imgPreviousPad.CopyTo(imgDF);

                    //reset ROIs

                    imgDF.ROI = Rectangle.Empty;

                    //Sub-pixels

                    //rethrive vector motion array
                    float fShiftX = VectorArraySbpxX.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize];
                    float fShiftY = VectorArraySbpxY.Data[iFramePointerX / iBlkSize, iFramePointerY / iBlkSize];

                    //define ROIs
                    imgPreviousPad.ROI = Rectangle.Empty;
                    imgSbpxDF.ROI = recBlk;

                    PointF pfCenter = new PointF(
                        iFramePointerX + iPadLength +(recBlk.Width -1)*0.5f +fShiftX ,
                        iFramePointerY + iPadLength + (recBlk.Height - 1) * 0.5f + fShiftY);
                    CvInvoke.cvGetRectSubPix(imgPreviousPad.Ptr, imgSbpxDF.Ptr, pfCenter);

                    //reset ROIs

                    imgSbpxDF.ROI = Rectangle.Empty;
                }
            }

            //Obtain DFD
            Image<Gray,float> fImgDF = imgDF.Convert<Gray, Single>();
            Image<Gray, float> fImgDFD = fImgCurrent - fImgDF;
            imgDFD = (fImgDFD + 127).Convert<Gray, Byte>();//for display

            Image<Gray, float> fImgSbpxDF = imgSbpxDF.Convert<Gray, Single>();
            Image<Gray, float> fImgSbpxDFD = fImgCurrent - fImgSbpxDF;
            imgSbpxDFD = (fImgSbpxDFD + 127).Convert<Gray, Byte>();//for display

            //Square FD element wise
            Image<Gray, float> fSquaredFD = fImgFD.Copy();
            fSquaredFD._Mul(fImgFD);
            double FDMSE = fSquaredFD.GetSum().Intensity / (float)iNunberofPixels;
            listBox1.Items.Add("Frame Diff MSE: " + FDMSE.ToString("###.00"));

            //Square DFD element wise
            Image<Gray, float> fSquaredDFD = fImgDFD.Copy();
            fSquaredDFD._Mul(fImgDFD);
            double MSE = fSquaredDFD.GetSum().Intensity / (float)iNunberofPixels;
            listBox1.Items.Add("MSE: " + MSE.ToString("###.00"));

            //Square SbpxDFD element wise
            Image<Gray, float> fSbpxSquaredDFD = fImgSbpxDFD.Copy();
            fSbpxSquaredDFD._Mul(fImgSbpxDFD);
            double SbpxMSE = fSbpxSquaredDFD.GetSum().Intensity / (float)iNunberofPixels;
            listBox1.Items.Add("Sub-pixel MSE: " + SbpxMSE.ToString("###.00"));
            listBox1.Items.Add(" ");

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
            else if (comboBoxRight.SelectedIndex == 4)
            {
                imageBox2.Image = imgSbpxDF;
            }
            else if (comboBoxRight.SelectedIndex == 5)
            {
                imageBox2.Image = imgSbpxDFD;
            }

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        


        
    }
}
