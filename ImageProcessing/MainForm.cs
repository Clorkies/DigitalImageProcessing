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
        int index;
        private bool isAdvancedFilter = false;
        private string currentAdvancedFilter = "";
        private bool cameraCaptureEnabled = false;

        public MainForm()
        {
            InitializeComponent();
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = false;
            button4.Visible = false;
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                        pictureBox3.Image = Processes.Subtract(
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

            switch (index)
            {
                case 0:
                    pictureBox2.Image = Processes.Copy((Bitmap)pictureBox1.Image);
                    break;
                case 1:
                    pictureBox2.Image = Processes.GreyScale((Bitmap)pictureBox1.Image);
                    break;
                case 2:
                    pictureBox2.Image = Processes.Histogram((Bitmap)pictureBox1.Image);
                    break;
                case 3:
                    pictureBox2.Image = Processes.InvertColor((Bitmap)pictureBox1.Image);
                    break;
                case 4:
                    pictureBox2.Image = Processes.Sepia((Bitmap)pictureBox1.Image);
                    break;
                default:
                    pictureBox2.Image = pictureBox1.Image;
                    break;
            }
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

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAdvancedFilterUI();
            index = 0;
            label5.Text = "Basic Copy";
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAdvancedFilterUI();
            index = 1;
            label5.Text = "Greyscale";
        }
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAdvancedFilterUI();
            index = 2;
            label5.Text = "Histogram";
        }

        private void colorInvertionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAdvancedFilterUI();
            index = 3;
            label5.Text = "Color Inversion";
        }

        private void sepiaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ResetAdvancedFilterUI();
            index = 4;
            label5.Text = "Sepia";
        }

        private void advancedFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void subtractionStaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = 1200;
            pictureBox3.Visible = true;
            button4.Visible = true;
            label5.Text = "Subtraction (Static)";
            isAdvancedFilter = true;
            currentAdvancedFilter = "static";
            label3.Left = 750;
            button3.Left = 750;
            button2.Left = 750;
            label1.Text = "Foreground Image";
            label2.Text = "Background Image";
        }

        private void subtractionWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "Click to select foreground image";
            Width = 1200;
            pictureBox3.Visible = true;
            button4.Visible = true;
            label5.Text = "Subtraction (Webcam)";
            isAdvancedFilter = true;
            currentAdvancedFilter = "webcam";
            label3.Left = 750;
            button3.Left = 750;
            button2.Left = 750;
            label1.Text = "Foreground Image";
            label2.Text = "Background Image";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (cameraCaptureEnabled)
            //{
            //    using (CameraForm camForm = new CameraForm())
            //    {
            //        camForm.ShowDialog();
            //        if (camForm.CapturedImage != null)
            //        {
            //            pictureBox2.Image = camForm.CapturedImage;
            //            button4.Visible = false;
            //        }
            //    }
            //}
            //else
            //{
                using (OpenFileDialog ofile = new OpenFileDialog())
                {
                    ofile.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                    if (ofile.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox2.Image = Image.FromFile(ofile.FileName);
                        button4.Visible = false;
                    }
                }
            //}
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
            this.Width = 800;
            pictureBox3.Visible = false;
            button4.Visible = false;
            label5.Text = "None";
            isAdvancedFilter = false;
            currentAdvancedFilter = "";
            pictureBox3.Image = null;
            button1.Text = "Click to select an image";
            label3.Left = 340;
            button3.Left = 333;
            button2.Left = 333;

            label1.Text = "Input image";
            label2.Text = "Output image";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toggleCameraCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void turnOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cameraCaptureEnabled = true;
            turnOnToolStripMenuItem.Checked = true;
            offToolStripMenuItem.Checked = false;

            MessageBox.Show(
                "If camera preview is not showing anything, download and use ManyCam (https://manycam.com/) as your camera device.",
                "Camera Preview Help",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cameraCaptureEnabled = false;
            turnOnToolStripMenuItem.Checked = false;
            offToolStripMenuItem.Checked = true;
        }
    }
}
