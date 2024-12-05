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
            string query = "SELECT id, event_name, description, event_image FROM events WHERE event_date = @date";

            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=event_schedule;Uid=root;Pwd=;"))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            lstEvents.Items.Clear(); // Clear the list before adding new items

                            while (reader.Read())
                            {
                                lstEvents.Items.Add(new ListBoxItem
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    Name = reader["event_name"].ToString()
                                });
                            }
                        }
                    }

                    if (lstEvents.Items.Count > 0)
                    {
                        lblInfo.Text = "Select an event to view details.";
                    }
                    else
                    {
                        lblInfo.Text = "No events found for the selected date.";
                        ClearEventDetails(); // Clear textboxes and image
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading events: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearEventDetails()
        {
            txtName.Clear();
            txtDescript.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpEvent.Value.Date;
            DateTime currentDate = DateTime.Now.Date;
            DateTime minDate = currentDate.AddDays(5); // Minimum allowed date is 5 days from today

            // Validation to allow only dates 5 days or later from today
            if (selectedDate <= currentDate || selectedDate < minDate)
            {
                MessageBox.Show("You can only add event 5 days prior before the event.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearEventDetails();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDescript.Text))
            {
                MessageBox.Show("Please enter both the event name and description.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO events (event_date, event_name, description, event_image) VALUES (@date, @name, @description, @image)";

            using (MySqlConnection conn = new MySqlConnection("Server=localhost;Database=event_schedule;Uid=root;Pwd=;"))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@description", txtDescript.Text);

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
                        MessageBox.Show("Event added successfully!");
                        txtDescript.Clear();
                        txtName.Clear();
                        picEventImage = null;
                        ShowEventInfo(selectedDate); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem == null)
            {
                MessageBox.Show("Please select an event to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = lstEvents.SelectedItem as ListBoxItem;
            if (selectedItem == null || selectedItem.Id == 0)
            {
                MessageBox.Show("Invalid event selection. Please select a valid event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int eventId = selectedItem.Id;
            // Proceed to delete using the eventId
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "DELETE FROM events WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", eventId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Event deleted successfully!");
                txtDescript.Clear();
                txtName.Clear();
                picEventImage = null;
                ShowEventInfo(dtpEvent.Value); // Refresh list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        private void txtName_Click(object sender, EventArgs e)
        {
            OpenTabTip();
        }
        private void txtName_Leave(object sender, EventArgs e)
        {
            OpenTabTip();
        }

        private void txtDescript_Click(object sender, EventArgs e)
        {
            OpenTabTip();
        }

        private void txtDescript_Leave(object sender, EventArgs e)
        {
            OpenTabTip();
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedItem is ListBoxItem selectedItem)
            {
                LoadEventDetails(selectedItem.Id); // Load the event details for the selected event
            }
            else
            {
                ClearEventDetails(); // Clear if no selection
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
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No Image to this event", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            OpenTabTip();
        }
        private void OpenTabTip()
        {
            try
            {
                Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open TabTip: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescript_Enter(object sender, EventArgs e)
        {
            OpenTabTip();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowEventInfo(dtpEvent.Value);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
public class ListBoxItem
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return Name; // This controls what is displayed in the ListBox
    }
}

