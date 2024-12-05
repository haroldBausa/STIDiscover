using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
namespace STIDiscover
{
    public partial class DeanValidation : Form
    {
        private Form backgroundForm;
        private Process onScreenKeyboardProc;
        public DeanValidation(Form background)
        {
            InitializeComponent();
            this.backgroundForm = background;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            lblDescr.Visible = false;
            lblRestrict.Visible = false;
            btnCancel.Visible = false;
            btnOkay.Visible = false;
            btnLogin.Visible = false;

            label3.Visible = true;
            label4.Visible = true;
            btnLogin.Visible = true;
            txtPassword.Visible = true;
            txtUsername.Visible = true;
            btnCancelagain.Visible = true;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FileMaintenance fm = new FileMaintenance();
            backgroundForm.Close();
            backgroundForm.Dispose();
            this.Close();
            fm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MySQL Connection String
            string connectionString = "Server=localhost;Database=admin_credentials;Uid=root;Pwd=;"; // Update with actual credentials

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM deans_credentials WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void OpenKeyboard(object sender, EventArgs e)
        {
            try
            {
                Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
                foreach (Process oskProcess in oskProcessArray)
                {
                    oskProcess.Kill();
                }

                string onScreenKeyboardPath = Environment.ExpandEnvironmentVariables(@"%ProgramFiles%\Common Files\Microsoft Shared\ink\TabTip.exe");

                if (File.Exists(onScreenKeyboardPath))
                {
                    onScreenKeyboardProc = Process.Start(onScreenKeyboardPath);
                }
                else
                {
                    MessageBox.Show("On-screen keyboard not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open the keyboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelagain_Click(object sender, EventArgs e)
        {
            lblDescr.Visible = true;
            lblRestrict.Visible = true;
            btnCancel.Visible = true;
            btnOkay.Visible = true;
            btnLogin.Visible = true;


            label3.Visible = false;
            label4.Visible = false;
            btnLogin.Visible = false;
            txtPassword.Visible = false;
            txtUsername.Visible = false;
            btnCancelagain.Visible = false;
        }

        private void txtUsername_Click(object sender, EventArgs e)
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

        private void txtPassword_Click(object sender, EventArgs e)
        {
            OpenTabTip();
        }
    }
}
