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
    public partial class homeControl : UserControl
    {
        public homeControl()
        {
            InitializeComponent();
           
        }
      
        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnB1_Click(object sender, EventArgs e)
        {
            Building1 building1 = new Building1();
            building1.Show();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Hide();
            GetHelp getHelp = new GetHelp();
            getHelp.Show();

        }

            
        private void btnB2_Click(object sender, EventArgs e)
        {
            Building2 building2 = new Building2();
            building2.Show();
        }

        private void btnB3_Click(object sender, EventArgs e)
        {
            Building3 building3 = new Building3();
            building3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void homeControl_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Parent = pictureBox4;
        }
    }
}
