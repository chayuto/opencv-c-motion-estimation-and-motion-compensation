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

namespace Test1_opencv1
{
    public partial class Form1 : Form
    {

        Capture capWebcam = null;
        bool blnCapProg = false;
        Image<Bgr, Byte> imgOriginal;
        Image<Gray, Byte> imgProcess;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (blnCapProg == true)
            {
                Application.Idle -= processFrameAndUpdateGUI;
                blnCapProg = false;
                btnresume.Text = "resume";
            }
            else
            {
                Application.Idle += processFrameAndUpdateGUI;
                blnCapProg = true;
                btnresume.Text = "pause";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                capWebcam = new Capture();  //associate capture object to webcam
            }
            catch (NullReferenceException except)
            {
                txtXY.Text = except.Message;
                return;
            }
            Application.Idle += processFrameAndUpdateGUI; //add process imaging function
            blnCapProg = true;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capWebcam != null)
            {
                capWebcam.Dispose();
            }

        }


        void processFrameAndUpdateGUI(object sender, EventArgs arg)
        {
            imgOriginal = capWebcam.QueryFrame();
            if (imageBoxOriginal == null) return;

            imgProcess = imgOriginal.InRange(new Bgr(0, 0, 175), new Bgr(100, 100, 256));


            imgProcess = imgProcess.SmoothGaussian(9);

            CircleF[] circles = imgProcess.HoughCircles(new Gray(100), new Gray(50), 2, imgProcess.Height / 4, 10, 400)[0];

            foreach (CircleF circle in circles)
            {
                if(txtXY.Text!= "") txtXY.AppendText(Environment.NewLine);
                
                txtXY.AppendText("ball position = X" + circle.Center.X.ToString().PadLeft(4) + ", Y" + circle.Center.Y.ToString().PadLeft(4) + " ,r =" + circle.Radius.ToString("###.000").PadLeft(7));

                txtXY.ScrollToCaret();


                CvInvoke.cvCircle(imgOriginal, new Point((int)circle.Center.X, (int)circle.Center.Y), 3, new MCvScalar(0, 255, 0), -1, LINE_TYPE.CV_AA, 0);


                imgOriginal.Draw(circle, new Bgr(Color.Red), 3);
            }

            imageBoxOriginal.Image = imgOriginal;
            imageBoxProcessed.Image = imgProcess;
        }
        
    }
}
