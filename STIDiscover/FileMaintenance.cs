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
        }
    }
}
