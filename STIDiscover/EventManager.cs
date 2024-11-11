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
using MySql.Data.MySqlClient;

namespace STIDiscover
{
    public partial class EventManager : UserControl
    {
        private Process onScreenKeyboardProc;
        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=event_schedule;Uid=root;Pwd=;");
        public EventManager()
        {
            InitializeComponent();
            txtName.Enter += new EventHandler(OpenKeyboard);
            txtDescript.Enter += new EventHandler(OpenKeyboard);
            dtpEvent.ValueChanged += dtpEvent_ValueChanged;
        }

        private void EventManager_Load(object sender, EventArgs e)
        {

        }
        private void OpenKeyboard(object sender, EventArgs e)
        {
            // Close any open instances of the on-screen keyboard
            Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
            foreach (Process oskProcess in oskProcessArray)
            {
                oskProcess.Kill();
            }

            // Open the on-screen keyboard
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string onScreenKeyboardPath = System.IO.Path.Combine(progFiles, "TabTip.exe");
            onScreenKeyboardProc = System.Diagnostics.Process.Start(onScreenKeyboardPath);
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
    }
}
