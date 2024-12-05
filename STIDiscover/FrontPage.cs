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
        
        private Timer autoSwitchTimer;
        private Timer fadeinTimer;
        private double opacityIncrement = 0.05;
        private int ImageNumber = 1;
        public FrontPage()
        {
            InitializeComponent();
            this.Opacity = 0;

            // Set up fade-in timer
            fadeinTimer = new Timer();
            fadeinTimer.Interval = 20;
            fadeinTimer.Tick += FadeInTimer_Tick;
            fadeinTimer.Start();

            // Set up auto switch timer
            autoSwitchTimer = new Timer();
            autoSwitchTimer.Interval = 5000;  // Set to 5 seconds (5000 ms)
            autoSwitchTimer.Tick += AutoSwitchTimer_Tick;  // Trigger image switch
            autoSwitchTimer.Start();
        }
        private void AutoSwitchTimer_Tick(object sender, EventArgs e)
        {
            LoadNextImages();  // Switch to the next image/video
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
            StartFadeIn();
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
            StartFadeIn();
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
                string videoPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images & Video\Happy 41st Founding Year STI.mp4"));
                if (System.IO.File.Exists(videoPath))
                {
                    axWindowsMediaPlayer1.URL = videoPath;
                    axWindowsMediaPlayer1.Visible = true;
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                    // Show the skip button while the video is playing
                    btnSkipVideo.Visible = true;

                    // Pause both timers while the video plays
                    fadeinTimer.Stop();
                    autoSwitchTimer.Stop(); // Stop auto-switching while video plays
                }
                else
                {
                    MessageBox.Show($"Video file not found: {videoPath}");
                }
            }
            else
            {
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

                // Start the fade-in timer for image transitions
                fadeinTimer.Start();
                autoSwitchTimer.Start(); // Ensure auto-switching is active for images
            }
        }


        private void LoadChecked()
        {
            rb1.Checked = ImageNumber == 1;
            rb2.Checked = ImageNumber == 2;
            rb3.Checked = ImageNumber == 3;
            rb4.Checked = ImageNumber == 4;
            rb5.Checked = ImageNumber == 5;
            rb6.Checked = ImageNumber == 6;

            if (ImageNumber == 1)
            {
                rb1.Select();
            }
        }

        private void Guna2ButtonSetup(Guna.UI2.WinForms.Guna2Button button)
        {
            button.FillColor = System.Drawing.Color.Transparent;
            button.BorderThickness = 0;
            button.HoverState.FillColor = System.Drawing.Color.Transparent;
            button.ForeColor = System.Drawing.Color.White;
            button.Parent = pictureBox1;
            BtnStart.BackColor = System.Drawing.Color.Transparent;
            BtnStart.Parent = pictureBox1;
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                ImageNumber = 1;
                LoadMedia();
                btnSkipVideo.Visible = false;

                // Resume the timers after video ends
                fadeinTimer.Start();
                autoSwitchTimer.Start();
            }
        }


        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity += opacityIncrement;
            if (this.Opacity >= 1)
            {
                this.Opacity = 1;
                fadeinTimer.Stop();
            }
        }

        private void StartFadeIn()
        {
            this.Opacity = 0;  // Reset opacity before fading in
            fadeinTimer.Start();  // Start the fade-in transition
        }

        private void FrontPage_Load_1(object sender, EventArgs e)
        {
            rb1.Checked = true;
            LoadMedia();

            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange;

            Guna2ButtonSetup(BtnPrevious);
            Guna2ButtonSetup(BtnNext);

            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Parent = pictureBox1;
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
            autoSwitchTimer.Stop();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Hide();
            using (MultipleLoginUser mlu = new MultipleLoginUser())
            {
                mlu.ShowDialog();
            }
            this.Close();
        }

        private void btnSkipVideo_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            ImageNumber = 1;
            rb1.Select();
            LoadMedia();
            btnSkipVideo.Visible = false;

            // Resume the auto-switch timer after skipping the video
            autoSwitchTimer.Start();
        }

        private void FrontPage_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }
    }
}
