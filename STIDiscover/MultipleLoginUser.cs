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

namespace STIDiscover
{
    public partial class MultipleLoginUser : Form
    {
        public MultipleLoginUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnToMap_Click(object sender, EventArgs e)
        {
            string unityAppPath = @"C:\Users\USER\Final\STIDiscover\Final.exe";

            StartUnityApp(unityAppPath);
        }
        private void StartUnityApp(string appPath)
        {
            try
            {
                // Create a new process
                Process process = new Process();
                process.StartInfo.FileName = appPath;

                // Start the process
                process.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start Unity application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToAsk_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Close();
            frm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrontPage fp = new FrontPage();
            this.Close();
            fp.ShowDialog();
        }
    }
}
