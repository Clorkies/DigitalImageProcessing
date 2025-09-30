namespace ImageProcessing
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rb_embossHVert = new System.Windows.Forms.RadioButton();
            this.rb_embossAllDir = new System.Windows.Forms.RadioButton();
            this.rb_embossHorizontal = new System.Windows.Forms.RadioButton();
            this.rb_embossVert = new System.Windows.Forms.RadioButton();
            this.rb_embossLossy = new System.Windows.Forms.RadioButton();
            this.rb_meanRemoval = new System.Windows.Forms.RadioButton();
            this.rb_embossLap = new System.Windows.Forms.RadioButton();
            this.rb_sharpen = new System.Windows.Forms.RadioButton();
            this.rb_gaussBlur = new System.Windows.Forms.RadioButton();
            this.rb_smooth = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_subtraction = new System.Windows.Forms.RadioButton();
            this.cb_toggleCamera = new System.Windows.Forms.CheckBox();
            this.rb_sepia = new System.Windows.Forms.RadioButton();
            this.rb_greyScale = new System.Windows.Forms.RadioButton();
            this.rb_histogram = new System.Windows.Forms.RadioButton();
            this.rb_colorInvert = new System.Windows.Forms.RadioButton();
            this.rb_basicCopy = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_convertingImg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(227, 89);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(315, 304);
            this.button1.TabIndex = 4;
            this.button1.Text = "Click to select an image";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button2.Font = new System.Drawing.Font("Product Sans Black", 10.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(18, 484);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans", 10.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(332, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Input image";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(692, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output image";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Product Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(223, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Filter:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Product Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "None";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Font = new System.Drawing.Font("Product Sans Black", 10.25F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(18, 446);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 34);
            this.button3.TabIndex = 12;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(591, 89);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(315, 304);
            this.button4.TabIndex = 14;
            this.button4.Text = "Click to select background image";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Product Sans", 10.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1033, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Output image";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rb_subtraction);
            this.panel1.Controls.Add(this.cb_toggleCamera);
            this.panel1.Controls.Add(this.rb_sepia);
            this.panel1.Controls.Add(this.rb_greyScale);
            this.panel1.Controls.Add(this.rb_histogram);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.rb_colorInvert);
            this.panel1.Controls.Add(this.rb_basicCopy);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 533);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rb_embossHVert);
            this.panel2.Controls.Add(this.rb_embossAllDir);
            this.panel2.Controls.Add(this.rb_embossHorizontal);
            this.panel2.Controls.Add(this.rb_embossVert);
            this.panel2.Controls.Add(this.rb_embossLossy);
            this.panel2.Controls.Add(this.rb_meanRemoval);
            this.panel2.Controls.Add(this.rb_embossLap);
            this.panel2.Controls.Add(this.rb_sharpen);
            this.panel2.Controls.Add(this.rb_gaussBlur);
            this.panel2.Controls.Add(this.rb_smooth);
            this.panel2.Location = new System.Drawing.Point(14, 172);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(152, 162);
            this.panel2.TabIndex = 24;
            // 
            // rb_embossHVert
            // 
            this.rb_embossHVert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_embossHVert.Location = new System.Drawing.Point(9, 219);
            this.rb_embossHVert.Name = "rb_embossHVert";
            this.rb_embossHVert.Size = new System.Drawing.Size(118, 26);
            this.rb_embossHVert.TabIndex = 30;
            this.rb_embossHVert.Text = "Emboss HorzVert";
            this.rb_embossHVert.UseVisualStyleBackColor = false;
            this.rb_embossHVert.CheckedChanged += new System.EventHandler(this.rb_embossHVert_CheckedChanged);
            // 
            // rb_embossAllDir
            // 
            this.rb_embossAllDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_embossAllDir.Location = new System.Drawing.Point(9, 196);
            this.rb_embossAllDir.Name = "rb_embossAllDir";
            this.rb_embossAllDir.Size = new System.Drawing.Size(118, 24);
            this.rb_embossAllDir.TabIndex = 29;
            this.rb_embossAllDir.Text = "Emboss All Dir.";
            this.rb_embossAllDir.UseVisualStyleBackColor = false;
            this.rb_embossAllDir.CheckedChanged += new System.EventHandler(this.rb_embossAllDir_CheckedChanged);
            // 
            // rb_embossHorizontal
            // 
            this.rb_embossHorizontal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_embossHorizontal.Location = new System.Drawing.Point(9, 172);
            this.rb_embossHorizontal.Name = "rb_embossHorizontal";
            this.rb_embossHorizontal.Size = new System.Drawing.Size(118, 24);
            this.rb_embossHorizontal.TabIndex = 28;
            this.rb_embossHorizontal.Text = "Emboss Horizontal";
            this.rb_embossHorizontal.UseVisualStyleBackColor = false;
            this.rb_embossHorizontal.CheckedChanged += new System.EventHandler(this.rb_embossHorizontal_CheckedChanged);
            // 
            // rb_embossVert
            // 
            this.rb_embossVert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_embossVert.Location = new System.Drawing.Point(9, 147);
            this.rb_embossVert.Name = "rb_embossVert";
            this.rb_embossVert.Size = new System.Drawing.Size(118, 24);
            this.rb_embossVert.TabIndex = 26;
            this.rb_embossVert.Text = "Emboss Vertical";
            this.rb_embossVert.UseVisualStyleBackColor = false;
            this.rb_embossVert.CheckedChanged += new System.EventHandler(this.rb_embossVert_CheckedChanged);
            // 
            // rb_embossLossy
            // 
            this.rb_embossLossy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_embossLossy.Location = new System.Drawing.Point(8, 122);
            this.rb_embossLossy.Name = "rb_embossLossy";
            this.rb_embossLossy.Size = new System.Drawing.Size(118, 24);
            this.rb_embossLossy.TabIndex = 25;
            this.rb_embossLossy.Text = "Emboss Lossy";
            this.rb_embossLossy.UseVisualStyleBackColor = false;
            this.rb_embossLossy.CheckedChanged += new System.EventHandler(this.rb_embossLossy_CheckedChanged);
            // 
            // rb_meanRemoval
            // 
            this.rb_meanRemoval.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_meanRemoval.Location = new System.Drawing.Point(8, 73);
            this.rb_meanRemoval.Name = "rb_meanRemoval";
            this.rb_meanRemoval.Size = new System.Drawing.Size(104, 24);
            this.rb_meanRemoval.TabIndex = 24;
            this.rb_meanRemoval.Text = "Mean Removal";
            this.rb_meanRemoval.UseVisualStyleBackColor = false;
            this.rb_meanRemoval.CheckedChanged += new System.EventHandler(this.rb_meanRemoval_CheckedChanged);
            // 
            // rb_embossLap
            // 
            this.rb_embossLap.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_embossLap.Location = new System.Drawing.Point(8, 97);
            this.rb_embossLap.Name = "rb_embossLap";
            this.rb_embossLap.Size = new System.Drawing.Size(118, 24);
            this.rb_embossLap.TabIndex = 22;
            this.rb_embossLap.Text = "Emboss Laplacian";
            this.rb_embossLap.UseVisualStyleBackColor = false;
            this.rb_embossLap.CheckedChanged += new System.EventHandler(this.rb_emboss_CheckedChanged);
            // 
            // rb_sharpen
            // 
            this.rb_sharpen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_sharpen.Location = new System.Drawing.Point(8, 50);
            this.rb_sharpen.Name = "rb_sharpen";
            this.rb_sharpen.Size = new System.Drawing.Size(104, 24);
            this.rb_sharpen.TabIndex = 21;
            this.rb_sharpen.Text = "Sharpen";
            this.rb_sharpen.UseVisualStyleBackColor = false;
            this.rb_sharpen.CheckedChanged += new System.EventHandler(this.rb_sharpen_CheckedChanged);
            // 
            // rb_gaussBlur
            // 
            this.rb_gaussBlur.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_gaussBlur.Location = new System.Drawing.Point(8, 28);
            this.rb_gaussBlur.Name = "rb_gaussBlur";
            this.rb_gaussBlur.Size = new System.Drawing.Size(104, 24);
            this.rb_gaussBlur.TabIndex = 20;
            this.rb_gaussBlur.Text = "Gaussian Blur";
            this.rb_gaussBlur.UseVisualStyleBackColor = false;
            this.rb_gaussBlur.CheckedChanged += new System.EventHandler(this.rb_gaussBlur_CheckedChanged);
            // 
            // rb_smooth
            // 
            this.rb_smooth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rb_smooth.Location = new System.Drawing.Point(8, 6);
            this.rb_smooth.Name = "rb_smooth";
            this.rb_smooth.Size = new System.Drawing.Size(104, 24);
            this.rb_smooth.TabIndex = 19;
            this.rb_smooth.Text = "Smoothen";
            this.rb_smooth.UseVisualStyleBackColor = false;
            this.rb_smooth.CheckedChanged += new System.EventHandler(this.rb_smooth_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(17, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Advanced filters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Others";
            // 
            // rb_subtraction
            // 
            this.rb_subtraction.Location = new System.Drawing.Point(18, 368);
            this.rb_subtraction.Name = "rb_subtraction";
            this.rb_subtraction.Size = new System.Drawing.Size(104, 24);
            this.rb_subtraction.TabIndex = 0;
            this.rb_subtraction.Text = "Subtraction";
            this.rb_subtraction.CheckedChanged += new System.EventHandler(this.rb_subtraction_CheckedChanged);
            // 
            // cb_toggleCamera
            // 
            this.cb_toggleCamera.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_toggleCamera.BackColor = System.Drawing.Color.White;
            this.cb_toggleCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_toggleCamera.Location = new System.Drawing.Point(18, 410);
            this.cb_toggleCamera.Name = "cb_toggleCamera";
            this.cb_toggleCamera.Size = new System.Drawing.Size(151, 31);
            this.cb_toggleCamera.TabIndex = 15;
            this.cb_toggleCamera.Text = "Camera Capture: Off";
            this.cb_toggleCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_toggleCamera.UseVisualStyleBackColor = false;
            this.cb_toggleCamera.CheckedChanged += new System.EventHandler(this.cb_toggleCamera_CheckedChanged);
            // 
            // rb_sepia
            // 
            this.rb_sepia.AccessibleDescription = "rb_sepia";
            this.rb_sepia.AutoSize = true;
            this.rb_sepia.Location = new System.Drawing.Point(20, 125);
            this.rb_sepia.Name = "rb_sepia";
            this.rb_sepia.Size = new System.Drawing.Size(52, 17);
            this.rb_sepia.TabIndex = 13;
            this.rb_sepia.TabStop = true;
            this.rb_sepia.Text = "Sepia";
            this.rb_sepia.UseVisualStyleBackColor = true;
            this.rb_sepia.CheckedChanged += new System.EventHandler(this.rb_sepia_CheckedChanged);
            // 
            // rb_greyScale
            // 
            this.rb_greyScale.AutoSize = true;
            this.rb_greyScale.Location = new System.Drawing.Point(20, 102);
            this.rb_greyScale.Name = "rb_greyScale";
            this.rb_greyScale.Size = new System.Drawing.Size(72, 17);
            this.rb_greyScale.TabIndex = 12;
            this.rb_greyScale.TabStop = true;
            this.rb_greyScale.Text = "Grayscale";
            this.rb_greyScale.UseVisualStyleBackColor = true;
            this.rb_greyScale.CheckedChanged += new System.EventHandler(this.rb_greyScale_CheckedChanged);
            // 
            // rb_histogram
            // 
            this.rb_histogram.AutoSize = true;
            this.rb_histogram.Location = new System.Drawing.Point(20, 79);
            this.rb_histogram.Name = "rb_histogram";
            this.rb_histogram.Size = new System.Drawing.Size(72, 17);
            this.rb_histogram.TabIndex = 11;
            this.rb_histogram.TabStop = true;
            this.rb_histogram.Text = "Histogram";
            this.rb_histogram.UseVisualStyleBackColor = true;
            this.rb_histogram.CheckedChanged += new System.EventHandler(this.rb_histogram_CheckedChanged);
            // 
            // rb_colorInvert
            // 
            this.rb_colorInvert.Location = new System.Drawing.Point(20, 53);
            this.rb_colorInvert.Name = "rb_colorInvert";
            this.rb_colorInvert.Size = new System.Drawing.Size(104, 24);
            this.rb_colorInvert.TabIndex = 17;
            this.rb_colorInvert.Text = "Color Invert";
            this.rb_colorInvert.CheckedChanged += new System.EventHandler(this.rb_colorInvert_CheckedChanged);
            // 
            // rb_basicCopy
            // 
            this.rb_basicCopy.Location = new System.Drawing.Point(19, 31);
            this.rb_basicCopy.Name = "rb_basicCopy";
            this.rb_basicCopy.Size = new System.Drawing.Size(104, 24);
            this.rb_basicCopy.TabIndex = 17;
            this.rb_basicCopy.Text = "Basic Copy";
            this.rb_basicCopy.CheckedChanged += new System.EventHandler(this.rb_basicCopy_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(17, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Basic filters";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(937, 88);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(317, 306);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(589, 88);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(317, 306);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(226, 88);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 306);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_convertingImg
            // 
            this.lbl_convertingImg.AutoSize = true;
            this.lbl_convertingImg.Font = new System.Drawing.Font("Product Sans Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_convertingImg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_convertingImg.Location = new System.Drawing.Point(624, 219);
            this.lbl_convertingImg.Name = "lbl_convertingImg";
            this.lbl_convertingImg.Size = new System.Drawing.Size(244, 30);
            this.lbl_convertingImg.TabIndex = 17;
            this.lbl_convertingImg.Text = "Converting image...";
            this.lbl_convertingImg.Click += new System.EventHandler(this.lbl_convertingImg_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 534);
            this.Controls.Add(this.lbl_convertingImg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Picasso";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rb_basicCopy;
        private System.Windows.Forms.RadioButton rb_histogram;
        private System.Windows.Forms.RadioButton rb_colorInvert;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rb_sepia;
        private System.Windows.Forms.RadioButton rb_greyScale;
        private System.Windows.Forms.RadioButton rb_subtraction;
        private System.Windows.Forms.CheckBox cb_toggleCamera;
        private System.Windows.Forms.RadioButton rb_sharpen;
        private System.Windows.Forms.RadioButton rb_gaussBlur;
        private System.Windows.Forms.RadioButton rb_smooth;
        private System.Windows.Forms.RadioButton rb_embossLap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rb_meanRemoval;
        private System.Windows.Forms.RadioButton rb_embossAllDir;
        private System.Windows.Forms.RadioButton rb_embossHorizontal;
        private System.Windows.Forms.RadioButton rb_embossVert;
        private System.Windows.Forms.RadioButton rb_embossLossy;
        private System.Windows.Forms.RadioButton rb_embossHVert;
        private System.Windows.Forms.Label lbl_convertingImg;
    }
}

