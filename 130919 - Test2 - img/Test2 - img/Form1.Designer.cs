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
            this.tbMF = new System.Windows.Forms.TextBox();
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
            this.label9 = new System.Windows.Forms.Label();
            this.lblIMRation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ib1)).BeginInit();
            this.bgLibSize.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ib1
            // 
            this.ib1.Location = new System.Drawing.Point(29, 12);
            this.ib1.Name = "ib1";
            this.ib1.Size = new System.Drawing.Size(343, 446);
            this.ib1.TabIndex = 2;
            this.ib1.TabStop = false;
            // 
            // btnloadimg
            // 
            this.btnloadimg.Location = new System.Drawing.Point(388, 319);
            this.btnloadimg.Name = "btnloadimg";
            this.btnloadimg.Size = new System.Drawing.Size(128, 22);
            this.btnloadimg.TabIndex = 3;
            this.btnloadimg.Text = "Execute";
            this.btnloadimg.UseVisualStyleBackColor = true;
            this.btnloadimg.Click += new System.EventHandler(this.btnloadimg_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 481);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 557);
            this.progressBar1.Maximum = 64;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(520, 15);
            this.progressBar1.Step = 64;
            this.progressBar1.TabIndex = 5;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Chayut\\Dropbox\\Academic File 3.2\\Intern (img)\\Resource\\project 1 numbere" +
    "d img";
            // 
            // btnLibLoad
            // 
            this.btnLibLoad.Location = new System.Drawing.Point(388, 38);
            this.btnLibLoad.Name = "btnLibLoad";
            this.btnLibLoad.Size = new System.Drawing.Size(128, 23);
            this.btnLibLoad.TabIndex = 6;
            this.btnLibLoad.Text = "Load Image Library";
            this.btnLibLoad.UseVisualStyleBackColor = true;
            this.btnLibLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Multiplication factor";
            // 
            // tbMF
            // 
            this.tbMF.Location = new System.Drawing.Point(106, 17);
            this.tbMF.Name = "tbMF";
            this.tbMF.Size = new System.Drawing.Size(31, 20);
            this.tbMF.TabIndex = 8;
            this.tbMF.Text = "2";
            // 
            // tbOffset
            // 
            this.tbOffset.Location = new System.Drawing.Point(106, 42);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(31, 20);
            this.tbOffset.TabIndex = 10;
            this.tbOffset.Text = "-10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 534);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Library Path:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(80, 531);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(452, 20);
            this.tbPath.TabIndex = 12;
            // 
            // tbSourcefile
            // 
            this.tbSourcefile.Location = new System.Drawing.Point(80, 505);
            this.tbSourcefile.Name = "tbSourcefile";
            this.tbSourcefile.ReadOnly = true;
            this.tbSourcefile.Size = new System.Drawing.Size(452, 20);
            this.tbSourcefile.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Source Img:";
            // 
            // btnLoadSource
            // 
            this.btnLoadSource.Location = new System.Drawing.Point(388, 67);
            this.btnLoadSource.Name = "btnLoadSource";
            this.btnLoadSource.Size = new System.Drawing.Size(128, 23);
            this.btnLoadSource.TabIndex = 15;
            this.btnLoadSource.Text = "Load Source Image";
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
            this.label1.Location = new System.Drawing.Point(382, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Columns:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Rows:";
            // 
            // tbCellRow
            // 
            this.tbCellRow.Location = new System.Drawing.Point(485, 181);
            this.tbCellRow.Name = "tbCellRow";
            this.tbCellRow.Size = new System.Drawing.Size(31, 20);
            this.tbCellRow.TabIndex = 18;
            this.tbCellRow.Text = "64";
            // 
            // tbCellColumn
            // 
            this.tbCellColumn.Location = new System.Drawing.Point(485, 206);
            this.tbCellColumn.Name = "tbCellColumn";
            this.tbCellColumn.Size = new System.Drawing.Size(31, 20);
            this.tbCellColumn.TabIndex = 19;
            this.tbCellColumn.Text = "64";
            // 
            // tbLibWidth
            // 
            this.tbLibWidth.Location = new System.Drawing.Point(106, 50);
            this.tbLibWidth.Name = "tbLibWidth";
            this.tbLibWidth.Size = new System.Drawing.Size(31, 20);
            this.tbLibWidth.TabIndex = 23;
            this.tbLibWidth.Text = "81";
            // 
            // tbLibHeight
            // 
            this.tbLibHeight.Location = new System.Drawing.Point(106, 24);
            this.tbLibHeight.Name = "tbLibHeight";
            this.tbLibHeight.Size = new System.Drawing.Size(31, 20);
            this.tbLibHeight.TabIndex = 22;
            this.tbLibHeight.Text = "115";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Width:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Height:";
            // 
            // bgLibSize
            // 
            this.bgLibSize.Controls.Add(this.label7);
            this.bgLibSize.Controls.Add(this.tbLibWidth);
            this.bgLibSize.Controls.Add(this.label8);
            this.bgLibSize.Controls.Add(this.tbLibHeight);
            this.bgLibSize.Location = new System.Drawing.Point(379, 97);
            this.bgLibSize.Name = "bgLibSize";
            this.bgLibSize.Size = new System.Drawing.Size(153, 79);
            this.bgLibSize.TabIndex = 24;
            this.bgLibSize.TabStop = false;
            this.bgLibSize.Text = "Library Imgs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbMF);
            this.groupBox2.Controls.Add(this.tbOffset);
            this.groupBox2.Location = new System.Drawing.Point(379, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 70);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Perimeters";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 357);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Image ratio = 1:";
            // 
            // lblIMRation
            // 
            this.lblIMRation.AutoSize = true;
            this.lblIMRation.Location = new System.Drawing.Point(461, 357);
            this.lblIMRation.Name = "lblIMRation";
            this.lblIMRation.Size = new System.Drawing.Size(10, 13);
            this.lblIMRation.TabIndex = 27;
            this.lblIMRation.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 574);
            this.Controls.Add(this.lblIMRation);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bgLibSize);
            this.Controls.Add(this.tbCellColumn);
            this.Controls.Add(this.tbCellRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLoadSource);
            this.Controls.Add(this.tbSourcefile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLibLoad);
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
        private System.Windows.Forms.TextBox tbMF;
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
        private System.Windows.Forms.Label lblIMRation;
    }
}

