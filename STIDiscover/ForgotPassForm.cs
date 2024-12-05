using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
namespace STIDiscover
{
    public partial class ForgotPassForm : Form
    {
        private Process onScreenKeyboardProc;

        private string generatedOtp;
        private string userEmail = "heyitsmebausa@gmail.com";
        public ForgotPassForm()
        {
            InitializeComponent();
            
        }

        private void ForgotPassForm_Load(object sender, EventArgs e)
        {

        }


    
        private string GenerateOtp()
        {
            Random random = new Random();
            int otpNumber = random.Next(100000, 999999); // Generates a number between 100000 and 999999
            return otpNumber.ToString();
        }

        private void btnOTP_Click_1(object sender, EventArgs e)
        {
            generatedOtp = GenerateOtp();
            string subject = "Your OTP Code";
            string body = $"Your OTP code is: {generatedOtp}";

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("heyitsmebausa@gmail.com");
                    mail.To.Add(userEmail);
                    mail.Subject = subject;
                    mail.Body = body;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("heyitsmebausa@gmail.com", "zpzm hupc wotf lnbz");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                pictureBox1.Visible = true;
                panel1.Size = new Size(571, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send OTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void confirmButton_Click_1(object sender, EventArgs e)
        {
            string enteredOtp = txtOTP.Text.Trim();

            if (enteredOtp == generatedOtp)
            {
               
                panel1.Size = new Size(571, 414);
                txtPassword.Visible = true;
                txtConfirmPassword.Visible = true;
                txtOTP.Visible = false;
                confirmButton.Visible = false;
                label3.Visible = true;
                label2.Visible = true;
                btnOTP.Visible = false;
                label1.Text = "SUCCESSFUL!";
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtConfirmPassword_Click(object sender, EventArgs e)
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
        private void btnPassword_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=admin_credentials;Uid=root;Pwd=;"; // Adjust as needed
            string newPassword = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Check if both password fields match
            if (newPassword != confirmPassword)
            {
                label4.Visible = true;
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                return;
            }

            // Validate that the password is not empty
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Proceed to update password in the database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE users SET password = @password WHERE username = 'stidiscoverAdmin'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameterized query to prevent SQL injection
                        cmd.Parameters.AddWithValue("@password", newPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {

                            AdminLoginForm loginForm = new AdminLoginForm();
                            this.Hide();
                            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPassword.Clear();
                            txtConfirmPassword.Clear();
                            loginForm.ShowDialog();
                            

                        }
                        else
                        {
                            MessageBox.Show("Failed to update password. Please ensure the username exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOTP_Click(object sender, EventArgs e)
        {
            OpenTabTip();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            OpenTabTip();
        }
    }
}
