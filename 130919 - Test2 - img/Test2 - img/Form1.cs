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
using Emgu.CV.UI ;



namespace Test2___img
{
    public partial class Form1 : Form
    {
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string folder_path = "";
        string strSourceimg = "";
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnloadimg_Click(object sender, EventArgs e)
        {
            
            int file_no = 0,i,j,k,l,m; //counters
            int iIMOffset, iIMMF;
            int iCellHeight, iCellWidth, iCellRow, iCellColumn,iBaseWidth,iBaseHeight;
            string strfileload = "";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    
            if (folder_path != "" &&strSourceimg!="")// check is folder path is loaded
            {
                try
                {
                    iCellHeight = int.Parse(tbLibHeight.Text);
                    iCellWidth = int.Parse(tbLibWidth.Text);
                    iCellRow = int.Parse(tbCellRow.Text);
                    iCellColumn = int.Parse(tbCellColumn.Text);
                    iBaseHeight = iCellHeight * iCellRow;
                    iBaseWidth = iCellWidth * iCellColumn;
                    progressBar1.Maximum = iCellRow;
                    progressBar1.Step = iCellRow;
                    lblIMRation.Text = (iBaseHeight * 1.0F/ iBaseWidth ).ToString("#0.##");
                    lblIMRation.Update();
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Image<Gray, Byte> img1 = new Image<Gray, Byte>(iBaseWidth , iBaseHeight, new Gray(0));
                    Image<Gray, Byte> img2 = new Image<Gray, Byte>(strSourceimg);
                    Image<Gray, Byte> img3 = img2.Resize(iBaseWidth, iBaseHeight, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    Image<Gray, Byte>[] img_arr = new Image<Gray, Byte>[77];
                    Random rnd = new Random();
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    

                    for (file_no = 1; file_no <= 77; file_no++)
                    {
                        strfileload = folder_path + "\\1 (" + file_no.ToString() + ").jpg";
                        img_arr[file_no - 1] = new Image<Gray, Byte>(strfileload).Resize(iCellWidth ,iCellHeight, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    }

                   
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
                    iIMMF = int.Parse(tbMF.Text);
                    iIMOffset = int.Parse(tbOffset.Text);
                    if(iIMMF>=1&&iIMMF<100&&iIMOffset>-300&&iIMOffset<300)
                    {

                        for (k = 0; k <= iCellRow-1 ; k++)
                        {
                            lblStatus.Text = "Processing..." + (k*1.0F/(iCellRow-1)).ToString("#0.##%");
                            lblStatus.Update();
                            progressBar1.Value = k + 1;

                            for (l = 0; l <= iCellColumn - 1; l++)
                            {

                                m = rnd.Next(0, 77);
                                for (i = 0; i <= iCellHeight-1; i++)
                                {
                                    for (j = 0; j <= iCellWidth-1; j++)
                                    {
                                        img1[i + (l * iCellHeight ), j + (k * iCellWidth )] = new Gray(img3[i + (l * iCellHeight ), j + (k * iCellWidth )].Intensity + img_arr[m][i, j].Intensity / iIMMF + iIMOffset);

                                    }
                                }
                            }
                        }

                    ib1.Image = img1; //Display image to the imagebox
                    lblStatus.Text = "Processing Completed";
                    
                    }
                    else
                    {
                        lblStatus.Text = "Error";
                        MessageBox.Show("invalid perimeters");
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
                }
                catch
                {
                    lblStatus.Text = "Error";
                    MessageBox.Show("System error");
                    return;
                }
            }
            else
            {
                lblStatus.Text = "Error";
                MessageBox.Show("Please checked if you have loaded images");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lblStatus.Text = "Image Library Loaded";
                folder_path = folderBrowserDialog1.SelectedPath;
                tbPath.Text = folder_path;
            }
        }

        private void btnLoadSource_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "JPGP file|*.jpg|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false ;

            // Call the ShowDialog method to show the dialog box.
            openFileDialog1.ShowDialog();

            
            strSourceimg= openFileDialog1.FileName;
            if (strSourceimg != "")
            {
                try
                {
                    ib1.Image = new Image<Bgr, Byte>(strSourceimg);
                    tbSourcefile.Text = strSourceimg;
                    lblStatus.Text = "Source Image Loaded";
                }
                catch
                {
                    lblStatus.Text = "Error";
                    MessageBox.Show("Invalid File");
                }
            }
        }

       

        
    }
}


    //ImageViewer viewer = new ImageViewer(); //create an image viewer
    //        Capture capture = new Capture(); //create a camera captue
    //        Application.Idle += new EventHandler(delegate(object sende1r, EventArgs e1)
    //        {  //run this until application closed (close button click on image viewer)
    //            viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
    //        });

    //        viewer.ShowDialog(); //show the image viewer
    //    