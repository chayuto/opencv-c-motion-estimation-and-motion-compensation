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



namespace _220913___Face_detection
{
    public partial class Form1 : Form
    {


        Image<Bgr, Byte> image;
        List<Rectangle> faces;
        List<Rectangle> eyes;
        Capture capture = new Capture();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Application.Idle += ProcessFrame;


        }

        private void ProcessFrame(object sender, EventArgs arg)
        {

            image = capture.QueryFrame();
             //Read the HaarCascade objects
            using (CascadeClassifier face = new CascadeClassifier("haarcascade_frontalface_default.xml"))
            using (CascadeClassifier eye = new CascadeClassifier("haarcascade_eye.xml"))
            {

                using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>()) //Convert it to Grayscale
                {
                    //normalizes brightness and increases contrast of the image
                    gray._EqualizeHist();

                    //Detect the faces  from the gray scale image and store the locations as rectangle
                    //The first dimensional is the channel
                    //The second dimension is the index of the rectangle in the specific channel
                    Rectangle[] facesDetected = face.DetectMultiScale(
                       gray,
                       1.1,
                       10,
                       new Size(20, 20),
                       Size.Empty);
                    faces.AddRange(facesDetected);

                    foreach (Rectangle f in facesDetected)
                    {
                        //Set the region of interest on the faces
                        gray.ROI = f;
                        Rectangle[] eyesDetected = eye.DetectMultiScale(
                           gray,
                           1.1,
                           10,
                           new Size(20, 20),
                           Size.Empty);
                        gray.ROI = Rectangle.Empty;

                        foreach (Rectangle e in eyesDetected)
                        {
                            Rectangle eyeRect = e;
                            eyeRect.Offset(f.X, f.Y);
                            eyes.Add(eyeRect);
                        }
                    }
                }

                foreach (Rectangle faceX in faces)
                    image.Draw(faceX, new Bgr(Color.Red), 2);
                foreach (Rectangle eyeX in eyes)
                    image.Draw(eyeX, new Bgr(Color.Blue), 2);

                imageBox1.Image = image;
               
            }
        }
    }
}
