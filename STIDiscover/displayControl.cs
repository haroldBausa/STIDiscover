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
using MySql.Data.MySqlClient;
namespace STIDiscover
{
    public partial class displayControl : UserControl
    {

        private string connectionString = "Server=localhost;Database=event_schedule;Uid=root;Pwd=;"; // Update as needed
        private string eventName;
        public displayControl()
        {
            InitializeComponent();
        }

        public void SetEventDetails(string eventName)
        {
            this.eventName = eventName;
            lblShowName.Text = eventName; // Assume lblEventName is a label in the user control
        }
        private void displayControl_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            RetrieveEventDetails(eventName);
        }
        private void RetrieveEventDetails(string eventName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT event_name, description, event_image FROM events WHERE event_name = @eventName";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@eventName", eventName);

                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["event_name"].ToString();
                        string description = reader["description"].ToString();
                        byte[] imageBytes = reader["event_image"] as byte[];

                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                try
                                {
                                    Image eventImage = Image.FromStream(ms);

                                    // Convert Image to byte[] before passing to SetEventDetails
                                    using (MemoryStream byteStream = new MemoryStream())
                                    {
                                        eventImage.Save(byteStream, eventImage.RawFormat);
                                        byte[] eventImageBytes = byteStream.ToArray();

                                        DisplayEventForm displayEventForm = new DisplayEventForm();
                                        displayEventForm.SetEventDetails(name, description, eventImageBytes);

                                        displayEventForm.Show();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error loading image: {ex.Message}", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No image available for this event.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DisplayEventForm displayEventForm = new DisplayEventForm();
                            displayEventForm.SetEventDetails(name, description, null);
                            displayEventForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Event details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
