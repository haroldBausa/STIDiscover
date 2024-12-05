using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;

namespace STIDiscover
{
    public partial class Camera : Form
    {
        FilterInfoCollection filter;
        VideoCaptureDevice device;

        public Camera()
        {
            InitializeComponent();
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            // Initialize filter to get all video input devices
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Check if there are any video input devices
            if (filter.Count > 0)
            {
                // Log available devices
                Console.WriteLine("Video input devices found:");
                foreach (FilterInfo deviceInfo in filter)
                {
                    Console.WriteLine(deviceInfo.Name);
                }

                // Automatically select the first video input device
                device = new VideoCaptureDevice(filter[0].MonikerString);
                device.NewFrame += Device_NewFrame;
                device.Start();
            }
            else
            {
                MessageBox.Show("No video input devices found.");
                Console.WriteLine("No video input devices found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        static readonly CascadeClassifier cascade = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                // Clone the current frame for processing
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
                Rectangle[] rectangles = cascade.DetectMultiScale(grayImage, 1.2, 1);

                // Process detected face
                if (rectangles.Length > 0)
                {
                    Rectangle rectangle = rectangles[0]; // Take the first detected face only

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Pen pen = new Pen(Color.Blue, 2))
                        {
                            graphics.DrawRectangle(pen, rectangle);
                        }
                    }

                    // Update status text
                    UpdateStatusText("Face Detected");
                }
                else
                {
                    UpdateStatusText("No face detected");
                }

                // Update the PictureBox with the processed frame
                pictureBox1.Image = bitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing frame: " + ex.Message);
            }
        }

        // Method to safely update label status
        private void UpdateStatusText(string message)
        {
            // Check if the form is not disposed before updating the label
            if (!this.IsDisposed && labelStatus.InvokeRequired)
            {
                Invoke(new Action(() => labelStatus.Text = message));
            }
        }

        private void Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that we stop the video device in a background thread to prevent UI lag
            Task.Run(() =>
            {
                if (device != null && device.IsRunning)
                {
                    device.SignalToStop(); // Request the device to stop gracefully
                    device.WaitForStop();  // Wait for the device to stop
                }

                // Cleanup any other resources (if necessary)
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }

                // Once done, you can invoke any necessary UI updates from the UI thread:
                Invoke(new Action(() =>
                {
                    // Update the status label or perform any UI-related cleanup here
                    labelStatus.Text = "Camera stopped and resources cleaned up";
                }));
            });

            // Prevent the form from closing immediately before cleanup is complete
            e.Cancel = false; // This allows the form to close as expected
        }

    }
}
