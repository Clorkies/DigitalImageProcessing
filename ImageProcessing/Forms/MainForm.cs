using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class MainForm : Form
    {
        private int index = 0;
        private bool isAdvancedFilter = false;
        private string currentAdvancedFilter = "";
        private bool cameraCaptureEnabled = false;
    
        private int collapsedWidth = 950;
        private int expandedWidth = 1300;

        public MainForm()
        {
            InitializeComponent();
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = false;
            button4.Visible = false;

            lbl_convertingImg.Visible = false;

            StartPosition = FormStartPosition.CenterScreen;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.rb_basicCopy.Checked = true;
            this.rb_histogram.Checked = false;
            this.rb_greyScale.Checked = false;
            this.rb_colorInvert.Checked = false;
            this.rb_sepia.Checked = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)      
        {
            if (isAdvancedFilter)
            {
                if (currentAdvancedFilter == "static")
                {
                    if (pictureBox1.Image != null && pictureBox2.Image != null)
                    {
                        pictureBox3.Image = BasicProcess.Subtract(
                            (Bitmap)pictureBox1.Image,
                            (Bitmap)pictureBox2.Image
                        );
                    }
                    else
                    {
                        MessageBox.Show("Please select both input images for subtraction.", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (currentAdvancedFilter == "webcam")
                {
                    MessageBox.Show("Webcam subtraction not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please select an input image first.", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lbl_convertingImg.Visible = true;
            pictureBox2.Image = null;
            lbl_convertingImg.Refresh(); 

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            switch (index)
            {
                case 0:
                    pictureBox2.Image = BasicProcess.Copy((Bitmap)pictureBox1.Image);
                    break;
                case 1:
                    pictureBox2.Image = BasicProcess.GreyScale((Bitmap)pictureBox1.Image);
                    break;
                case 2:
                    pictureBox2.Image = BasicProcess.Histogram((Bitmap)pictureBox1.Image);
                    break;
                case 3:
                    pictureBox2.Image = BasicProcess.InvertColor((Bitmap)pictureBox1.Image);
                    break;
                case 4:
                    pictureBox2.Image = BasicProcess.Sepia((Bitmap)pictureBox1.Image);
                    break;
                case 5:
                    ConvolutionMatrix.Smooth(bmp, 1);
                    pictureBox2.Image = bmp;
                    break;
                case 6:
                    ConvolutionMatrix.GaussianBlur(bmp, 4);
                    pictureBox2.Image = bmp;
                    break;
                case 7:
                    ConvolutionMatrix.Sharpen(bmp, 11);
                    pictureBox2.Image = bmp;
                    break;
                case 8:
                    ConvolutionMatrix.MeanRemoval(bmp, 9);
                    pictureBox2.Image = bmp;
                    break;
                case 9:
                    ConvolutionMatrix.EmbossLaplacian(bmp);
                    pictureBox2.Image = bmp;
                    break;
                case 10:
                    ConvolutionMatrix.EmbossLossy(bmp);
                    pictureBox2.Image = bmp;
                    break;
                case 11:
                    ConvolutionMatrix.EmbossVertical(bmp);
                    pictureBox2.Image = bmp;
                    break;
                case 12:
                    ConvolutionMatrix.EmbossHorizontal(bmp);
                    pictureBox2.Image = bmp;
                    break;
                case 13:
                    ConvolutionMatrix.EmbossAllDirections(bmp);
                    pictureBox2.Image = bmp;
                    break;
                case 14:
                    ConvolutionMatrix.EmbossHorzVertical(bmp);
                    pictureBox2.Image = bmp;
                    break;
                default:
                    pictureBox2.Image = pictureBox1.Image;
                    break;
            }

            lbl_convertingImg.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cameraCaptureEnabled)
            {
                using (CameraForm camForm = new CameraForm())
                {
                    camForm.ShowDialog();
                    if (camForm.CapturedImage != null)
                    {
                        pictureBox1.Image = camForm.CapturedImage;
                        button1.Visible = false;
                    }
                }
            }
            else
            {
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    ofile.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(ofile.FileName);
                        button1.Visible = false;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    ofile.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox2.Image = Image.FromFile(ofile.FileName);
                        button4.Visible = false;
                    }
                }
 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            label1.AutoSize = true;
            label1.Left = (ClientSize.Width - label1.Width) / 2;
            label1.Top = (ClientSize.Height - label1.Height) / 2;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            button1.Visible = true;
            label5.Text = "None";
            index = 0;
            ResetAdvancedFilterUI();
        }

        private void ResetAdvancedFilterUI()
        {
            Width = collapsedWidth;
            pictureBox3.Visible = false;
            button4.Visible = false;
            label5.Text = "None";
            isAdvancedFilter = false;
            currentAdvancedFilter = "";
            pictureBox3.Image = null;
            button1.Text = "Click to select an image";

            label1.Text = "Input image";
            label2.Text = "Output image";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rb_greyScale_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_greyScale.Checked)
            {
                UncheckAdvancedFilters();
                ResetAdvancedFilterUI();
                index = 1;
                label5.Text = "Greyscale";
            }
        }

        private void rb_histogram_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_histogram.Checked)
            {
                UncheckAdvancedFilters();
                ResetAdvancedFilterUI();
                index = 2;
                label5.Text = "Histogram";
            }
        }

        private void rb_sepia_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sepia.Checked)
            {
                UncheckAdvancedFilters();
                ResetAdvancedFilterUI();
                index = 4;
                label5.Text = "Sepia";
            }
        }

        private void rb_basicCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_basicCopy.Checked)
            {
                UncheckAdvancedFilters();
                ResetAdvancedFilterUI();
                index = 0;
                label5.Text = "Basic Copy";
            }
        }

        private void rb_colorInvert_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_colorInvert.Checked)
            {
                UncheckAdvancedFilters();
                ResetAdvancedFilterUI();
                index = 3;
                label5.Text = "Color Inversion";
            }
        }

        private void rb_subtraction_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            Width = expandedWidth;
            pictureBox3.Visible = true;
            button4.Visible = true;
            label5.Text = "Subtraction";
            isAdvancedFilter = true;
            currentAdvancedFilter = "static";
            label1.Text = "Foreground Image";
            label2.Text = "Background Image";
        }

        private void cb_toggleCamera_CheckedChanged(object sender, EventArgs e)
        {
            cameraCaptureEnabled = cb_toggleCamera.Checked;

            if (cameraCaptureEnabled)
            {
                cb_toggleCamera.Text = "Camera Capture: On";
                cb_toggleCamera.BackColor = Color.LightGreen;
                MessageBox.Show(
                    "If camera preview is not showing anything, download and use ManyCam (https://manycam.com/) as your camera device.",
                    "Camera Preview Help",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                cb_toggleCamera.BackColor = Color.LightGreen;
            }
            else
            {
                cb_toggleCamera.Text = "Camera Capture: Off";
                cb_toggleCamera.BackColor = Color.White;
            }

        }

        // Advanced Filters

        private void rb_smooth_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_smooth.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 5;
                label5.Text = "Smoother";
            }
        }

        private void rb_gaussBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_gaussBlur.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 6;
                label5.Text = "Gaussian Blur";
            }
        }

        private void rb_sharpen_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sharpen.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 7;
                label5.Text = "Sharpen";
            }
        }

        private void rb_meanRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_meanRemoval.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 8;
                label5.Text = "Mean Removal";
            }
        }


        ///////////
        //Emboss Variants
        ///////////

        private void rb_emboss_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_embossLap.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 9;
                label5.Text = "Emboss Laplacian";
            }
        }

        private void rb_embossLossy_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_embossLossy.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 10;
                label5.Text = "Emboss Lossy";
            }
        }

        private void rb_embossVert_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_embossVert.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 11;
                label5.Text = "Emboss Vertical";
            }
        }

        private void rb_embossHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_embossHorizontal.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 12;
                label5.Text = "Emboss Horizontal";
            }
        }

        private void rb_embossAllDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_embossAllDir.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 13;
                label5.Text = "Emboss All Directions";
            }
        }

        private void rb_embossHVert_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_embossHVert.Checked)
            {
                UncheckBasicFilters();
                ResetAdvancedFilterUI();
                index = 14;
                label5.Text = "Emboss HorzVert";
            }
        }

        private void UncheckBasicFilters()
        {
            rb_basicCopy.Checked = false;
            rb_greyScale.Checked = false;
            rb_histogram.Checked = false;
            rb_colorInvert.Checked = false;
            rb_sepia.Checked = false;
        }

        private void UncheckAdvancedFilters()
        {
            rb_smooth.Checked = false;
            rb_gaussBlur.Checked = false;
            rb_sharpen.Checked = false;
            rb_meanRemoval.Checked = false;
            rb_embossLap.Checked = false;
            rb_embossLossy.Checked = false;
            rb_embossVert.Checked = false;
            rb_embossHorizontal.Checked = false;
            rb_embossAllDir.Checked = false;
            rb_embossHVert.Checked = false;
        }

        private void lbl_convertingImg_Click(object sender, EventArgs e)
        {

        }
    }
}
