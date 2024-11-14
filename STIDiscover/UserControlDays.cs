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
    public partial class UserControlDays : UserControl
    {
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void SetDay(int numday)
        {
            label1.Text = numday.ToString();
        }
        // Method to set the event name under the day number
        public void SetEvent(int eventCount)
        {
            if (eventCount > 0)
            {
                lblEventName.Text = $"{eventCount}";
            }
            else
            {
                lblEventName.Text = "";
            }
        }

        private void lblEventName_Click(object sender, EventArgs e)
        {
            
        }
    }
}
