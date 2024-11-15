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
    public partial class displayControl : UserControl
    {
        public displayControl()
        {
            InitializeComponent();
        }
        public void SetEventDetails(string eventName)
        {
            lblShowName.Text = eventName; // Assume lblEventName is a label in the user control
        }
        private void displayControl_Load(object sender, EventArgs e)
        {

        }
    }
}
