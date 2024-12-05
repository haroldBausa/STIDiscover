using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
namespace STIDiscover
{

    public partial class Form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
  
        public Form1()
        {

            InitializeComponent();
            //homeControl1.BringToFront();
            homeControl1.BringToFront();
        }
        
        protected override void WndProc(ref Message m)
        {
            // Block the form from being moved
            if (m.Msg == WM_NCLBUTTONDOWN && (int)m.WParam == HTCAPTION)
            {
                // Prevent the form from moving
                return;
            }

            base.WndProc(ref m);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homeControl1.BringToFront();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleControl1.BringToFront();
        }

  

        private void btnEventModule_Click(object sender, EventArgs e)
        {
            eventSchedule1.BringToFront();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Camera cam = new Camera();
            cam.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
           
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnMap_Click(object sender, EventArgs e)
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

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLoginForm admin = new AdminLoginForm(); 
            this.Hide();
            admin.ShowDialog();
        }
    }
}
