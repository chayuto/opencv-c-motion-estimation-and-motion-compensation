namespace _131125___Blk_Matching
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackbarSearchRange = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboboxLeft = new System.Windows.Forms.ComboBox();
            this.comboBoxRight = new System.Windows.Forms.ComboBox();
            this.comboBoxSequence = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnPrevious1 = new System.Windows.Forms.Button();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.trackBarBlkSize = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarFrameNo = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConExe = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSearchRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlkSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrameNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(12, 39);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(479, 325);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(397, 414);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(177, 44);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Exexute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox2.Location = new System.Drawing.Point(505, 39);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(468, 325);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Block Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search Range:";
            // 
            // trackbarSearchRange
            // 
            this.trackbarSearchRange.LargeChange = 1;
            this.trackbarSearchRange.Location = new System.Drawing.Point(287, 460);
            this.trackbarSearchRange.Maximum = 13;
            this.trackbarSearchRange.Minimum = 1;
            this.trackbarSearchRange.Name = "trackbarSearchRange";
            this.trackbarSearchRange.Size = new System.Drawing.Size(104, 45);
            this.trackbarSearchRange.TabIndex = 1;
            this.trackbarSearchRange.Tag = "";
            this.trackbarSearchRange.Value = 7;
            this.trackbarSearchRange.Scroll += new System.EventHandler(this.trackbarSearchRange_Scroll);
            // 
            // comboboxLeft
            // 
            this.comboboxLeft.Enabled = false;
            this.comboboxLeft.Items.AddRange(new object[] {
            "Frame N-1",
            "Frame N",
            "Frame N+1"});
            this.comboboxLeft.Location = new System.Drawing.Point(12, 12);
            this.comboboxLeft.Name = "comboboxLeft";
            this.comboboxLeft.Size = new System.Drawing.Size(479, 21);
            this.comboboxLeft.TabIndex = 11;
            this.comboboxLeft.SelectedIndexChanged += new System.EventHandler(this.comboboxLeft_SelectedIndexChanged);
            // 
            // comboBoxRight
            // 
            this.comboBoxRight.Enabled = false;
            this.comboBoxRight.Items.AddRange(new object[] {
            "Block Matching",
            "Displaced Frame",
            "Sub-Pix Displaced Frame",
            "Interpolated Displace Frame",
            "Sub-Pix Inter Displaced Frame",
            "Frame Difference",
            "Displaced Frame Difference",
            "Sub-Pix Displaced Frame Difference",
            "Interpolated Frame Difference",
            "Sub-Pix Inter Frame Difference"});
            this.comboBoxRight.Location = new System.Drawing.Point(505, 12);
            this.comboBoxRight.Name = "comboBoxRight";
            this.comboBoxRight.Size = new System.Drawing.Size(468, 21);
            this.comboBoxRight.TabIndex = 12;
            this.comboBoxRight.SelectedIndexChanged += new System.EventHandler(this.comboBoxRight_SelectedIndexChanged);
            // 
            // comboBoxSequence
            // 
            this.comboBoxSequence.FormattingEnabled = true;
            this.comboBoxSequence.Items.AddRange(new object[] {
            "Foreman",
            "Waterfall",
            "Stefan"});
            this.comboBoxSequence.Location = new System.Drawing.Point(12, 418);
            this.comboBoxSequence.Name = "comboBoxSequence";
            this.comboBoxSequence.Size = new System.Drawing.Size(136, 21);
            this.comboBoxSequence.TabIndex = 13;
            this.comboBoxSequence.SelectedIndexChanged += new System.EventHandler(this.comboBoxSequence_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Sequence:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(1098, 230);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(67, 23);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(929, 367);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(879, 367);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(44, 23);
            this.btnPrevious.TabIndex = 17;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnPrevious1
            // 
            this.btnPrevious1.Location = new System.Drawing.Point(397, 370);
            this.btnPrevious1.Name = "btnPrevious1";
            this.btnPrevious1.Size = new System.Drawing.Size(44, 23);
            this.btnPrevious1.TabIndex = 19;
            this.btnPrevious1.Text = "<";
            this.btnPrevious1.UseVisualStyleBackColor = true;
            this.btnPrevious1.Click += new System.EventHandler(this.btnPrevious1_Click);
            // 
            // btnNext1
            // 
            this.btnNext1.Location = new System.Drawing.Point(447, 370);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(44, 23);
            this.btnNext1.TabIndex = 18;
            this.btnNext1.Text = ">";
            this.btnNext1.UseVisualStyleBackColor = true;
            this.btnNext1.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackBarBlkSize
            // 
            this.trackBarBlkSize.LargeChange = 1;
            this.trackBarBlkSize.Location = new System.Drawing.Point(287, 409);
            this.trackBarBlkSize.Maximum = 3;
            this.trackBarBlkSize.Minimum = 1;
            this.trackBarBlkSize.Name = "trackBarBlkSize";
            this.trackBarBlkSize.Size = new System.Drawing.Size(104, 45);
            this.trackBarBlkSize.TabIndex = 20;
            this.trackBarBlkSize.Value = 2;
            this.trackBarBlkSize.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "16";
            // 
            // trackBarFrameNo
            // 
            this.trackBarFrameNo.Location = new System.Drawing.Point(12, 460);
            this.trackBarFrameNo.Maximum = 88;
            this.trackBarFrameNo.Minimum = 2;
            this.trackBarFrameNo.Name = "trackBarFrameNo";
            this.trackBarFrameNo.Size = new System.Drawing.Size(171, 45);
            this.trackBarFrameNo.TabIndex = 24;
            this.trackBarFrameNo.TickFrequency = 10;
            this.trackBarFrameNo.Value = 2;
            this.trackBarFrameNo.Scroll += new System.EventHandler(this.trackBarFrameNo_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 445);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Frame No:";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Window;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(979, 262);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "MSE";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(186, 198);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "MSE Chart";
            this.chart1.Titles.Add(title1);
            // 
            // btnConExe
            // 
            this.btnConExe.Location = new System.Drawing.Point(594, 414);
            this.btnConExe.Name = "btnConExe";
            this.btnConExe.Size = new System.Drawing.Size(176, 44);
            this.btnConExe.TabIndex = 27;
            this.btnConExe.Text = "Continuous Execute";
            this.btnConExe.UseVisualStyleBackColor = true;
            this.btnConExe.Click += new System.EventHandler(this.btnConExe_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(979, 12);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(186, 212);
            this.tbLog.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 506);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnConExe);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackBarFrameNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBarBlkSize);
            this.Controls.Add(this.btnPrevious1);
            this.Controls.Add(this.btnNext1);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSequence);
            this.Controls.Add(this.comboBoxRight);
            this.Controls.Add(this.comboboxLeft);
            this.Controls.Add(this.trackbarSearchRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.imageBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Motion Estimation & Motion Compensation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSearchRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlkSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrameNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btnExecute;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackbarSearchRange;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboboxLeft;
        private System.Windows.Forms.ComboBox comboBoxRight;
        private System.Windows.Forms.ComboBox comboBoxSequence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnPrevious1;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.TrackBar trackBarBlkSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarFrameNo;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnConExe;
        private System.Windows.Forms.TextBox tbLog;
    }
}

