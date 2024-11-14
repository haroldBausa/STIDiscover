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
    public partial class scheduleControl : UserControl
    {
        private string connectionString = "Server=localhost;Database=schedules;Uid=root;Pwd=;";
        public scheduleControl()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                    // Add matching table names to the DataTable
                    foreach (string tableName in tableNames)
                    {
                        DataRow row = dataTable.NewRow();
                        row["Table Name"] = tableName;
                        dataTable.Rows.Add(row);
                    }

                    // Display the table names in the DataGridView
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
                    string tableName = reader.GetString(0);
                    // Perform case-insensitive comparison by converting both strings to lowercase
                    if (tableName.ToLower().Contains(searchQuery.ToLower()))
                    {
                        tableNames.Add(tableName);
                    }
                }
            }

            return tableNames;
        }
    }
}
