using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OfficeOpenXml;

namespace STIDiscover
{
    public partial class ScheduleControlManager : UserControl
    {
        private Process onScreenKeyboardProc;
        private string currentTableName = "";
        private string connectionString = "Server=localhost;Database=schedules;Uid=root;Pwd=;";
        public ScheduleControlManager()
        {
            InitializeComponent();
            InitializeDataGridView();
            this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
            textBoxSearch.Click += textBoxSearch_Click;
            textBoxSearch.Enter += new EventHandler(OpenKeyboard);
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

                    string query = $@"
                SELECT id, course_des, days, time, room 
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
                    ELSE 8
                END, 
                STR_TO_DATE(time, '%h:%i %p') ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        dgvCourseDetails.DataSource = dataTable;

                        // Hide the `id` column
                        dgvCourseDetails.Columns["id"].Visible = false;

                        // Set custom column headers
                        dgvCourseDetails.Columns["course_des"].HeaderText = "Course Description";
                        dgvCourseDetails.Columns["days"].HeaderText = "Days";
                        dgvCourseDetails.Columns["time"].HeaderText = "Time";
                        dgvCourseDetails.Columns["room"].HeaderText = "Room";

                        // Make columns editable except for `id`
                        foreach (DataGridViewColumn column in dgvCourseDetails.Columns)
                        {
                            column.ReadOnly = column.Name == "id";
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

        private void btnUploadExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Before uploading, make sure to arrange data based on the SQL structure:\n\n" +
                   "Columns: course_des, days, time, room",
                   "Upload Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Open file dialog to select the Excel file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    UploadSchedule(filePath); // Call method to process and upload
                }
            }
        }
        private void UploadSchedule(string filePath)
        {
            try
            {
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Step 1: Read the Excel file
                using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    // Extract the table name from the file name (remove the extension and spaces, convert to lowercase)
                    string tableName = Path.GetFileNameWithoutExtension(filePath).Trim().Replace(" ", "_").ToLower();

                    // Validate column structure based on the Excel headers
                    var expectedColumns = new[] { "course_des", "days", "time", "room" };
                    int colCount = worksheet.Dimension.Columns;
                    for (int col = 1; col <= colCount; col++)
                    {
                        string headerText = worksheet.Cells[1, col].Text.ToLower();
                        if (!expectedColumns.Contains(headerText))
                        {
                            MessageBox.Show($"Column mismatch at position {col}. Expected one of {string.Join(", ", expectedColumns)}. Found: {headerText}",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Step 2: Create the table in the database using the extracted table name
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string createTableQuery = $@"
                CREATE TABLE `{tableName}` (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    course_des VARCHAR(255) NULL,
                    days VARCHAR(50) NULL,
                    time VARCHAR(50) NULL,
                    room VARCHAR(100) NULL
                );";

                        using (MySqlCommand createCmd = new MySqlCommand(createTableQuery, conn))
                        {
                            createCmd.ExecuteNonQuery();
                        }

                        // Step 3: Insert the data into the newly created table
                        int rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++) // Start from row 2 (skip header row)
                        {
                            string courseDes = worksheet.Cells[row, 1].Text.Trim();
                            string days = worksheet.Cells[row, 2].Text.Trim();
                            string time = worksheet.Cells[row, 3].Text.Trim();
                            string room = worksheet.Cells[row, 4].Text.Trim();

                            string insertQuery = $@"
                    INSERT INTO `{tableName}` (course_des, days, time, room) 
                    VALUES (@courseDes, @days, @time, @room);";

                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@courseDes", courseDes);
                                insertCmd.Parameters.AddWithValue("@days", days);
                                insertCmd.Parameters.AddWithValue("@time", time);
                                insertCmd.Parameters.AddWithValue("@room", room);

                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Schedule uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
