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
    public partial class GetHelp : Form
    {
        public GetHelp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenContact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(); 
            contact.ShowDialog();
        }
    }
}
