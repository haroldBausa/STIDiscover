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
        // Method to fetch events for the current month and year
        // Fetches events for the current month and year
        private Dictionary<int, string> GetEvents(int month, int year)
        {
            var events = new Dictionary<int, string>();
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
                            string eventName = reader.GetString("event_name"); // Assuming "EventName" is the event name column
                            events[day] = eventName;
                        }
                    }
                }
            }
            return events;
        }
        public void displayDays()
        {
            DateTime now = new DateTime(year, month, 1);
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lblMonth.Text = monthName + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek);

            // Get events for the current month and year
            var events = GetEvents(month, year);

            // Clear existing controls
            dayContainer.Controls.Clear();

            // Fill empty spaces
            for (int i = 0; i < dayoftheweek; i++)
            {
                dayContainer.Controls.Add(new Panel { Size = new Size(209, 100), Margin = new Padding(0) });
            }

            // Add days of the month
            for (int i = 1; i <= days; i++)
            {
                UserControlDays userdays = new UserControlDays();
                userdays.days(i);

                // Check if there's an event for this day
                if (events.ContainsKey(i))
                {
                    userdays.SetEvent(events[i]); // Highlight day if event exists
                }

                dayContainer.Controls.Add(userdays);
            }
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
    }
}
