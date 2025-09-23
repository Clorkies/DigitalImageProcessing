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

            device = device;
            devices = DeviceManager.GetAllDevices();
            if (devices.Length == 0)
            {
                MessageBox.Show("No camera devices found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
            device = devices[0];
            if (device == null)
            {
                MessageBox.Show("Invalid camera device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            device.ShowWindow(pictureBoxCamera);
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
            device.Sendmessage();
            if (Clipboard.ContainsImage())
            {
                CapturedImage = new Bitmap(Clipboard.GetImage());
                DialogResult = DialogResult.OK;
                Close();
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
