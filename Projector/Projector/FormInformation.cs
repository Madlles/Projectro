using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Projector
{
    public partial class FormInformation : Form
    {
        public FormInformation()
        {
            InitializeComponent();
        }

        async private void FormInformation_Load(object sender, EventArgs e)
        {

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM DB";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(dbReader["PC_ID"], dbReader["ID_Configyration"], dbReader["Location"], dbReader["Responsible_Person"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Clear();
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT * FROM DB WHERE PC_ID ={bunifuMaterialTextbox1.Text}";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(dbReader["PC_ID"], dbReader["ID_Configyration"], dbReader["Location"], dbReader["Responsible_Person"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Clear();
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM DB";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (dbReader.Read())
                {
                    bunifuCustomDataGrid1.Rows.Add(dbReader["PC_ID"], dbReader["ID_Configyration"], dbReader["Location"], dbReader["Responsible_Person"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
