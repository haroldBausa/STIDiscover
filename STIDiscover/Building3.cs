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
    public partial class Building3 : Form
    {
        public Building3()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Building3_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Parent = pictureBox2;
        }
    }
}
