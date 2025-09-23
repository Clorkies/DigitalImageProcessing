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
    public partial class Form1 : Form
    {
        int index;
        OpenFileDialog ofile;
        private bool isAdvancedFilter = false;
        private string currentAdvancedFilter = "";

        public Form1()
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

        // Convert button logic
        private void button2_Click(object sender, EventArgs e)
        {
            if (isAdvancedFilter)
            {
                if (currentAdvancedFilter == "static")
                {
                    if (pictureBox1.Image != null && pictureBox3.Image != null)
                    {
                        pictureBox2.Image = Processes.Subtract(
                            (Bitmap)pictureBox1.Image,
                            (Bitmap)pictureBox3.Image
                        );
                    }
                    else
                    {
                        MessageBox.Show("Please select both input images for subtraction.", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (currentAdvancedFilter == "webcam")
                {
                    // Placeholder for webcam subtraction logic
                    MessageBox.Show("Webcam subtraction not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            // Normal filter logic (if not advanced)
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
            ofile = new OpenFileDialog();
            ofile.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (DialogResult.OK == ofile.ShowDialog())
            {
                pictureBox1.Image = Image.FromFile(ofile.FileName);
                
                button1.Visible = false;

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
            this.Width = 1120;
            pictureBox3.Visible = true;
            button4.Visible = true;
            label5.Text = "Subtraction (Static)";
            isAdvancedFilter = true;
            currentAdvancedFilter = "static";
        }

        private void subtractionWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 1120;
            pictureBox3.Visible = true;
            button4.Visible = true;
            label5.Text = "Subtraction (Webcam)";
            isAdvancedFilter = true;
            currentAdvancedFilter = "webcam";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox3.Image = Image.FromFile(ofd.FileName);
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
        }
    }
}
