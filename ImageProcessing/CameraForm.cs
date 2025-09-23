using System;
using System.Drawing;
using System.Windows.Forms;
using WebCamLib;

namespace ImageProcessing
{
    public partial class CameraForm : Form
    {
        private Device device;
        private Device[] devices;   
        public Bitmap CapturedImage { get; private set; }


        public CameraForm(Device device)
        {
            InitializeComponent();

            this.device = device; // Assign parameter to field
            devices = DeviceManager.GetAllDevices();
            if (devices.Length == 0)
            {
                MessageBox.Show("No camera devices found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            this.device = devices[0];
            if (this.device == null)
            {
                MessageBox.Show("Invalid camera device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            this.device.ShowWindow(pictureBoxCamera);
            pictureBoxCamera.Refresh();
        }

        public CameraForm()
        {
            InitializeComponent();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            var devices = DeviceManager.GetAllDevices();
            if (devices.Length == 0)
            {
                MessageBox.Show("No camera devices found.");
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            device = devices[0];
            device.ShowWindow(pictureBoxCamera);
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            if (device == null) return;
            device.Sendmessage();
            if (Clipboard.ContainsImage())
            {
                var img = Clipboard.GetImage();
                if (img != null)
                {
                    CapturedImage = new Bitmap(img);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Clipboard image is null. Camera may not support this operation.");
                }
            }
            else
            {
                MessageBox.Show("Failed to capture image from camera.");
            }
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            device.Stop();
        }

        private void pictureBoxCamera_Click(object sender, EventArgs e)
        {

        }
    }
}
