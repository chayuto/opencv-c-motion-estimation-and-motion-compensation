using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace MotionEstimation1
{
    public partial class Form1 : Form
    {
        int iBlocksSize = 4; 
        int iNFrame = 5; //no of frame to be loaded
        int iFrameH = 176, iFrameV = 144;
        int iPadPx = 7; //for 4SS
        int iShiftBig = 2;
        //========================================
        int iVBlocks, iHBlocks,iBlocks;
        int[, ,] VectorArray;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            iHBlocks = iFrameH / iBlocksSize;
            iVBlocks = iFrameV / iBlocksSize;
            iBlocks = iHBlocks * iVBlocks;
            VectorArray = new int[iVBlocks, iHBlocks, 2];
            int i, j,m,n,p,q;    //counter
            //=================
            string strImagePath ="C:\\Users\\Chayut\\Dropbox\\Academic File 3.2\\Intern (img)\\Resource\\Foreman Sequences\\QCIF BMP\\";
            Image<Gray, Byte> imgN1 = new Image<Gray, Byte>(strImagePath+"foreman_qcif_2.bmp");;
            Image<Gray, Byte> imgN2 = new Image<Gray, Byte>(strImagePath + "foreman_qcif_3.bmp");
            Image<Gray, Byte> imgN2Recon = new Image<Gray, Byte>(imgN2.Size);
            Image<Gray, Byte> imgPadded = PaddGrayIMG(imgN1, iPadPx);
            imageBox1.Image = imgPadded;

            
            for (i = 0; i < iVBlocks; i++)
            {
                for (j = 0; j < iHBlocks; j++)
                {

                    int iVectorV = 0, iVectorH = 0;
                    int iMSEminimum = 999999999;
                    for (p = -iShiftBig; p <= iShiftBig; p += iShiftBig)
                    {
                        for (q = -iShiftBig; q <= iShiftBig; q += iShiftBig)
                        {
                            int iVBlkMSE = p / 2 + 1, iHBlkMSE = q / 2 + 1;
                            int blkMSE = 0;
                            for (m = 0; m < iBlocksSize; m++)
                            {
                                for (n = 0; n < iBlocksSize; n++)
                                {
                                    blkMSE += (int)Math.Pow(
                                        (double)imgPadded.Data[i * iBlocksSize + iPadPx + m+p, j * iBlocksSize + iPadPx + n +q, 0]
                                        - (double)imgN2.Data[i * iBlocksSize + m, j * iBlocksSize + n, 0]
                                        , 2);
                                }//end for n(px-wise)
                            }//end for m(px-wise)
                            if(blkMSE<iMSEminimum)//find minimum and stpre value
                            {
                                iVectorV = p; iVectorH = q;
                                iMSEminimum=blkMSE;
                            }
                        }//end for q(shift)
                    }//end for p(shift)
                    VectorArray[i, j, 0] = iVectorV;
                    VectorArray[i, j, 1] = iVectorH;//Store vector in Vector array

                    //Point A = new Point(j * 4, i * 4);
                    //Point B = new Point(j * 4 + iVectorH, i * 4 + iVectorV);
                    //LineSegment2D line1 = new LineSegment2D(A, B);
                    //imgN1Vector.Draw(line1, new Gray(255), 1);

                }//end for j(blk-wise)
             
            }//end for i(blk-wise)
            imgN2Recon = ReconstructIMG(imgN1);
            imageBox1.Image = imgN1;
            imageBox2.Image =imgN2Recon ;
              //Text = CalculateFrameMSE(imgN1, imgN2).ToString("");
            lblMSE2.Text = CalculateFrameMSE(imgN2Recon, imgN2).ToString("");
        }//end btnStart

        private Image<Gray, Byte> PaddGrayIMG(Image<Gray, Byte> imgScr, int iPadPixel)
        {
            int iScrHeight = imgScr.Height, iScrWidth = imgScr.Width;
            int iPadHeight = iScrHeight + 2 * iPadPixel, iPadWidth = iScrWidth + 2 * iPadPixel;
            int i, j; //counter
            Image<Gray, Byte> imgPadded = new Image<Gray, Byte>(iPadWidth,iPadHeight) ;
            for (i = 0; i < iPadHeight; i++)
            {
                for (j = 0; j < iPadWidth; j++)
                {
                    if (i < iPadPixel)
                    {
                        if(j < iPadPixel)
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[0, 0, 0];
                        }
                        else if (j < iPadPixel + iScrWidth)
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[0, j - iPadPixel, 0];
                        }
                        else
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[0, iScrWidth-1, 0];
                        }
                    }

                    else if (i < iPadPixel + iScrHeight)
                    {
                        if (j < iPadPixel)
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[i - iPadPixel, 0, 0];
                        }
                        else if (j < iPadPixel + iScrWidth)
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[i - iPadPixel, j - iPadPixel, 0];
                        }
                        else
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[i - iPadPixel, iScrWidth - 1, 0];
                        }
                    }
                    else
                    {
                        if (j < iPadPixel)
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[iScrHeight - 1, 0, 0];
                        }
                        else if (j < iPadPixel + iScrWidth)
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[iScrHeight-1, j - iPadPixel, 0];
                        }
                        else
                        {
                            imgPadded.Data[i, j, 0] = imgScr.Data[iScrHeight-1, iScrWidth - 1, 0];
                        }
                    
                    }//end if-else
                }//end for
            }//end for 

            return imgPadded;
        }

        private float CalculateFrameMSE(Image<Gray, Byte> imgA, Image<Gray, Byte> imgB)
        {
            int iAHeight = imgA.Height, iAWidth = imgA.Width;
            float fSumSquareError = 0;
            int i, j; //counter
            if (iAHeight != imgB.Height || iAWidth != imgB.Width)
            {
                MessageBox.Show("Images do not have equal size");
                return 0f;
            }
            else
            {
                for (i = 0; i < iAHeight; i++)
                {
                    for (j = 0; j < iAWidth; j++)
                    {
                        fSumSquareError  += (float)Math.Pow(
                            (double)imgA.Data[i,j, 0]
                            - (double)imgB.Data[i,j, 0]
                            , 2);
                    }
                }
                return (fSumSquareError / (iAHeight * iAWidth));
                
            }//end if-else

        }//end CalculateFrameMSE

        private Image<Gray, Byte> ReconstructIMG(Image<Gray, Byte> imgScr)//construct frame N base on frame N-1
        {
            iHBlocks = iFrameH / iBlocksSize;
            iVBlocks = iFrameV / iBlocksSize;
            int i, j,m,n;    //counter
            Image<Gray, Byte> imgRecon = new Image<Gray, Byte>(imgScr.Size);
            Image<Gray, Byte> imgPadded = PaddGrayIMG(imgScr, iPadPx);

            for (i = 0; i < iVBlocks; i++)
            {
                for (j = 0; j < iHBlocks; j++)
                {
                     
                    for (m = 0; m < iBlocksSize; m++)
                    {
                        for (n = 0; n < iBlocksSize; n++)
                        {

                            imgRecon.Data[
                                i * iBlocksSize+m ,
                                j * iBlocksSize+ n , 0] =
                               imgPadded.Data[
                               i * iBlocksSize + iPadPx + m + VectorArray[i,j,0],
                               j * iBlocksSize + iPadPx + n + VectorArray[i, j, 1], 0];
                                
                        }//end for n(px-wise)
                    }//end for m(px-wise)
                            
                        
                }//end for i(blk-wise) 
            }//end btnStart
            return imgRecon;
        }

    }
}
