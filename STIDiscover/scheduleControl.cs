
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
            InitializeControlEvents();
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
            dgvResults.Visible = !string.IsNullOrEmpty(textBoxSearch.Text);

            if (string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dgvResults.DataSource = null;
                dgvResults.Rows.Clear();
                label1.Text = "Start typing to search...";
                dgvResults.CellClick -= dgvResults_CellClick; // Detach event
                return;
            }

            dgvResults.CellClick += dgvResults_CellClick; // Attach event
            LiveSearch(textBoxSearch.Text.Trim());
        }


        private void LiveSearch(string searchQuery)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Get matching table names
                    List<string> tableNames = GetTableNames(conn, searchQuery);

                    // Clear the DataGridView if no results
                    if (tableNames.Count == 0)
                    {
                        dgvResults.DataSource = null; // Clear DataSource
                        dgvResults.Rows.Clear(); // Clear rows
                        label1.Text = "No result found.";
                        return;
                    }

                    // Populate the DataGridView with results
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Table Name");

                    foreach (string tableName in tableNames)
                    {
                        dataTable.Rows.Add(tableName.ToUpper());
                    }

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

            CloseKeyboard();
        }

        private void dgvCourseDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CloseKeyboard();
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
                        Console.WriteLine("Data loaded successfully."); 
                        label1.Text =  tableName;
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
            // Ensure the clicked row is valid
            if (e.RowIndex >= 0 && dgvResults.Rows[e.RowIndex].Cells[0].Value != null)
            {
                string selectedTable = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (string.IsNullOrWhiteSpace(selectedTable) ||
                    selectedTable.Equals("No result found", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No valid table selected.");
                    return;
                }

                label1.Text = selectedTable; // Update the label
                dgvResults.Visible = false; // Hide the DataGridView
                DisplayCourseDetails(selectedTable); // Load data
            }
        }



        private void LoadCourseData(string tableName)
        {
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

                // Clear selection after binding the data source
                dgvCourseDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            textBoxSearch.ForeColor = Color.Black;
        }

        private void OpenKeyboard(object sender, EventArgs e)
        {
            try
            {
                Process[] oskProcessArray = Process.GetProcessesByName("TabTip");
                foreach (Process oskProcess in oskProcessArray)
                {
                    oskProcess.Kill();
                }

                string onScreenKeyboardPath = Environment.ExpandEnvironmentVariables(@"%ProgramFiles%\Common Files\Microsoft Shared\ink\TabTip.exe");

                if (File.Exists(onScreenKeyboardPath))
                {
                    onScreenKeyboardProc = Process.Start(onScreenKeyboardPath);
                }
                else
                {
                    MessageBox.Show("On-screen keyboard not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open the keyboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CloseKeyboard()
        {
            try
            {
                // Search for the TabTip.exe process
                foreach (var process in System.Diagnostics.Process.GetProcessesByName("TabTip"))
                {
                    process.Kill(); // Forcefully close the process
                }
            }
            catch (Exception ex)
            {
                
            }
        }


       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ScreenShot.ShowWithScreenshot();
        }

        private void dgvResults_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if the click is on a valid row
            {
                // Get the selected table name from the first column
                string selectedTable = dgvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Call the method to load data from the selected table into the second DataGridView
                LoadCourseData(selectedTable);
                
            }
        }

        private void scheduleControl_Click(object sender, EventArgs e)
        {
            CloseKeyboard();
        }
        private void InitializeControlEvents()
        {
            // Attach the Leave event to the TextBox
            textBoxSearch.Leave += textBoxSearch_Leave;

            // Attach the Click event to the UserControl (or Form)
            this.Click += scheduleControl_Click;
            dgvResults.CellClick += dgvResults_CellClick;
           
        }

        private void dgvResults_Click(object sender, EventArgs e)
        {
            CloseKeyboard();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBoxSearch.Text.ToLower() == "stidiscoveradmin")
            {
                Form1 form = new Form1();
                form.Dispose();
                // Open AdminLoginForm when "stidiscover admin" is typed and enter key is pressed
                AdminLoginForm adminForm = new AdminLoginForm();
                adminForm.Show();
                textBoxSearch.Clear(); // Clear the search box after pressing Enter
            }
        }
    }
}
