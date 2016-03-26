namespace Test2___img
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ib1 = new Emgu.CV.UI.ImageBox();
            this.btnloadimg = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLibLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMF2 = new System.Windows.Forms.TextBox();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbSourcefile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLoadSource = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCellRow = new System.Windows.Forms.TextBox();
            this.tbCellColumn = new System.Windows.Forms.TextBox();
            this.tbLibWidth = new System.Windows.Forms.TextBox();
            this.tbLibHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bgLibSize = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbHistEq = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMF1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIMRatio = new System.Windows.Forms.Label();
            this.listBoxFileList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIMSize = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblIMScrSize = new System.Windows.Forms.Label();
            this.lblIMScrRatio = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblIMScrpixel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblIMPixel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ib1)).BeginInit();
            this.bgLibSize.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ib1
            // 
            this.ib1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ib1.Location = new System.Drawing.Point(12, 12);
            this.ib1.Name = "ib1";
            this.ib1.Size = new System.Drawing.Size(382, 453);
            this.ib1.TabIndex = 2;
            this.ib1.TabStop = false;
            // 
            // btnloadimg
            // 
            this.btnloadimg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnloadimg.Location = new System.Drawing.Point(400, 505);
            this.btnloadimg.Name = "btnloadimg";
            this.btnloadimg.Size = new System.Drawing.Size(145, 26);
            this.btnloadimg.TabIndex = 3;
            this.btnloadimg.Text = "Execute";
            this.btnloadimg.UseVisualStyleBackColor = true;
            this.btnloadimg.Click += new System.EventHandler(this.btnloadimg_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 524);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 596);
            this.progressBar1.Maximum = 64;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(533, 15);
            this.progressBar1.Step = 64;
            this.progressBar1.TabIndex = 5;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Chayut\\Dropbox\\Academic File 3.2\\Intern (img)\\Resource\\Project 1 img";
            // 
            // btnLibLoad
            // 
            this.btnLibLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLibLoad.Location = new System.Drawing.Point(6, 19);
            this.btnLibLoad.Name = "btnLibLoad";
            this.btnLibLoad.Size = new System.Drawing.Size(133, 23);
            this.btnLibLoad.TabIndex = 6;
            this.btnLibLoad.Text = "Load Library";
            this.btnLibLoad.UseVisualStyleBackColor = true;
            this.btnLibLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Factor 2:";
            // 
            // tbMF2
            // 
            this.tbMF2.Location = new System.Drawing.Point(103, 44);
            this.tbMF2.Name = "tbMF2";
            this.tbMF2.Size = new System.Drawing.Size(31, 20);
            this.tbMF2.TabIndex = 8;
            this.tbMF2.Text = "4";
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(103, 66);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(31, 20);
            this.tbOffset.TabIndex = 10;
            this.tbOffset.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 574);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Library Path:";
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(80, 571);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(465, 20);
            this.tbPath.TabIndex = 12;
            // 
            // tbSourcefile
            // 
            this.tbSourcefile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourcefile.Location = new System.Drawing.Point(80, 545);
            this.tbSourcefile.Name = "tbSourcefile";
            this.tbSourcefile.ReadOnly = true;
            this.tbSourcefile.Size = new System.Drawing.Size(465, 20);
            this.tbSourcefile.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 548);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Source Img:";
            // 
            // btnLoadSource
            // 
            this.btnLoadSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSource.Location = new System.Drawing.Point(6, 19);
            this.btnLoadSource.Name = "btnLoadSource";
            this.btnLoadSource.Size = new System.Drawing.Size(133, 23);
            this.btnLoadSource.TabIndex = 15;
            this.btnLoadSource.Text = "Load";
            this.btnLoadSource.UseVisualStyleBackColor = true;
            this.btnLoadSource.Click += new System.EventHandler(this.btnLoadSource_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Columns:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Rows:";
            // 
            // tbCellRow
            // 
            this.tbCellRow.Location = new System.Drawing.Point(103, 13);
            this.tbCellRow.Name = "tbCellRow";
            this.tbCellRow.Size = new System.Drawing.Size(31, 20);
            this.tbCellRow.TabIndex = 18;
            this.tbCellRow.Text = "64";
            // 
            // tbCellColumn
            // 
            this.tbCellColumn.Location = new System.Drawing.Point(103, 39);
            this.tbCellColumn.Name = "tbCellColumn";
            this.tbCellColumn.Size = new System.Drawing.Size(31, 20);
            this.tbCellColumn.TabIndex = 19;
            this.tbCellColumn.Text = "64";
            // 
            // tbLibWidth
            // 
            this.tbLibWidth.Location = new System.Drawing.Point(103, 43);
            this.tbLibWidth.Name = "tbLibWidth";
            this.tbLibWidth.Size = new System.Drawing.Size(31, 20);
            this.tbLibWidth.TabIndex = 23;
            this.tbLibWidth.Text = "81";
            // 
            // tbLibHeight
            // 
            this.tbLibHeight.Location = new System.Drawing.Point(103, 17);
            this.tbLibHeight.Name = "tbLibHeight";
            this.tbLibHeight.Size = new System.Drawing.Size(31, 20);
            this.tbLibHeight.TabIndex = 22;
            this.tbLibHeight.Text = "115";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Height:";
            // 
            // bgLibSize
            // 
            this.bgLibSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bgLibSize.Controls.Add(this.label7);
            this.bgLibSize.Controls.Add(this.tbLibWidth);
            this.bgLibSize.Controls.Add(this.label8);
            this.bgLibSize.Controls.Add(this.tbLibHeight);
            this.bgLibSize.Location = new System.Drawing.Point(400, 227);
            this.bgLibSize.Name = "bgLibSize";
            this.bgLibSize.Size = new System.Drawing.Size(145, 79);
            this.bgLibSize.TabIndex = 24;
            this.bgLibSize.TabStop = false;
            this.bgLibSize.Text = "Library Imgs";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbHistEq);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbMF1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbMF2);
            this.groupBox2.Controls.Add(this.tbOffset);
            this.groupBox2.Location = new System.Drawing.Point(400, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 113);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Perimeters";
            // 
            // cbHistEq
            // 
            this.cbHistEq.AutoSize = true;
            this.cbHistEq.Checked = true;
            this.cbHistEq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHistEq.Location = new System.Drawing.Point(12, 88);
            this.cbHistEq.Name = "cbHistEq";
            this.cbHistEq.Size = new System.Drawing.Size(125, 17);
            this.cbHistEq.TabIndex = 13;
            this.cbHistEq.Text = "Equalized Histrogram";
            this.cbHistEq.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Factor 1:";
            // 
            // tbMF1
            // 
            this.tbMF1.Location = new System.Drawing.Point(103, 22);
            this.tbMF1.Name = "tbMF1";
            this.tbMF1.Size = new System.Drawing.Size(31, 20);
            this.tbMF1.TabIndex = 12;
            this.tbMF1.Text = "2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 478);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Image ratio = 1:";
            // 
            // lblIMRatio
            // 
            this.lblIMRatio.AutoSize = true;
            this.lblIMRatio.Location = new System.Drawing.Point(88, 478);
            this.lblIMRatio.Name = "lblIMRatio";
            this.lblIMRatio.Size = new System.Drawing.Size(13, 13);
            this.lblIMRatio.TabIndex = 27;
            this.lblIMRatio.Text = "1";
            // 
            // listBoxFileList
            // 
            this.listBoxFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFileList.FormattingEnabled = true;
            this.listBoxFileList.HorizontalScrollbar = true;
            this.listBoxFileList.Location = new System.Drawing.Point(6, 48);
            this.listBoxFileList.Name = "listBoxFileList";
            this.listBoxFileList.Size = new System.Drawing.Size(133, 56);
            this.listBoxFileList.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbCellRow);
            this.groupBox1.Controls.Add(this.tbCellColumn);
            this.groupBox1.Location = new System.Drawing.Point(400, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 68);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cells";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Image size:";
            // 
            // lblIMSize
            // 
            this.lblIMSize.AutoSize = true;
            this.lblIMSize.Location = new System.Drawing.Point(77, 500);
            this.lblIMSize.Name = "lblIMSize";
            this.lblIMSize.Size = new System.Drawing.Size(25, 13);
            this.lblIMSize.TabIndex = 31;
            this.lblIMSize.Text = "size";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Image size:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Image ratio = 1:";
            // 
            // lblIMScrSize
            // 
            this.lblIMScrSize.AutoSize = true;
            this.lblIMScrSize.Location = new System.Drawing.Point(59, 45);
            this.lblIMScrSize.Name = "lblIMScrSize";
            this.lblIMScrSize.Size = new System.Drawing.Size(27, 13);
            this.lblIMScrSize.TabIndex = 34;
            this.lblIMScrSize.Text = "Size";
            // 
            // lblIMScrRatio
            // 
            this.lblIMScrRatio.AutoSize = true;
            this.lblIMScrRatio.Location = new System.Drawing.Point(83, 71);
            this.lblIMScrRatio.Name = "lblIMScrRatio";
            this.lblIMScrRatio.Size = new System.Drawing.Size(32, 13);
            this.lblIMScrRatio.TabIndex = 35;
            this.lblIMScrRatio.Text = "Ratio";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lblIMScrpixel);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btnLoadSource);
            this.groupBox3.Controls.Add(this.lblIMScrRatio);
            this.groupBox3.Controls.Add(this.lblIMScrSize);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(400, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 92);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source Image";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 13);
            this.label16.TabIndex = 38;
            // 
            // lblIMScrpixel
            // 
            this.lblIMScrpixel.AutoSize = true;
            this.lblIMScrpixel.Location = new System.Drawing.Point(38, 58);
            this.lblIMScrpixel.Name = "lblIMScrpixel";
            this.lblIMScrpixel.Size = new System.Drawing.Size(28, 13);
            this.lblIMScrpixel.TabIndex = 37;
            this.lblIMScrpixel.Text = "pixel";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Pixels:";
            // 
            // lblIMPixel
            // 
            this.lblIMPixel.AutoSize = true;
            this.lblIMPixel.Location = new System.Drawing.Point(193, 500);
            this.lblIMPixel.Name = "lblIMPixel";
            this.lblIMPixel.Size = new System.Drawing.Size(28, 13);
            this.lblIMPixel.TabIndex = 39;
            this.lblIMPixel.Text = "pixel";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(161, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Pixels:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxFileList);
            this.groupBox4.Controls.Add(this.btnLibLoad);
            this.groupBox4.Location = new System.Drawing.Point(400, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(145, 111);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Image Library";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 614);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblIMPixel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblIMSize);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblIMRatio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bgLibSize);
            this.Controls.Add(this.tbSourcefile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnloadimg);
            this.Controls.Add(this.ib1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Photo Mosaic";
            ((System.ComponentModel.ISupportInitialize)(this.ib1)).EndInit();
            this.bgLibSize.ResumeLayout(false);
            this.bgLibSize.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ib1;
        private System.Windows.Forms.Button btnloadimg;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnLibLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMF2;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbSourcefile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLoadSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCellRow;
        private System.Windows.Forms.TextBox tbCellColumn;
        private System.Windows.Forms.TextBox tbLibWidth;
        private System.Windows.Forms.TextBox tbLibHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox bgLibSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIMRatio;
        private System.Windows.Forms.ListBox listBoxFileList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblIMSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblIMScrSize;
        private System.Windows.Forms.Label lblIMScrRatio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblIMScrpixel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblIMPixel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbMF1;
        private System.Windows.Forms.CheckBox cbHistEq;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

