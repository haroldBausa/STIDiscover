using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace STIDiscover
{
    public partial class displayEventCount : Form
    {
        
        public displayEventCount(List<string> events, DateTime selectedDate)
        {
            InitializeComponent();
            PopulateEvents(events);
            SetSelectedDate(selectedDate);


           
        }
        
        private void SetSelectedDate(DateTime date)
        {
            // Format the date as "Saturday, November 16, 2024"
            lblGetDate.Text = date.ToString("D");
        }
        private void PopulateEvents(List<string> events)
        {
            flowLayoutPanel1.Controls.Clear(); // Clear any existing controls

            foreach (string eventName in events)
            {
                // Create an instance of displayControl for each event
                displayControl eventControl = new displayControl();
                eventControl.SetEventDetails(eventName); // Set event name

                // Add the user control to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(eventControl);
            }
        }
        private void displayEventCount_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
