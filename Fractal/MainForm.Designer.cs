namespace Fractal
{
    partial class Fractal
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
            this.nudDetail = new System.Windows.Forms.NumericUpDown();
            this.butStart = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.radStandard = new System.Windows.Forms.RadioButton();
            this.radInvert = new System.Windows.Forms.RadioButton();
            this.labLevels = new System.Windows.Forms.Label();
            this.radDouble = new System.Windows.Forms.RadioButton();
            this.radTriple = new System.Windows.Forms.RadioButton();
            this.radSolid = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // nudDetail
            // 
            this.nudDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudDetail.Location = new System.Drawing.Point(59, 333);
            this.nudDetail.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudDetail.Name = "nudDetail";
            this.nudDetail.Size = new System.Drawing.Size(66, 20);
            this.nudDetail.TabIndex = 1;
            // 
            // butStart
            // 
            this.butStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butStart.Location = new System.Drawing.Point(524, 330);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 2;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // butStop
            // 
            this.butStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butStop.Enabled = false;
            this.butStop.Location = new System.Drawing.Point(605, 330);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(75, 23);
            this.butStop.TabIndex = 3;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            this.butStop.EnabledChanged += new System.EventHandler(this.butStop_EnabledChanged);
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(668, 312);
            this.picImage.TabIndex = 6;
            this.picImage.TabStop = false;
            this.picImage.Paint += new System.Windows.Forms.PaintEventHandler(this.picImage_Paint);
            // 
            // radStandard
            // 
            this.radStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radStandard.AutoSize = true;
            this.radStandard.Checked = true;
            this.radStandard.Location = new System.Drawing.Point(151, 335);
            this.radStandard.Name = "radStandard";
            this.radStandard.Size = new System.Drawing.Size(68, 17);
            this.radStandard.TabIndex = 7;
            this.radStandard.TabStop = true;
            this.radStandard.Text = "Standard";
            this.radStandard.UseVisualStyleBackColor = true;
            // 
            // radInvert
            // 
            this.radInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radInvert.AutoSize = true;
            this.radInvert.Location = new System.Drawing.Point(225, 335);
            this.radInvert.Name = "radInvert";
            this.radInvert.Size = new System.Drawing.Size(52, 17);
            this.radInvert.TabIndex = 8;
            this.radInvert.Text = "Invert";
            this.radInvert.UseVisualStyleBackColor = true;
            // 
            // labLevels
            // 
            this.labLevels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labLevels.AutoSize = true;
            this.labLevels.Location = new System.Drawing.Point(12, 335);
            this.labLevels.Name = "labLevels";
            this.labLevels.Size = new System.Drawing.Size(41, 13);
            this.labLevels.TabIndex = 9;
            this.labLevels.Text = "Levels:";
            // 
            // radDouble
            // 
            this.radDouble.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radDouble.AutoSize = true;
            this.radDouble.Location = new System.Drawing.Point(283, 335);
            this.radDouble.Name = "radDouble";
            this.radDouble.Size = new System.Drawing.Size(59, 17);
            this.radDouble.TabIndex = 10;
            this.radDouble.TabStop = true;
            this.radDouble.Text = "Double";
            this.radDouble.UseVisualStyleBackColor = true;
            // 
            // radTriple
            // 
            this.radTriple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radTriple.AutoSize = true;
            this.radTriple.Location = new System.Drawing.Point(349, 335);
            this.radTriple.Name = "radTriple";
            this.radTriple.Size = new System.Drawing.Size(51, 17);
            this.radTriple.TabIndex = 11;
            this.radTriple.TabStop = true;
            this.radTriple.Text = "Triple";
            this.radTriple.UseVisualStyleBackColor = true;
            // 
            // radSolid
            // 
            this.radSolid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radSolid.AutoSize = true;
            this.radSolid.Location = new System.Drawing.Point(407, 335);
            this.radSolid.Name = "radSolid";
            this.radSolid.Size = new System.Drawing.Size(48, 17);
            this.radSolid.TabIndex = 12;
            this.radSolid.TabStop = true;
            this.radSolid.Text = "Solid";
            this.radSolid.UseVisualStyleBackColor = true;
            // 
            // Fractal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 366);
            this.Controls.Add(this.radSolid);
            this.Controls.Add(this.radTriple);
            this.Controls.Add(this.radDouble);
            this.Controls.Add(this.labLevels);
            this.Controls.Add(this.radInvert);
            this.Controls.Add(this.radStandard);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.nudDetail);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "Fractal";
            this.Text = "Fractal";
            this.Load += new System.EventHandler(this.Fractal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudDetail;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.RadioButton radStandard;
        private System.Windows.Forms.RadioButton radInvert;
        private System.Windows.Forms.Label labLevels;
        private System.Windows.Forms.RadioButton radDouble;
        private System.Windows.Forms.RadioButton radTriple;
        private System.Windows.Forms.RadioButton radSolid;
    }
}

