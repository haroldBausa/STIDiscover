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
using MySql.Data.MySqlClient;
using System.IO;
using MySqlX.XDevAPI;
namespace STIDiscover
{
    public partial class AdminLoginForm : Form
    {

        public AdminLoginForm()
        {
            InitializeComponent();
            txtUsername.Click += txtUsername_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // MySQL connection string
            string connectionString = "Server=localhost;Database=admin_credentials;Uid=root;Pwd=;"; 

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to check username and password
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if (result > 0)
                        {
                            // Open the next form if login is successful
                            MessageBox.Show("Login successful!");
                            //FormFaceAuthentication ffa = new FormFaceAuthentication();
                            //ffa.ShowDialog();
                            this.Hide();
                            // Open your next form here
                            FileMaintenance fm = new FileMaintenance();
                            fm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username or password, please try again");
                            txtUsername.Clear();
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Hide();
        }
        
        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the full path to TabTip.exe
                string tabTipPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";

                // Check if TabTip.exe exists
                if (File.Exists(tabTipPath))
                {
                    // Launch the On-Screen Keyboard (TabTip.exe)
                    Process.Start(tabTipPath);
                }
                else
                {
                    // Show an error message if TabTip.exe is not found
                    MessageBox.Show("TabTip.exe not found at the expected location.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Show the error message in a MessageBox
                MessageBox.Show($"Error opening On-Screen Keyboard:\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
