using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.IO;
namespace STIDiscover
{
    public partial class Contact : Form
    {
        private Process oskProcess;
        public Contact()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string course = txtCourse.Text;
            string year = txtYear.Text;
            string section = txtSection.Text;
            string concernDescription = txtConcern.Text;

            if (string.IsNullOrWhiteSpace(course) || string.IsNullOrWhiteSpace(year) ||
                string.IsNullOrWhiteSpace(section) || string.IsNullOrWhiteSpace(concernDescription))
            {
                MessageBox.Show("Please fill out all fields before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string adminEmail = "heyitsmebausa@gmail.com"; 
            string subject = $"Concern from {course} {year}-{section}";
            string body = $"Course: {course}\nYear: {year}\nSection: {section}\n\nConcern:\n{concernDescription}";

            try
            {
                SendEmail(adminEmail, subject, body);
                MessageBox.Show("Your concern has been sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send the email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartOnScreenKeyboard()
        {
            try
            {
                string oskPath = @"C:\Windows\System32\osk.exe"; // Adjust path if necessary

                // Check if the On-Screen Keyboard exists
                if (File.Exists(oskPath))
                {
                    // Launch the On-Screen Keyboard and save the process object
                    oskProcess = Process.Start(oskPath);
                }
                else
                {
                    MessageBox.Show("On-Screen Keyboard not found at the expected location.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening On-Screen Keyboard:\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("heyitsmebausa@gmail.com"); 
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)) 
                {
                    smtp.Credentials = new NetworkCredential("heyitsmebausa@gmail.com", "zpzm hupc wotf lnbz"); 
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCourse_Click(object sender, EventArgs e)
        {

        }

        private void txtYear_Click(object sender, EventArgs e)
        {
            StartOnScreenKeyboard();
        }

        private void txtSection_Click(object sender, EventArgs e)
        {
            StartOnScreenKeyboard();
        }

        private void txtConcern_Click(object sender, EventArgs e)
        {
            StartOnScreenKeyboard();
        }
    }
}
