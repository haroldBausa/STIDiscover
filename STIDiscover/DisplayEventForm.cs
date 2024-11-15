using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STIDiscover
{
    public partial class DisplayEventForm : Form
    {
        public DisplayEventForm()
        {
            InitializeComponent();
        }
        public void SetEventDetails(string eventName, string description, byte[] imageBytes)
        {
            lblEventName.Text = eventName; // Set event name in the label
            lblEventDescription.Text = description; // Set event description in the label

            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureEvent.Image = Image.FromStream(ms); // Set image from byte array
                }
            }
            else
            {
                pictureEvent.Image = null; // Or set a default image if no image is provided
            }
        }
        private void userControlForEventDescription1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
