using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Querymancer
{
    public partial class Querymancer_MainMenu : Form
    {
        // Database Connections
        OleDbConnection oleDbConnection = new OleDbConnection(Database.DatbaseString.ToString());

        public Querymancer_MainMenu()
        {
            InitializeComponent();
        }
        
        private void Querymancer_MainMenu_Load(object sender, EventArgs e)
        {
            ListTable();
        }

        private void ListTable()
        {
            // Connection Opened
            oleDbConnection.Open();

            // Instantiated Objects
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
            DataTable dataTable = new DataTable();

            // OleDb Command
            OleDbCommand listTableCommand = new OleDbCommand("Select * From Query_Table", oleDbConnection);

            // Command Setted To Adapter & Filled Into DataTable
            oleDbDataAdapter.SelectCommand = listTableCommand;
            oleDbDataAdapter.Fill(dataTable);

            // Sets The DataTable To DataGridView
            Query_DataGridView.DataSource = dataTable;

            // Connection Closed
            oleDbConnection.Close();
        }
    }
}
