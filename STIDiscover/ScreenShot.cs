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

        public ScreenShot()
        {
            InitializeComponent();
        }
        private void ScreenShot_Load(object sender, EventArgs e)
        {

        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string adminEmail = "heyitsmebausa@gmail.com"; // Admin email address
            string description = txtConcern.Text;

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please provide a description of the issue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string subject = "User Report with Screenshot";
            string body = $"User Description:\n{description}";

            try
            {
                // Prepare the email
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

                    // Configure the SMTP client
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("heyitsmebausa@gmail.com", "zpzm hupc wotf lnbz");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                MessageBox.Show("Report sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCaptureScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide the form temporarily to capture the target data
                this.Hide();

                // Capture the entire screen
                Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    g.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                }

                // Display the screenshot in the PictureBox
                pictureBoxScreenshot.Image = screenshot;

                // Optionally save the screenshot to a temporary location
                string tempPath = Path.Combine(Path.GetTempPath(), "screenshot.png");
                screenshot.Save(tempPath, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("Screenshot captured successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Show the form again after the screenshot is captured
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing screenshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void txtConcern_Enter(object sender, EventArgs e)
        {
            OpenTabTip();
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
        
    }
}
