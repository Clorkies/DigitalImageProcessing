namespace ImageProcessing
{
    partial class CameraForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Button buttonCapture;

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
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.buttonCapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCamera.Location = new System.Drawing.Point(9, 10);
            this.pictureBoxCamera.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(282, 271);
            this.pictureBoxCamera.TabIndex = 0;
            this.pictureBoxCamera.TabStop = false;
            this.pictureBoxCamera.Click += new System.EventHandler(this.pictureBoxCamera_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonCapture.Location = new System.Drawing.Point(91, 295);
            this.buttonCapture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(111, 44);
            this.buttonCapture.TabIndex = 1;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = false;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 350);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.pictureBoxCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CameraForm";
            this.Text = "Camera Capture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraForm_FormClosing);
            this.Load += new System.EventHandler(this.CameraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}