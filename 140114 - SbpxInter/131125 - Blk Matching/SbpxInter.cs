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

        Image<Gray, Byte> imgCurrent, imgPrevious,imgNext,imgFD,imgDF,imgDFD,imgSbpxDF,imgSbpxDFD;
        Image<Gray, Byte> imgInterDF, imgInterDFD, imgSbpxInterDF, imgSbpxInterDFD;
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
                imgNext = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Foreman Sequences\CIF BMP\foreman_cif_4.bmp");
            
            }
            else if (comboBoxSequence.SelectedIndex == 1)
            {
                imgCurrent = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Waterfall Sequence\waterfall_cif_3.bmp");
                imgPrevious = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Waterfall Sequence\waterfall_cif_2.bmp");
                imgNext = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Waterfall Sequence\waterfall_cif_4.bmp");
            
            }
            else
            {
                imgCurrent = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Stefan Sequence\stefan_cif_3.bmp");
                imgPrevious = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Stefan Sequence\stefan_cif_2.bmp");
                imgNext = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Stefan Sequence\stefan_cif_4.bmp");

            }
            
            int iSearchRange = trackbarSearchRange.Value;
            int iBlkSize = 1 << (trackBar1.Value + 1);
            Size sizeBlk = new Size(iBlkSize, iBlkSize);

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
            Image<Gray, Byte> imgNextPad = new Image<Gray, Byte>(iFrameWidth + 2 * iPadLength, iFrameHeight + 2 * iPadLength);
            CvInvoke.cvCopyMakeBorder(imgPrevious.Ptr, imgPreviousPad.Ptr , new Point(iPadLength,iPadLength), Emgu.CV.CvEnum.BORDER_TYPE.REPLICATE, new MCvScalar(0f));
            CvInvoke.cvCopyMakeBorder(imgNext.Ptr, imgNextPad.Ptr, new Point(iPadLength, iPadLength), Emgu.CV.CvEnum.BORDER_TYPE.REPLICATE, new MCvScalar(0f)); 
            
            //preparing DF 

            imgDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight,new Gray(0f));
            imgSbpxDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight, new Gray(0f));
            imgInterDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight, new Gray(0f));
            imgSbpxInterDF = new Image<Gray, Byte>(iFrameWidth, iFrameHeight, new Gray(0f));

            //to float conversion
            Image<Gray, float> fImgCurrent = imgCurrent.Convert<Gray, Single>();
            Image<Gray, float> fImgPrevious = imgPrevious.Convert<Gray, Single>();
            Image<Gray, float> fImgPreviousPad = imgPreviousPad.Convert<Gray, Single>();
            Image<Gray, float> fImgNext = imgNext.Convert<Gray, Single>();
            Image<Gray, float> fImgNextPad = imgNextPad.Convert<Gray, Single>();

            fImgPreviousMatchResult = fImgPreviousPad.Copy();

            //Frame difference
            Image<Gray, float> fImgFD = fImgCurrent - fImgPrevious;
            imgFD = (fImgFD + 127).Convert<Gray, Byte>();//for display

            //decaring vector array 
            Matrix<int> VectorArrayX = new Matrix<int>(iRunX, iRunY);
            Matrix<int> VectorArrayY = new Matrix<int>(iRunX, iRunY);
            Matrix<int> VectorArrayNextX = new Matrix<int>(iRunX, iRunY);
            Matrix<int> VectorArrayNextY = new Matrix<int>(iRunX, iRunY);

            //decaring Sbpx vector array 
            Matrix<float> VectorArraySbpxX = new Matrix<float>(iRunX, iRunY);
            Matrix<float> VectorArraySbpxY = new Matrix<float>(iRunX, iRunY);
            Matrix<float> VectorArraySbpxNextX = new Matrix<float>(iRunX, iRunY);
            Matrix<float> VectorArraySbpxNextY = new Matrix<float>(iRunX, iRunY);
          

            //Block Matching
            for (int iFramePointerY = 0; iFramePointerY < iFrameHeight; iFramePointerY += iBlkSize)
            {
                for (int iFramePointerX = 0; iFramePointerX < iFrameWidth; iFramePointerX += iBlkSize)
                {
                    //varible declaration
                    int iBlkPointerX = iFramePointerX / iBlkSize;
                    int iBlkPointerY = iFramePointerY / iBlkSize;

                    //====values min search=====
                    double minValSearch = 999999999999.9f;
                    int minValIndex = 0;
                    double minValSearchNext = 999999999999.9f;
                    int minValIndexNext = 0;

                    //====values sbpx stack=======
                    double[] minValStack = new double[16];
                    Point[] minPointStack = new Point[16];
                    double[] minValNextStack = new double[16];
                    Point[] minPointNextStack = new Point[16];

                    //define ROI
                    Rectangle recSearchWindow = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize + 2 * iSearchRange, iBlkSize + 2 * iSearchRange);
                    
                    fImgCurrent.ROI = new Rectangle(iFramePointerX, iFramePointerY, iBlkSize, iBlkSize);
                    fImgPreviousMatchResult.ROI = recSearchWindow;
                    fImgPreviousPad.ROI = recSearchWindow;
                    fImgNextPad.ROI = recSearchWindow;     

                    for (int iSbpxOffsetX = 0; iSbpxOffsetX <= 3; iSbpxOffsetX ++)
                    {
                        for (int iSbpxOffsetY = 0; iSbpxOffsetY <= 3; iSbpxOffsetY ++)
                        {
                            int iFrameIndex = iSbpxOffsetX * 4 + iSbpxOffsetY;
                            float fSbpxOffsetX  = iSbpxOffsetX * 0.25f;
                            float fSbpxOffsetY  = iSbpxOffsetY * 0.25f;
                            

                            Image<Gray, Single> fBlkSbpx = new Image<Gray, float>(recSearchWindow.Size);
                            Image<Gray, Single> fBlkSbpxNext = new Image<Gray, float>(recSearchWindow.Size);
                            
                            PointF ptfBlkCen = new PointF((float)(recSearchWindow.Width - 1.0f) / 2 + fSbpxOffsetX, (float)(recSearchWindow.Height - 1.0f) / 2 + fSbpxOffsetY);
                            CvInvoke.cvGetRectSubPix(fImgPreviousPad.Ptr, fBlkSbpx.Ptr,  ptfBlkCen);
                            CvInvoke.cvGetRectSubPix(fImgNextPad.Ptr, fBlkSbpxNext.Ptr, ptfBlkCen);
                    
                           

                            Image<Gray, float> tm = fBlkSbpx.MatchTemplate(fImgCurrent, Emgu.CV.CvEnum.TM_TYPE.CV_TM_SQDIFF);
                            Image<Gray, float> tmNext = fBlkSbpxNext.MatchTemplate(fImgCurrent, Emgu.CV.CvEnum.TM_TYPE.CV_TM_SQDIFF);
                            

                            double minval = 0, maxval = 0;
                            Point minPoint = new Point(0, 0);
                            Point maxPoint = new Point(0, 0);
                            IntPtr i = IntPtr.Zero;
                            //Previous Frame
                            CvInvoke.cvMinMaxLoc(tm.Ptr, ref minval, ref maxval, ref minPoint, ref maxPoint, IntPtr.Zero);
                            
                            
                            minValStack[iFrameIndex] = minval;
                            minPointStack[iFrameIndex] = minPoint;

                            if (minval < minValSearch)
                            {
                                minValSearch = minval;
                                minValIndex = iFrameIndex;
                            }
                            if (iFrameIndex == 0) // plot square on image
                            {
                                fImgPreviousMatchResult.Draw(new Rectangle(minPoint, sizeBlk), new Gray(0), 1);
                                fImgPreviousMatchResult.Draw(new LineSegment2D(new Point(minPoint.X  + iBlkSize / 2, minPoint.Y+ iBlkSize / 2), new Point(iSearchRange + iBlkSize / 2, iSearchRange+ iBlkSize / 2)), new Gray(255), 1);
                                    
                            }
                            //Next Frame
                            CvInvoke.cvMinMaxLoc(tmNext.Ptr, ref minval, ref maxval, ref minPoint, ref maxPoint, IntPtr.Zero);


                            minValNextStack[iFrameIndex] = minval;
                            minPointNextStack[iFrameIndex] = minPoint;

                            if (minval < minValSearchNext)
                            {
                                minValSearchNext = minval;
                                minValIndexNext = iFrameIndex;
                            }

                        }
                    }

                    //full pixels
                    //convert minium point to motio nvector
                    //store result vector into vector array
                    //Previous
                    VectorArrayX.Data[iBlkPointerX, iBlkPointerY] = 
                        minPointStack[0].X - iSearchRange;
                    VectorArrayY.Data[iBlkPointerX, iBlkPointerY] = 
                        minPointStack[0].Y - iSearchRange;
                    //Next
                    VectorArrayNextX.Data[iBlkPointerX, iBlkPointerY] =
                        minPointNextStack[0].X - iSearchRange;
                    VectorArrayNextY.Data[iBlkPointerX, iBlkPointerY] =
                        minPointNextStack[0].Y - iSearchRange;



                    //Sub-pixels
                    //convert minium point to motio nvector
                    //store result vector into vector array
                    //Previous
                    VectorArraySbpxX.Data[iBlkPointerX, iBlkPointerY] =
                        minPointStack[minValIndex].X - iSearchRange + (minValIndex / (int)4) * 0.25f;
                    VectorArraySbpxY.Data[iBlkPointerX, iBlkPointerY] = 
                        minPointStack[minValIndex].Y - iSearchRange + (minValIndex % (int)4) * 0.25f;
                    //Next
                    VectorArraySbpxNextX.Data[iBlkPointerX, iBlkPointerY] =
                        minPointNextStack[minValIndexNext].X - iSearchRange + (minValIndexNext / (int)4) * 0.25f;
                    VectorArraySbpxNextY.Data[iBlkPointerX, iBlkPointerY] =
                        minPointNextStack[minValIndexNext].Y - iSearchRange + (minValIndexNext % (int)4) * 0.25f; 


                    //reset ROIs
                    fImgPreviousMatchResult.ROI = Rectangle.Empty;
                    fImgPreviousPad.ROI = Rectangle.Empty;
                    fImgNextPad.ROI = Rectangle.Empty;
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
                    
                    Image<Gray, Byte> blkPrevious = new Image<Gray,byte>(sizeBlk);
                    Image<Gray, Byte> blkPreviousSbpx = new Image<Gray, byte>(sizeBlk),
                        blkNext = new Image<Gray, byte>(sizeBlk),
                        blkNextSbpx = new Image<Gray, byte>(sizeBlk);
                    
                    
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

                    //Next frame
                    //rethrive vector motion array
                    iShiftX = VectorArrayNextX.Data[iBlkPointerX, iBlkPointerY];
                    iShiftY = VectorArrayNextY.Data[iBlkPointerX, iBlkPointerY];
                    //obtain blk Previous
                    imgNextPad.ROI = new Rectangle(iFramePointerX + iSearchRange + iShiftX, iFramePointerY + iSearchRange + iShiftY, iBlkSize, iBlkSize);
                    imgNextPad.CopyTo(blkNext);

                    //Sub-pixels

                    //Previous
                    //rethrive vector motion array
                    float fShiftX = VectorArraySbpxX.Data[iBlkPointerX, iBlkPointerY];
                    float fShiftY = VectorArraySbpxY.Data[iBlkPointerX, iBlkPointerY];

                    //define ROIs
                    imgPreviousPad.ROI = Rectangle.Empty;

                    PointF pfCenter = new PointF(
                        iFramePointerX + iPadLength +(recBlk.Width -1)*0.5f +fShiftX ,
                        iFramePointerY + iPadLength + (recBlk.Height - 1) * 0.5f + fShiftY);
                    CvInvoke.cvGetRectSubPix(imgPreviousPad.Ptr, blkPreviousSbpx.Ptr, pfCenter);

                    //Next
                    //rethrive vector motion array
                    fShiftX = VectorArraySbpxNextX.Data[iBlkPointerX, iBlkPointerY];
                    fShiftY = VectorArraySbpxNextY.Data[iBlkPointerX, iBlkPointerY];

                    //define ROIs
                    imgNextPad.ROI = Rectangle.Empty;

                     pfCenter = new PointF(
                       iFramePointerX + iPadLength + (recBlk.Width - 1) * 0.5f + fShiftX,
                       iFramePointerY + iPadLength + (recBlk.Height - 1) * 0.5f + fShiftY);
                    CvInvoke.cvGetRectSubPix(imgNextPad.Ptr, blkNextSbpx.Ptr, pfCenter);



                    //set ROI for placement
                    imgDF.ROI = recBlk;
                    imgSbpxDF.ROI = recBlk;
                    imgInterDF.ROI = recBlk;
                    imgSbpxInterDF.ROI = recBlk;

                    //block placement
                    blkPrevious.CopyTo(imgDF);
                    blkPreviousSbpx.CopyTo(imgSbpxDF);

                    

                    (blkNext / 2 + blkPrevious / 2).CopyTo(imgInterDF);
                    ( blkNextSbpx / 2 + blkPreviousSbpx / 2).CopyTo(imgSbpxInterDF);

                    //(blkNextSbpx.Convert<Gray, Single>() / 2 + blkPreviousSbpx.Convert<Gray, Single>() / 2).Convert<Gray, Byte>().CopyTo(imgSbpxInterDF);

                    
                }
            }

            //reset ROIs
            imgDF.ROI = Rectangle.Empty;
            imgSbpxDF.ROI = Rectangle.Empty;
            imgSbpxInterDF.ROI = Rectangle.Empty;
            imgInterDF.ROI = Rectangle.Empty;

            //Obtain DFD
            Image<Gray,float> fImgDF = imgDF.Convert<Gray, Single>();
            Image<Gray, float> fImgDFD = fImgCurrent - fImgDF;
            imgDFD = (fImgDFD + 127).Convert<Gray, Byte>();//for display

            Image<Gray, float> fImgSbpxDF = imgSbpxDF.Convert<Gray, Single>();
            Image<Gray, float> fImgSbpxDFD = fImgCurrent - fImgSbpxDF;
            imgSbpxDFD = (fImgSbpxDFD + 127).Convert<Gray, Byte>();//for display

            Image<Gray, float> fImgInterDF = imgInterDF.Convert<Gray, Single>();
            Image<Gray, float> fImgInterDFD = fImgCurrent - fImgInterDF;
            imgInterDFD = (fImgInterDFD + 127).Convert<Gray, Byte>();//for display

            Image<Gray, float> fImgSbpxInterDF = imgSbpxInterDF.Convert<Gray, Single>();
            Image<Gray, float> fImgSbpxInterDFD = fImgCurrent - fImgSbpxInterDF;
            imgSbpxInterDFD = (fImgSbpxInterDFD + 127).Convert<Gray, Byte>();//for display

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

            //Square InterDFD element wise
            Image<Gray, float> fInterSquaredDFD = fImgInterDFD.Copy();
            fInterSquaredDFD._Mul(fImgInterDFD);
            double InterMSE = fInterSquaredDFD.GetSum().Intensity / (float)iNunberofPixels;
            listBox1.Items.Add("Inter MSE: " + InterMSE.ToString("###.00"));

            //Square SbpxInterDFD element wise
            Image<Gray, float> fSbpxInterSquaredDFD = fImgSbpxInterDFD.Copy();
            fSbpxInterSquaredDFD._Mul(fImgSbpxInterDFD);
            double SbpxInterMSE = fSbpxInterSquaredDFD.GetSum().Intensity / (float)iNunberofPixels;
            listBox1.Items.Add("Spbx Inter MSE: " + SbpxInterMSE.ToString("###.00"));
            listBox1.Items.Add(" ");

            imageBox2.Image = fImgPreviousMatchResult;
            imageBox1.Image = fImgCurrent;
            comboboxLeft.SelectedIndex = 1;
            comboboxLeft.Enabled = true;
            comboBoxRight.SelectedIndex = 0;
            comboBoxRight.Enabled = true;
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
                imageBox2.Image = imgSbpxDF;
            }
            else if (comboBoxRight.SelectedIndex == 3)
            {
                imageBox2.Image = imgInterDF;
            }
            else if (comboBoxRight.SelectedIndex == 4)
            {
                imageBox2.Image = imgSbpxInterDF;
            }
            else if (comboBoxRight.SelectedIndex == 5)
            {
                imageBox2.Image = imgFD;
            }
            else if (comboBoxRight.SelectedIndex == 6)
            {
                imageBox2.Image = imgDFD;
            }
            else if (comboBoxRight.SelectedIndex == 7)
            {
                imageBox2.Image = imgSbpxDFD;
            }
            else if (comboBoxRight.SelectedIndex == 8)
            {
                imageBox2.Image = imgInterDFD;
            }
            else if (comboBoxRight.SelectedIndex == 9)
            {
                imageBox2.Image = imgSbpxInterDFD;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxRight.SelectedIndex != 9)
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
            else { comboBoxRight.SelectedIndex = 9; }
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
            toolTip1.SetToolTip(trackBar1, (1 << (trackBar1.Value + 1)).ToString());
        
        }

        

        


        
    }
}
