using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STIDiscover
{
    public partial class FrontPage : Form
    {
        private int ImageNumber = 1;
        public FrontPage()
        {
            InitializeComponent();
        }

        private void LoadNextImages()
        {
            ImageNumber++;
            if (ImageNumber > 7) // Adjust this to include the video
            {
                ImageNumber = 1;
            }

            LoadMedia();
            LoadChecked();
        }

        private void LoadPreviousImages()
        {
            ImageNumber--;
            if (ImageNumber < 1)
            {
                ImageNumber = 7; // Adjust this to include the video
            }

            LoadMedia();
            LoadChecked();
        }

        private void LoadMedia()
        {
            // Stop any previous media to ensure smooth transitions
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Visible = false;
            pictureBox1.Visible = false;
            btnSkipVideo.Visible = false; // Hide the skip button by default

            if (ImageNumber == 7) // Check if ImageNumber corresponds to the video
            {
                // Use GetFullPath to resolve the relative path
                string videoPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images & Video\Happy 41st Founding Year STI.mp4"));
                if (System.IO.File.Exists(videoPath))
                {
                    axWindowsMediaPlayer1.URL = videoPath;
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                    // Show the skip button while the video is playing
                    btnSkipVideo.Visible = true;

                    // Pause the timer while the video plays
                    timer1.Stop();
                }
                else
                {
                    MessageBox.Show($"Video file not found: {videoPath}");
                }
            }
            else
            {
                // Check if the image file exists before loading
                string imagePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"..\..\Images & Video\{ImageNumber}.jpg"));
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBox1.ImageLocation = imagePath;
                    pictureBox1.Visible = true;
                }
                else
                {
                    MessageBox.Show($"Image file not found: {imagePath}");
                }

                // Start the timer again if not on the video
                timer1.Start();
            }
        }


        private void LoadChecked()
        {
            // Handle radio button checks for images 1-6
            rb1.Checked = ImageNumber == 1;
            rb2.Checked = ImageNumber == 2;
            rb3.Checked = ImageNumber == 3;
            rb4.Checked = ImageNumber == 4;
            rb5.Checked = ImageNumber == 5;
            rb6.Checked = ImageNumber == 6;

            // Ensure the appearance is reset after the video
            if (ImageNumber == 1)
            {
                rb1.Select(); // Manually select rb1 to apply appearance consistently
            }
        }

       


        private void Guna2ButtonSetup(Guna.UI2.WinForms.Guna2Button button)
        {
            button.FillColor = System.Drawing.Color.Transparent; // Make button background transparent
            button.BorderThickness = 0; // Remove border
            button.HoverState.FillColor = System.Drawing.Color.Transparent; // Transparent on hover

            // Set text color for visibility
            button.ForeColor = System.Drawing.Color.White; // Adjust this color as needed

            button.Parent = pictureBox1;  // Set to the background PictureBox or container
            BtnStart.BackColor = System.Drawing.Color.Transparent;
            BtnStart.Parent = pictureBox1;
        }


        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                // Video has finished playing
                ImageNumber = 1; // Reset to the first image
                LoadMedia(); // Load the first image

                // Hide the skip button after video ends
                btnSkipVideo.Visible = false;

                // Resume the timer after video ends
                timer1.Start();
            }
        }




        private void timer1_Tick_1(object sender, EventArgs e)
        {
            LoadNextImages();
        }

        private void FrontPage_Load_1(object sender, EventArgs e)
        {

            rb1.Checked = true;
            LoadMedia();

            // Subscribe to the PlayStateChange event
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            // Setup Guna buttons
            Guna2ButtonSetup(BtnPrevious);
            Guna2ButtonSetup(BtnNext);

            // Make panel transparent (if applicable)
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Parent = pictureBox1; // Set the parent for transparency
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            LoadNextImages();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            LoadPreviousImages();
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Stop any media playing
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            // Hide this form
            this.Hide();

            // Open the next form
            using (Form1 form = new Form1())
            {
                form.ShowDialog();
            }

            // Dispose of this form after the new form is closed
            this.Dispose();
        }

        private void btnSkipVideo_Click_1(object sender, EventArgs e)
        {
            // Stop the video, reset to first image, and hide skip button
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            ImageNumber = 1;
            rb1.Select();
            LoadMedia(); // Load the first image
            btnSkipVideo.Visible = false; // Hide the skip button
            timer1.Start(); // Resume the timer
        }
    }
}
