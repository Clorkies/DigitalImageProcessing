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

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("-- Select Filter --");
            comboBox1.SelectedIndex = 5;
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

            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox2.Image = ImageProcessing.Processes.Copy((Bitmap)pictureBox1.Image);
            }
            else
            {
                pictureBox2.Image = pictureBox1.Image;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofile = new OpenFileDialog();
            ofile.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (DialogResult.OK == ofile.ShowDialog())
            {
                pictureBox1.Image = Image.FromFile(ofile.FileName);
                
                button1.Visible = false;

                //button1.Text = "";
                //button1.FlatStyle = FlatStyle.Flat;
                //button1.BackColor = Color.Transparent;
                //button1.Parent = pictureBox1;
                //button1.BringToFront();

            }
        }
    }
}
