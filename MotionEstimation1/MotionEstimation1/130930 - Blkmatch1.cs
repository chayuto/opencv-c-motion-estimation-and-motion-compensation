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
        //========================================
        int iVBlocks, iHBlocks,iBlocks;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            iHBlocks = iFrameH / iBlocksSize;
            iVBlocks = iFrameV / iBlocksSize;
            iBlocks = iHBlocks * iVBlocks;
            int[] blkMSE = new int[iBlocks];
            int iSumBlkMSE;
            int i, j,m,n;    //counter
            //=================
            string strImagePath ="C:\\Users\\Chayut\\Dropbox\\Academic File 3.2\\Intern (img)\\Resource\\Foreman Sequences\\QCIF BMP\\";
            Image<Gray, Byte> imgN1 = new Image<Gray, Byte>(strImagePath+"foreman_qcif_2.bmp");
            Image<Gray, Byte> imgN2 = new Image<Gray, Byte>(strImagePath + "foreman_qcif_3.bmp");
            Image<Gray, Byte> imgPadded = PaddGrayIMG(imgN1, iPadPx);
            imageBox1.Image = imgPadded;

            for (i = 0; i < iVBlocks; i++)
            {
                for (j = 0; j < iHBlocks; j++)
                {
                    iSumBlkMSE = 0;
                    for (m = 0; m < iBlocksSize; m++)
                    {
                        for (n = 0; n < iBlocksSize; n++)
                        {
                            iSumBlkMSE += (int) Math.Pow(
                                (double)imgPadded.Data[i * iBlocksSize + iPadPx + m, j * iBlocksSize + iPadPx + n, 0]
                                - (double)imgN2.Data[i * iBlocksSize + m, j * iBlocksSize + n, 0]
                                ,2);
                        }//end for n(px-wise)
                    }//end for m(px-wise)

                    listBox1.Items.Add(iSumBlkMSE.ToString(""));

                }//end for j(blk-wise)
            }//end for i(blk-wise)
            
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

    }
}
