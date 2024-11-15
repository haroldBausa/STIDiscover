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
            connection.Open();
            string query = "SELECT event_name, description FROM events WHERE event_date = @date";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblInfo.Text = $"Event: {reader["event_name"]}\nDescription: {reader["description"]}";
            }
            else
            {
                lblInfo.Text = "No event scheduled on this date.";
            }
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO events (event_date, event_name, description) VALUES (@date, @name, @description)";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@date", dtpEvent.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@description", txtDescript.Text);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Event added successfully!");
            ShowEventInfo(dtpEvent.Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "UPDATE events SET event_name = @name, description = @description WHERE event_date = @date";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@date", dtpEvent.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@description", txtDescript.Text);
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(rowsAffected > 0 ? "Event updated successfully!" : "No event found on this date.");
            ShowEventInfo(dtpEvent.Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "DELETE FROM events WHERE event_date = @date";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@date", dtpEvent.Value.ToString("yyyy-MM-dd"));
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(rowsAffected > 0 ? "Event deleted successfully!" : "No event found on this date.");
            ShowEventInfo(dtpEvent.Value);
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

        
    }
}
