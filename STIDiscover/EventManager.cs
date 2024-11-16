using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace STIDiscover
{
    public partial class EventManager : UserControl
    {
        private Process oskProcess;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=event_schedule;Uid=root;Pwd=;");
        public EventManager()
        {
            InitializeComponent();
            dtpEvent.ValueChanged += dtpEvent_ValueChanged;
            txtDescript.Click += txtDescript_Click;
            txtName.Click += txtName_Click;

            txtDescript.Leave += txtDescript_Leave;
            txtName.Leave += txtName_Leave;
        }

        private void EventManager_Load(object sender, EventArgs e)
        {

        }

        private void dtpEvent_ValueChanged(object sender, EventArgs e)
        {
            ShowEventInfo(dtpEvent.Value);
        }
        private void ShowEventInfo(DateTime date)
        {
            try
            {
                connection.Open();
                string query = "SELECT id, event_name, description, event_image FROM events WHERE event_date = @date";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                MySqlDataReader reader = cmd.ExecuteReader();
                lstEvents.Items.Clear(); // Clear previous events
                while (reader.Read())
                {
                    // Populate the ListBox with the event ID and name
                    lstEvents.Items.Add($"{reader["id"]} - {reader["event_name"]}");
                }
                if (!lstEvents.Items.Count.Equals(0))
                {
                    lblInfo.Text = "Select an event to view details.";
                }
                else
                {
                    lblInfo.Text = "No events found for the selected date.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO events (event_date, event_name, description, event_image) VALUES (@date, @name, @description, @image)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@date", dtpEvent.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@description", txtDescript.Text);

            // Add the image as a BLOB
            if (picEventImage.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    picEventImage.Image.Save(ms, picEventImage.Image.RawFormat);
                    cmd.Parameters.AddWithValue("@image", ms.ToArray());
                }
            }
            else
            {
                cmd.Parameters.AddWithValue("@image", DBNull.Value);
            }

            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Event with image added successfully!");
            ShowEventInfo(dtpEvent.Value);
            txtDescript.Clear();
            txtName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem == null)
            {
                MessageBox.Show("Please select an event to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedEvent = lstEvents.SelectedItem.ToString();
            string[] parts = selectedEvent.Split('-');
            int eventId = int.Parse(parts[0].Trim());

            try
            {
                connection.Open();
                string query = "UPDATE events SET event_name = @name, description = @description, event_image = @image WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", eventId);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@description", txtDescript.Text);

                // Update the image
                if (picEventImage.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picEventImage.Image.Save(ms, picEventImage.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@image", ms.ToArray());
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@image", DBNull.Value);
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show(rowsAffected > 0 ? "Event updated successfully!" : "No event found with the given ID.");
                ShowEventInfo(dtpEvent.Value); // Refresh the list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "DELETE FROM events WHERE event_date = @date AND event_name = @name";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@date", dtpEvent.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@name", txtName.Text); // Use the event name to delete specific event
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Event deleted successfully!");
            }
            else
            {
                MessageBox.Show("No matching event found for deletion.");
            }

            // Refresh the event list
            ShowEventInfo(dtpEvent.Value);

            // Clear input fields
            txtDescript.Clear();
            txtName.Clear();
            picEventImage.Image = null;
        }
        private void StartOnScreenKeyboard()
        {
            try
            {
                string oskPath = @"C:\Windows\System32\osk.exe"; // Adjust path if necessary

                // Check if the On-Screen Keyboard exists
                if (File.Exists(oskPath))
                {
                    // Launch the On-Screen Keyboard and save the process object
                    oskProcess = Process.Start(oskPath);
                }
                else
                {
                    MessageBox.Show("On-Screen Keyboard not found at the expected location.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening On-Screen Keyboard:\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void CloseOnScreenKeyboard()
        {
            // If the On-Screen Keyboard process is running, kill it
            if (oskProcess != null && !oskProcess.HasExited)
            {
                try
                {
                    oskProcess.Kill();
                    oskProcess = null; // Reset the process object after closing
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error closing On-Screen Keyboard:\n{ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            StartOnScreenKeyboard();
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            StartOnScreenKeyboard();
        }

        private void txtDescript_Click(object sender, EventArgs e)
        {
            CloseOnScreenKeyboard();
        }

        private void txtDescript_Leave(object sender, EventArgs e)
        {
            CloseOnScreenKeyboard();
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem != null)
            {
                // Get the event ID from the selected item
                string selectedEvent = lstEvents.SelectedItem.ToString();
                string[] parts = selectedEvent.Split('-');
                if (parts.Length >= 2)
                {
                    int eventId = int.Parse(parts[0].Trim());
                    LoadEventDetails(eventId);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected image in the PictureBox
                    picEventImage.Image = Image.FromFile(openFileDialog.FileName);
                    picEventImage.Tag = openFileDialog.FileName; // Store the file path or name for later use
                }
            }
        }
        private void LoadEventDetails(int eventId)
        {
            try
            {
                connection.Open();
                string query = "SELECT event_name, description, event_image FROM events WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", eventId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["event_name"].ToString();
                    txtDescript.Text = reader["description"].ToString();

                    // Load the image if it exists
                    if (reader["event_image"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["event_image"];
                        using (MemoryStream ms = new MemoryStream(imgBytes))
                        {
                            picEventImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picEventImage.Image = null; // No image
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading event details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
