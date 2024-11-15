using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace STIDiscover
{
    public partial class scheduleControl : UserControl
    {
        private Process oskProcess;
        private string connectionString = "Server=localhost;Database=schedules;Uid=root;Pwd=;";
        public scheduleControl()
        {
            InitializeComponent();
            InitializeDataGridView();
            this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
            textBoxSearch.Click += textBoxSearch_Click;
        }
        private void InitializeDataGridView()
        {
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCourseDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = textBoxSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                // Call method to perform live search and display results
                LiveSearch(searchQuery);
            }
            else
            {
                dgvResults.DataSource = null; // Clear DataGridView when search box is empty
            }

            if (!string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dgvResults.Visible = true;
            }
            else
            {
                dgvResults.Visible = false; // Hide DataGridView when TextBox is empty
            }
        }
        private void LiveSearch(string searchQuery)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get the list of table names dynamically
                    List<string> tableNames = GetTableNames(conn, searchQuery);

                    // Create a DataTable to hold table names
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Table Name");

                    // If no results are found, show a "No result found" message
                    if (tableNames.Count == 0)
                    {
                        DataRow row = dataTable.NewRow();
                        row["Table Name"] = "No result found";
                        dataTable.Rows.Add(row);
                    }
                    else
                    {
                        // Add matching table names to the DataTable
                        foreach (string tableName in tableNames)
                        {
                            DataRow row = dataTable.NewRow();
                            row["Table Name"] = tableName.ToUpper();  // Convert to uppercase before adding
                            dataTable.Rows.Add(row);
                        }
                    }

                    // Display the table names or the no result message in the DataGridView
                    dgvResults.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private List<string> GetTableNames(MySqlConnection conn, string searchQuery)
        {
            List<string> tableNames = new List<string>();

            // Retrieve all table names in the database and filter them
            string query = "SHOW TABLES";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string tableName = reader.GetString(0).ToUpper(); // Convert table name to uppercase
                                                                      // Perform case-insensitive comparison by converting both strings to lowercase
                    if (tableName.Contains(searchQuery.ToUpper())) // Make search query uppercase for case-insensitive comparison
                    {
                        tableNames.Add(tableName);
                    }
                }
            }

            return tableNames;
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            dgvResults.Visible = true;
            textBoxSearch.Text = "";
            textBoxSearch.ForeColor = Color.Black;
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {

            
        }

        private void dgvCourseDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void DisplayCourseDetails(string tableName)
        {
            try
            {
                Console.WriteLine($"Fetching details for table: {tableName}"); // Debugging log
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query the selected table for Course_des, Days, Time, and Room
                    string query = $"SELECT course_des, days, time, room FROM `{tableName}`";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Check if the table has data
                    if (dataTable.Rows.Count == 0)
                    {
                        Console.WriteLine("No data found in the selected table."); // Debugging log
                        MessageBox.Show("No data found for the selected course.");
                    }
                    else
                    {
                        // Bind the results to the second DataGridView (dgvCourseDetails)
                        dgvCourseDetails.DataSource = dataTable;
                        dgvCourseDetails.Visible = true; // Ensure it's visible
                        Console.WriteLine("Data loaded successfully."); // Debugging log
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Console.WriteLine($"Error: {ex.Message}");  // Debugging log
            }
        }

        private void dgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if the click is on a valid row
            {
                // Get the selected table name from the first column
                string selectedTable = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Call the method to load data from the selected table into the second DataGridView
                LoadCourseData(selectedTable);
            }
        }
        private void LoadCourseData(string tableName)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get course details (e.g., course_des, days, time, room) from the selected table
                    string query = $"SELECT course_des, days, time, room FROM {tableName}";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Create a DataTable to hold the course data
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader); // Load the data from the reader

                        // Set the DataSource of your second DataGridView to display course data
                        dgvCourseDetails.DataSource = dataTable;

                        // Disable row selection in dgvCourseData
                        dgvCourseDetails.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        dgvCourseDetails.MultiSelect = false;  // Optionally prevent multiple selection
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            StartOnScreenKeyboard();
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
    }
}
