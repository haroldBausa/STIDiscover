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
    }
}
