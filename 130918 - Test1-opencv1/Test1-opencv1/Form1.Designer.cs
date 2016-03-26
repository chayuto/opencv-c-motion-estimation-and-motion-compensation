namespace Test1_opencv1
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
            this.imageBoxOriginal = new Emgu.CV.UI.ImageBox();
            this.btnresume = new System.Windows.Forms.Button();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.imageBoxProcessed = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxProcessed)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxOriginal
            // 
            this.imageBoxOriginal.Location = new System.Drawing.Point(12, 12);
            this.imageBoxOriginal.Name = "imageBoxOriginal";
            this.imageBoxOriginal.Size = new System.Drawing.Size(680, 480);
            this.imageBoxOriginal.TabIndex = 2;
            this.imageBoxOriginal.TabStop = false;
            // 
            // btnresume
            // 
            this.btnresume.Location = new System.Drawing.Point(52, 510);
            this.btnresume.Name = "btnresume";
            this.btnresume.Size = new System.Drawing.Size(157, 26);
            this.btnresume.TabIndex = 3;
            this.btnresume.Text = "start";
            this.btnresume.UseVisualStyleBackColor = true;
            this.btnresume.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtXY
            // 
            this.txtXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtXY.Location = new System.Drawing.Point(241, 498);
            this.txtXY.Multiline = true;
            this.txtXY.Name = "txtXY";
            this.txtXY.ReadOnly = true;
            this.txtXY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXY.Size = new System.Drawing.Size(573, 68);
            this.txtXY.TabIndex = 4;
            // 
            // imageBoxProcessed
            // 
            this.imageBoxProcessed.Location = new System.Drawing.Point(698, 12);
            this.imageBoxProcessed.Name = "imageBoxProcessed";
            this.imageBoxProcessed.Size = new System.Drawing.Size(680, 480);
            this.imageBoxProcessed.TabIndex = 2;
            this.imageBoxProcessed.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 578);
            this.Controls.Add(this.imageBoxProcessed);
            this.Controls.Add(this.txtXY);
            this.Controls.Add(this.btnresume);
            this.Controls.Add(this.imageBoxOriginal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxProcessed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxOriginal;
        private System.Windows.Forms.Button btnresume;
        private System.Windows.Forms.TextBox txtXY;
        private Emgu.CV.UI.ImageBox imageBoxProcessed;
    }
}

