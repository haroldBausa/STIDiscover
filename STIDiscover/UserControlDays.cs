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
            DayNumber = numday; // Store the day number for later use
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
                List<string> eventsForDay = GetEventsForDay(DayNumber);

                if (eventsForDay.Count > 0)
                {
                    // Assume you have a way to get the current month and year
                    DateTime selectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DayNumber);

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
        private List<string> GetEventsForDay(int day)
        {
            var events = new List<string>();
            string connectionString = "Server=localhost;Database=event_schedule;Uid=root;Pwd=;";
            string query = "SELECT event_name FROM Events WHERE DAY(event_date) = @day";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@day", day);

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
    }
}
