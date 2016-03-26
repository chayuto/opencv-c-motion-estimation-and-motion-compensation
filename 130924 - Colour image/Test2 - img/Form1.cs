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
        Image<Gray, Byte> img1 ;
        Image<Gray, Byte> img2 ;
        Image<Gray, Byte> img3 ;
        Image<Gray, Byte> img4 ;
        Image<Gray, Byte>[] img_arr;
        Boolean blnIMMatrixConstructed = false;
        Boolean blnIMBaseLoaded = false;
        int iIMAlpha;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnloadimg_Click(object sender, EventArgs e)
        {
            
            int i,j,k,l,m,o; //counters
            
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
                    iIMAlpha = trackBar1.Value;
                    o = 0;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    img1 = new Image<Gray, Byte>(iBaseWidth , iBaseHeight, new Gray(0));
                    img2 = new Image<Gray, Byte>(strSourceimg);
                    img3 = img2.Resize(iBaseWidth, iBaseHeight, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    img4 = new Image<Gray, Byte>(iBaseWidth, iBaseHeight, new Gray(0));
                    img_arr = new Image<Gray, Byte>[iLibrarySize];
                    Random rnd = new Random();

                    blnIMBaseLoaded = true;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    foreach (string filepath in fileArray)
                    {
                        img_arr[o]=new Image<Gray, Byte>(filepath).Resize(iCellWidth ,iCellHeight, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        o++;
                            
                    }        
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////    

                    
                    
                       
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
                                    img4.Data[i + (l * iCellHeight), j + (k * iCellWidth),0]= img_arr[m].Data[i, j,0];

                                }
                            }
                        }
                    }

                    blnIMMatrixConstructed = true;

                    img1 = img4.AddWeighted(img3, iIMAlpha / 100.0F, (100-iIMAlpha) / 100.0F, 0.0f);

                        

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
                tbPath.SelectionStart = tbPath.Text.Length - 1;
                //////////////////////////////////////////////////////////////////////////////////////////
                fileArray = Directory.GetFiles(folder_path+ "\\", "*.jpg");
                foreach (string filename in fileArray)
                {
                    listBoxFileList.Items.Add(filename);
                }

                listBoxFileList.SelectedIndex = listBoxFileList.Items.Count - 1;
                listBoxFileList.SelectedIndex = -1;

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
                    tbSourcefile.SelectionStart = tbSourcefile.TextLength - 1;

                    lblStatus.Text = "Source Image Loaded";
                }
                catch
                {
                    lblStatus.Text = "Error";
                    MessageBox.Show("Invalid File");
                }
            }
        }

        

        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblStatus.Text = "Alpha value:" + trackBar1.Value.ToString();
            lblStatus.Update();
            if (blnIMMatrixConstructed && blnIMBaseLoaded)
            {
                
                iIMAlpha = trackBar1.Value;
                img1 =  img4.AddWeighted(img3, iIMAlpha / 100.0F, (100 - iIMAlpha) / 100.0F, 0.0f);



                if (cbHistEq.Checked)
                {
                    img1._EqualizeHist();//equalised histrogram
                }
                //ib1.Image.Dispose();
                ib1.Image = img1; //Display image to the imagebox
               
            }
        }

        private void btnRGB_Click(object sender, EventArgs e)
        {
            if (folder_path != "" && strSourceimg != "" && blnIMMatrixConstructed)// check is folder path is loaded
            {
                Image<Rgb, Byte> RBGimg = new Image<Rgb, Byte>(strSourceimg).Resize(img1.Size.Width, img1.Size.Height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Image<Rgb, Byte> RBGbase = new Image<Rgb, Byte>(img1.Size);
                Image<Rgb, Byte> RBGout = new Image<Rgb, Byte>(img1.Size);
                RBGbase[0] = img4;
                RBGbase[1] = img4;
                RBGbase[2] = img4;

                RBGout = RBGimg.AddWeighted(RBGbase, iIMAlpha / 100.0F, (100 - iIMAlpha) / 100.0F, 0.0f);
                ib1.Image.Dispose();
                ib1.Image = RBGout; //Display image to the imagebox
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

      



        }
}



   