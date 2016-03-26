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
    public partial class FormTest1 : Form
    {
        float i = 0.0f, j = 0.0f;
        public FormTest1()
        {
            InitializeComponent();
        }

        private void buttonExe_Click(object sender, EventArgs e)
        {

            Image<Gray, Byte> imgCurrent, imgPrevious,imgSbpx;
            imgCurrent = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Foreman Sequences\CIF BMP\foreman_cif_3.bmp");
            imgPrevious = new Image<Gray, Byte>(@"C:\Users\Chayut\Dropbox\Academic File 3.2\Intern (img)\Resource\Foreman Sequences\CIF BMP\foreman_cif_2.bmp");
            imgSbpx = new Image<Gray,Byte> (imgPrevious.Size);

            CvInvoke.cvGetRectSubPix(imgCurrent.Ptr, imgSbpx.Ptr, new PointF((float)imgCurrent.Width /2+i,(float)imgCurrent.Height  /2+j));

            imageBox1.Image = imgSbpx;
            
            i += 0.25f;
            j += 0.25f;
            

            //Image<Gray, Byte> fBlk = new Image<Gray, byte>(2, 2);
            //Matrix<Single> MatA = new Matrix<float>(2, 2);
            //Matrix<Single> MatB = new Matrix<float>(2, 1);
            //Matrix<Single> MatC = new Matrix<float>(1, 2);
            //MatA.Data[0, 0] = 127;
            //MatA.Data[1, 0] = 255;
            //MatA.Data[0, 1] = 0;
            //MatA.Data[1, 1] = 127;

            //CvInvoke.cvConvert(MatA,fBlk);
           

            //for (int i = 0; i <= 4; i++)
            //{
            //    for (int j = 0; j <= 4; j++)
            //    {
            //        MatB.Data[0, 0] = 1.0f -0.25f*j;
            //        MatB.Data[1, 0] =  0.25f*j;

            //        MatC.Data[0, 0] = 1.0f - 0.25f * i;
            //        MatC.Data[0, 1] = 0.25f * i; ;

            //        Matrix<Single> MatResult = MatC * MatA * MatB;
            //        listBox1.Items.Add(MatResult.Data[0, 0].ToString());

            //    }
            //}


        }
    }
}
