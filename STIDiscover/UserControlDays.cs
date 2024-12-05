using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace STIDiscover
{
    public partial class UserControlDays : UserControl
    {
        public int DayNumber { get; private set; }  // Store the day number
        public int MonthNumber { get; private set; } // Store the month number
        public int YearNumber { get; private set; } // Store the year number

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
        }

        public void SetDay(int numday, int month, int year)
        {
            label1.Text = numday.ToString();
            DayNumber = numday;
            MonthNumber = month;  // Store the month number
            YearNumber = year;    // Store the year number
        }

        // Method to set the event count under the day number
        public void SetEvent(int eventCount)
        {
            if (eventCount > 0)
            {
                lblEventName.Text = $"{eventCount} Event(s)";
            }
            else
            {
                lblEventName.Text = "";
            }
        }

        private void lblEventName_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> eventsForDay = GetEventsForDay(DayNumber, MonthNumber, YearNumber);

                if (eventsForDay.Count > 0)
                {
                    DateTime selectedDate = new DateTime(YearNumber, MonthNumber, DayNumber);

                    // Pass the event list and selected date to the displayEventCount form
                    displayEventCount detailsForm = new displayEventCount(eventsForDay, selectedDate);
                    detailsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No events available for this day.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private List<string> GetEventsForDay(int day, int month, int year)
        {
            var events = new List<string>();
            string connectionString = "Server=localhost;Database=event_schedule;Uid=root;Pwd=;";
            string query = "SELECT event_name FROM Events WHERE DAY(event_date) = @day AND MONTH(event_date) = @month AND YEAR(event_date) = @year";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@day", day);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", year);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                events.Add(reader.GetString("event_name"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching events: {ex.Message}");
            }

            return events;
        }

        public void HighlightPastEvents()
        {
            DateTime controlDate = new DateTime(YearNumber, MonthNumber, DayNumber);
            DateTime today = DateTime.Today;

            if (controlDate < today)
            {
                string connectionString = "Server=localhost;Database=event_schedule;Uid=root;Pwd=;";
                string query = "SELECT COUNT(*) FROM Events WHERE event_date < @today AND event_date >= @monthAgo";

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            DateTime oneMonthAgo = today.AddMonths(-1);

                            cmd.Parameters.AddWithValue("@today", today);
                            cmd.Parameters.AddWithValue("@monthAgo", oneMonthAgo);

                            int eventCount = Convert.ToInt32(cmd.ExecuteScalar());

                            if (eventCount > 0)
                            {
                                this.BackColor = Color.Red;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error highlighting past events: {ex.Message}");
                }
            }
        }
    }
}