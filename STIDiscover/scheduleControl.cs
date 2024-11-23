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
        private Process onScreenKeyboardProc;
        private string connectionString = "Server=localhost;Database=schedules;Uid=root;Pwd=;";
        public scheduleControl()
        {
            InitializeComponent();
            InitializeDataGridView();
            this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
            textBoxSearch.Click += textBoxSearch_Click;
            textBoxSearch.Enter += new EventHandler(OpenKeyboard);
            textBoxSearch.TextChanged += new EventHandler(textBoxSearch_TextChanged);
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

                    // Query to fetch and sort data by `days` (Monday to Sunday) and `time`
                    string query = $@"
                SELECT course_des, days, time, room 
                FROM `{tableName}` 
                ORDER BY 
                CASE 
                    WHEN LOWER(days) = 'monday' THEN 1
                    WHEN LOWER(days) = 'tuesday' THEN 2
                    WHEN LOWER(days) = 'wednesday' THEN 3
                    WHEN LOWER(days) = 'thursday' THEN 4
                    WHEN LOWER(days) = 'friday' THEN 5
                    WHEN LOWER(days) = 'saturday' THEN 6
                    WHEN LOWER(days) = 'sunday' THEN 7
                    ELSE 8 -- For any unexpected values
                END, 
                STR_TO_DATE(time, '%h:%i %p') ASC"; // Sort by time in ascending order

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader()) // Use MySqlDataReader directly
                    {
                        // Create a DataTable to hold the course data
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader); // Load the data from the reader

                        // Set the DataSource of dgvCourseDetails to display course data
                        dgvCourseDetails.DataSource = dataTable;

                        // Set custom column headers
                        dgvCourseDetails.Columns[0].HeaderText = "Course Description";
                        dgvCourseDetails.Columns[1].HeaderText = "Days";
                        dgvCourseDetails.Columns[2].HeaderText = "Time";
                        dgvCourseDetails.Columns[3].HeaderText = "Room";

                        // Disable row selection in dgvCourseDetails
                        dgvCourseDetails.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        dgvCourseDetails.MultiSelect = false; // Optionally prevent multiple selection
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
            dgvResults.Visible = true;
            textBoxSearch.Text = "";
            textBoxSearch.ForeColor = Color.Black;
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


        private void btnGetHelp_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Hide();
            GetHelp getHelp = new GetHelp();
            getHelp.Show();
        }
    }
}
