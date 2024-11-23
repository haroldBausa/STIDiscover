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

namespace STIDiscover
{

    public partial class Form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        public Form1()
        {
            InitializeComponent();
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
        private void moveImageBox(object sender)
        {

        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homeControl1.BringToFront();
        }
      
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleControl1.BringToFront();
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            map1.BringToFront();
        }

       

        private void btnAdmin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginForm adm = new AdminLoginForm();
            adm.ShowDialog();
        }

        private void btnEventModule_Click(object sender, EventArgs e)
        {
            eventSchedule1.BringToFront();
        }

        private void scheduleControl2_Load(object sender, EventArgs e)
        {

        }

    }
}
