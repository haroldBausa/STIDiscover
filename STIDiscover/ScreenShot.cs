using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
namespace STIDiscover
{
    public partial class ScreenShot : Form
    {
        private static ScreenShot instance;
        public ScreenShot()
        {
            InitializeComponent();
            
        }
        
        private void ScreenShot_Load(object sender, EventArgs e)
        {

        }

        private async void btnSendEmail_Click(object sender, EventArgs e)
        {
            string adminEmail = "heyitsmebausa@gmail.com"; // Admin email address
            string description = txtConcern.Text.Trim();

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please provide a description of the issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string subject = "User Report with Screenshot";
            string body = $"User Description:\n{description}";

            try
            {
                // Show a loading message
                MessageBox.Show("Sending email, please wait...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await Task.Run(() =>
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("heyitsmebausa@gmail.com");
                        mail.To.Add(adminEmail);
                        mail.Subject = subject;
                        mail.Body = body;

                        // Attach the screenshot if it exists
                        if (pictureBoxScreenshot.Image != null)
                        {
                            string tempPath = Path.Combine(Path.GetTempPath(), "screenshot.png");
                            mail.Attachments.Add(new Attachment(tempPath));
                        }

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("heyitsmebausa@gmail.com", "zpzm hupc wotf lnbz");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                });

                MessageBox.Show("Report sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCaptureScreenshot_Click(object sender, EventArgs e)
        {
            CaptureScreenshot();
        }

        public static void ShowWithScreenshot()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ScreenShot();
            }

            instance.CaptureScreenshot(); // Automatically capture a screenshot
            instance.Show(); // Display the form
            instance.BringToFront(); // Bring it to the front
        }

        private void CaptureScreenshot()
        {
            try
            {
                // Define the area to capture (update dimensions as needed)
                Rectangle captureArea = new Rectangle(this.Location.X, this.Location.Y, 1980, 875);

                // Create a new bitmap for the screenshot
                Bitmap screenshot = new Bitmap(captureArea.Width, captureArea.Height);

                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(captureArea.Location, Point.Empty, captureArea.Size);
                }

                // Display the screenshot in the PictureBox
                pictureBoxScreenshot.Image = screenshot;

                // Save to a temporary file
                string tempPath = Path.Combine(Path.GetTempPath(), "screenshot.png");
                screenshot.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void txtConcern_Enter(object sender, EventArgs e)
        {
        }
        private void OpenTabTip()
        {
            try
            {
                Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open TabTip: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConcern_Click(object sender, EventArgs e)
        {
            OpenTabTip();
            txtConcern.Text = "";
            txtConcern.ForeColor = Color.Black;
        }
    }
}
