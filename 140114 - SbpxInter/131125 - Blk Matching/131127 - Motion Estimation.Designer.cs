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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackbarSearchRange = new System.Windows.Forms.TrackBar();
            this.tbBlkSize = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboboxLeft = new System.Windows.Forms.ComboBox();
            this.comboBoxRight = new System.Windows.Forms.ComboBox();
            this.comboBoxSequence = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSearchRange)).BeginInit();
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
            this.btnExecute.Location = new System.Drawing.Point(423, 387);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(195, 43);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Exexute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(646, 372);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(145, 69);
            this.listBox1.TabIndex = 4;
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
            this.label1.Location = new System.Drawing.Point(203, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Block Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search Range:";
            // 
            // trackbarSearchRange
            // 
            this.trackbarSearchRange.LargeChange = 1;
            this.trackbarSearchRange.Location = new System.Drawing.Point(288, 400);
            this.trackbarSearchRange.Maximum = 13;
            this.trackbarSearchRange.Minimum = 1;
            this.trackbarSearchRange.Name = "trackbarSearchRange";
            this.trackbarSearchRange.Size = new System.Drawing.Size(104, 45);
            this.trackbarSearchRange.TabIndex = 1;
            this.trackbarSearchRange.Tag = "";
            this.trackbarSearchRange.Value = 7;
            this.trackbarSearchRange.Scroll += new System.EventHandler(this.trackbarSearchRange_Scroll);
            // 
            // tbBlkSize
            // 
            this.tbBlkSize.Location = new System.Drawing.Point(288, 374);
            this.tbBlkSize.Name = "tbBlkSize";
            this.tbBlkSize.Size = new System.Drawing.Size(31, 20);
            this.tbBlkSize.TabIndex = 10;
            this.tbBlkSize.Text = "8";
            // 
            // comboboxLeft
            // 
            this.comboboxLeft.Enabled = false;
            this.comboboxLeft.Items.AddRange(new object[] {
            "Frame N-1",
            "Frame N"});
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
            "Frame Difference",
            "Block Matching",
            "Displaced Frame",
            "Displaced Frame Difference"});
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
            this.comboBoxSequence.Location = new System.Drawing.Point(12, 387);
            this.comboBoxSequence.Name = "comboBoxSequence";
            this.comboBoxSequence.Size = new System.Drawing.Size(136, 21);
            this.comboBoxSequence.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Sequence:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(797, 418);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(67, 23);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 453);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSequence);
            this.Controls.Add(this.comboBoxRight);
            this.Controls.Add(this.comboboxLeft);
            this.Controls.Add(this.tbBlkSize);
            this.Controls.Add(this.trackbarSearchRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.imageBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Block Matching";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSearchRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ListBox listBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackbarSearchRange;
        private System.Windows.Forms.TextBox tbBlkSize;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboboxLeft;
        private System.Windows.Forms.ComboBox comboBoxRight;
        private System.Windows.Forms.ComboBox comboBoxSequence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearLog;
    }
}

