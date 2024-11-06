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
using MySqlX.XDevAPI;
namespace STIDiscover
{
    public partial class AdminLoginForm : Form
    {
        private Process onScreenKeyboardProc;
        public AdminLoginForm()
        {
            InitializeComponent();
            txtUsername.Enter += new EventHandler(OpenKeyboard);
            txtPassword.Enter += new EventHandler(OpenKeyboard);
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
                            FormFaceAuthentication ffa = new FormFaceAuthentication();
                            ffa.ShowDialog();
                            this.Hide();
                            // Open your next form here
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
        private void OpenKeyboard(object sender, EventArgs e)
        {
            // Close any open instances of the on-screen keyboard
            Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
            foreach (Process oskProcess in oskProcessArray)
            {
                oskProcess.Kill();
            }

            // Open the on-screen keyboard
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string onScreenKeyboardPath = System.IO.Path.Combine(progFiles, "TabTip.exe");
            onScreenKeyboardProc = System.Diagnostics.Process.Start(onScreenKeyboardPath);
        }
    }
}