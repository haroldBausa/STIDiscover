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
    public partial class FileMaintenance : Form
    {
        public FileMaintenance()
        {
            InitializeComponent();
           
        }
        

        private void btnEvent_Click(object sender, EventArgs e)
        {
           eventManager1.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1(); 
            form1.ShowDialog();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            scheduleControlManager1.BringToFront();
            Form background = new Form();
            try
            {
                background.StartPosition = FormStartPosition.Manual;
                background.FormBorderStyle = FormBorderStyle.None;
                background.Opacity = .70d;
                background.BackColor = Color.Black;
                background.WindowState = FormWindowState.Maximized;
                background.TopMost = true;
                background.Location = this.Location;
                background.ShowInTaskbar = false;
                background.Show();

                // Pass the background form to DeanValidation
                using (DeanValidation deanValidation = new DeanValidation(background))
                {
                    deanValidation.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Ensure the background form is closed and disposed
                if (!background.IsDisposed)
                {
                    background.Close();
                    background.Dispose();
                }
            }
        }

        private void FileMaintenance_Load(object sender, EventArgs e)
        {
            eventManager1.BringToFront();
        }
    }
}
