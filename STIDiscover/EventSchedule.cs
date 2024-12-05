using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace STIDiscover
{
    public partial class EventSchedule : UserControl
    {
        int month,year;
        public EventSchedule()
        {
            InitializeComponent();
            
        }
       
        private Dictionary<int, List<string>> GetEvents(int month, int year)
        {
            var events = new Dictionary<int, List<string>>();
            string query = "SELECT DAY(event_date) AS Day, event_name FROM Events WHERE MONTH(event_date) = @month AND YEAR(event_date) = @year";

            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=event_schedule;Uid=root;Pwd=;"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int day = reader.GetInt32("Day");
                            string eventName = reader.GetString("event_name");

                            if (!events.ContainsKey(day))
                            {
                                events[day] = new List<string>();
                            }

                            events[day].Add(eventName);  // Add event to the list for that day
                        }
                    }
                }
            }
            return events;
        }
        public void displayDays()
        {
            DateTime now = new DateTime(year, month, 1);
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMonth.Text = $"{monthName} {year}";

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek);

            // Get events for the current month and year
            var events = GetEvents(month, year);

            // Suspend the layout update to prevent the UI from refreshing each time
            dayContainer.SuspendLayout();

            // Clear existing controls in the day container
            dayContainer.Controls.Clear();

            // Add empty spaces for days before the start of the month (empty slots)
            for (int i = 0; i < dayoftheweek; i++)
            {
                dayContainer.Controls.Add(new Panel { Size = new Size(209, 100), Margin = new Padding(0) });
            }

            // Add days of the month with event count
            for (int i = 1; i <= days; i++)
            {
                UserControlDays userdays = new UserControlDays();
                userdays.SetDay(i, month, year);  // Pass the day, month, and year to SetDay

                // Check if there are events for this day
                if (events.ContainsKey(i))
                {
                    int eventCount = events[i].Count();  // Get the count of events for this day
                    userdays.SetEvent(eventCount);  // Pass event count to the user control

                    // Highlight past events in red
                    DateTime eventDate = new DateTime(year, month, i);
                    if (eventDate < DateTime.Now)
                    {
                        userdays.BackColor = Color.Red;
                    }
                }
                else
                {
                    userdays.SetEvent(0); // No events for this day
                }

                dayContainer.Controls.Add(userdays); // Add the control to the container
            }

            // End layout update and refresh the container in one go
            dayContainer.ResumeLayout();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EventSchedule_Load_1(object sender, EventArgs e)
        {
            // Set the initial month and year
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            displayDays();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Increment the month and adjust year if necessary
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            displayDays(); // Update the calendar display
        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Decrement the month and adjust year if necessary
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            displayDays(); // Update the calendar display
        }

        private void OpenEventDetailsForm(int day)
        {
            // Fetch events for the selected day
            var events = GetEvents(month, year);
            if (events.ContainsKey(day))
            {
                List<string> eventNames = events[day];

                // Create a DateTime for the selected date
                DateTime selectedDate = new DateTime(year, month, day);

                // Open the new form and pass the event names and selected date
                displayEventCount detailsForm = new displayEventCount(eventNames, selectedDate);
                detailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No events available for this day.");
            }
        }
    }
}
