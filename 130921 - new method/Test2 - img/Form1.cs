using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
        string[] fileArray;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnloadimg_Click(object sender, EventArgs e)
        {
            
            int i,j,k,l,m,o; //counters
            int iIMOffset,iIMMF1, iIMMF2,iIMAl;
            int iCellHeight, iCellWidth, iCellRow, iCellColumn,iBaseWidth,iBaseHeight; //images sizes
            int iLibrarySize;
            int height1, width1, pixels1;
            float ratio1;
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
                    iLibrarySize = fileArray.Length;
                    iIMMF1 = int.Parse(tbMF1.Text);
                    iIMMF2 = int.Parse(tbMF2.Text);
                    iIMOffset = int.Parse(tbOffset.Text);
                    iIMAl = trackBar1.Value;
                    o = 0;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    Image<Gray, Byte> img1 = new Image<Gray, Byte>(iBaseWidth , iBaseHeight, new Gray(0));
                    Image<Gray, Byte> img2 = new Image<Gray, Byte>(strSourceimg);
                    Image<Gray, Byte> img3 = img2.Resize(iBaseWidth, iBaseHeight, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    Image<Gray, Byte> img4 = new Image<Gray, Byte>(iBaseWidth, iBaseHeight, new Gray(0));
                    Image<Gray, Byte>[] img_arr = new Image<Gray, Byte>[iLibrarySize];
                    Random rnd = new Random();
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    foreach (string filepath in fileArray)
                    {
                        img_arr[o]=new Image<Gray, Byte>(filepath).Resize(iCellWidth ,iCellHeight, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        o++;
                            
                    }        
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////    

                    
                    if(iIMMF2>=1&&iIMMF2<100&&iIMOffset>-300&&iIMOffset<300)
                    {
                        if (!cbAddWeighted.Checked)
                        {
                            for (k = 0; k <= iCellRow - 1; k++)
                            {
                                ib1.Image = img1;
                                ib1.Update();
                                lblStatus.Text = "Processing..." + (k * 1.0F / (iCellRow - 1)).ToString("#0.##%");
                                lblStatus.Update();
                                progressBar1.Value = k + 1;

                                for (l = 0; l <= iCellColumn - 1; l++)
                                {

                                    m = rnd.Next(0, iLibrarySize - 1);
                                    for (i = 0; i <= iCellHeight - 1; i++)
                                    {
                                        for (j = 0; j <= iCellWidth - 1; j++)
                                        {
                                            img1[i + (l * iCellHeight), j + (k * iCellWidth)] = new Gray(img3[i + (l * iCellHeight), j + (k * iCellWidth)].Intensity / iIMMF1 + img_arr[m][i, j].Intensity / iIMMF2 + iIMOffset);

                                        }
                                    }
                                }
                            }


                        }
                        else
                        {
                            for (k = 0; k <= iCellRow - 1; k++)
                            {
                                ib1.Image = img4;
                                ib1.Update();
                                lblStatus.Text = "Processing..." + (k * 1.0F / (iCellRow - 1)).ToString("#0.##%");
                                lblStatus.Update();
                                progressBar1.Value = k + 1;

                                for (l = 0; l <= iCellColumn - 1; l++)
                                {

                                    m = rnd.Next(0, iLibrarySize - 1);
                                    for (i = 0; i <= iCellHeight - 1; i++)
                                    {
                                        for (j = 0; j <= iCellWidth - 1; j++)
                                        {
                                            img4[i + (l * iCellHeight), j + (k * iCellWidth)]= img_arr[m][i, j];

                                        }
                                    }
                                }
                            }

                            img1 = img4.AddWeighted(img3, iIMAl / 100.0F, (100-iIMAl) / 100.0F, 0.0f);

                        }

                        if (cbHistEq.Checked)
                        {
                            img1._EqualizeHist();//equalised histrogram
                        }


                    ib1.Image = img1; //Display image to the imagebox

                    height1 = ib1.Image.Size.Height;
                    width1 = ib1.Image.Size.Width;
                    pixels1 = height1 * width1;
                    ratio1 = height1 * 1.0F / width1;
                    lblIMSize.Text = height1.ToString() + " x " + width1.ToString();
                    lblIMRatio.Text = ratio1.ToString("#0.##");
                    lblIMPixel.Text = pixels1.ToString("###,###,###");

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
            listBoxFileList.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                folder_path = folderBrowserDialog1.SelectedPath;
                tbPath.Text = folder_path;
                //////////////////////////////////////////////////////////////////////////////////////////
                fileArray = Directory.GetFiles(folder_path+ "\\", "*.jpg");
                foreach (string filename in fileArray)
                {
                    listBoxFileList.Items.Add(filename);
                }

                lblStatus.Text = "Image Library Loaded: "+ fileArray.Length.ToString() +" Images";
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
                    int height1, width1, pixels1;
                    float ratio1;
                    ib1.Image = new Image<Bgr, Byte>(strSourceimg);
                    height1 = ib1.Image.Size.Height;
                    width1 = ib1.Image.Size.Width;
                    pixels1 = height1 * width1;
                    ratio1 = height1 * 1.0F / width1;
                    lblIMScrSize.Text = height1.ToString() + " x " + width1.ToString();
                    lblIMScrRatio.Text = ratio1.ToString("#0.##");
                    lblIMScrpixel.Text = pixels1.ToString("###,###,###");

                    lblIMSize.Text = lblIMScrSize.Text;

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

        

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "" + trackBar1.Value.ToString();
            lblStatus.Update();
        }

        private void cbAddWeighted_CheckedChanged(object sender, EventArgs e)
        {

            if (cbAddWeighted.Checked)
            {
                tbMF1.Enabled = false;
                tbMF2.Enabled = false;
                tbOffset.Enabled = false;
                trackBar1.Enabled = true;

            }
            else
            {
                tbMF1.Enabled = true;
                tbMF2.Enabled = true;
                tbOffset.Enabled = true;
                trackBar1.Enabled = false;
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