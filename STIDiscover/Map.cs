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
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            string unityAppPath = @"C:\Path\To\Your\UnityApp.exe";

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

                MessageBox.Show("Unity application started successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start Unity application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetHelp_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Hide();
            GetHelp getHelp = new GetHelp();
            getHelp.Show();
        }
    }
}
