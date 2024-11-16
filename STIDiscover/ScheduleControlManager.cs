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
    public partial class ScheduleControlManager : UserControl
    {
        private string currentTableName = "";
        private string connectionString = "Server=localhost;Database=schedules;Uid=root;Pwd=;";
        public ScheduleControlManager()
        {
            InitializeComponent();
            InitializeDataGridView();
            this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
            textBoxSearch.Click += textBoxSearch_Click;
        }

        private void ScheduleControlManager_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataGridView()
        {
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCourseDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourseDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourseDetails.ReadOnly = false; // Allow typing in cells
            dgvCourseDetails.AllowUserToAddRows = false; // Prevent adding new rows manually
            dgvCourseDetails.AllowUserToDeleteRows = false; // Prevent deleting rows manually
            dgvCourseDetails.SelectionMode = DataGridViewSelectionMode.CellSelect; // Allow cell selection
            dgvCourseDetails.MultiSelect = false; // Single cell selection
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

        private void textBoxSearch_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            dgvResults.Visible = true;
            textBoxSearch.Text = "";
            textBoxSearch.ForeColor = Color.Black;
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
            currentTableName = tableName; // Store the table name for future updates
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to get course details, including `id` as a hidden unique identifier
                    string query = $"SELECT id, course_des, days, time, room FROM `{tableName}`";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Create a DataTable to hold the course data
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader); // Load the data from the reader

                        // Set the DataSource of your second DataGridView to display course data
                        dgvCourseDetails.DataSource = dataTable;

                        // Hide the `id` column
                        dgvCourseDetails.Columns["id"].Visible = false;

                        // Make all other columns editable
                        foreach (DataGridViewColumn column in dgvCourseDetails.Columns)
                        {
                            if (column.Name != "id") // Keep `id` non-editable
                            {
                                column.ReadOnly = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dgvCourseDetails.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int id = Convert.ToInt32(row.Cells["id"].Value);
                            string courseDes = row.Cells["course_des"].Value?.ToString();
                            string days = row.Cells["days"].Value?.ToString();
                            string time = row.Cells["time"].Value?.ToString();
                            string room = row.Cells["room"].Value?.ToString();

                            string query = $@"
                        UPDATE `{currentTableName}` 
                        SET `course_des` = @course_des, `days` = @days, `time` = @time, `room` = @room 
                        WHERE `id` = @id";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@course_des", courseDes);
                                cmd.Parameters.AddWithValue("@days", days);
                                cmd.Parameters.AddWithValue("@time", time);
                                cmd.Parameters.AddWithValue("@room", room);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Reload the updated data
                    LoadCourseData(currentTableName);

                    MessageBox.Show("Database updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTableName))
            {
                LoadCourseData(currentTableName); // Reload data for the currently selected table
            }
        }
    }
}
