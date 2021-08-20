using System;
using System.Data;
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

        private void QueryTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (QueryTextBox.Text == "  Enter Query:")
            {
                QueryTextBox.Clear();
            }
        }
        private void Minimize_PictureBox_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Exit_PictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExecuteSQLQuery_Button_Click(object sender, EventArgs e)
        {
            try
            {
                oleDbConnection.Open();
                OleDbCommand clientQuery = new OleDbCommand(QueryTextBox.Text, oleDbConnection);
                clientQuery.ExecuteNonQuery();
                oleDbConnection.Close();

                ListTable();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            if (oleDbConnection.State == ConnectionState.Open)
            {
                oleDbConnection.Close();
            }
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
