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
using System.IO;

namespace Projector
{
    public partial class FormConfigyrationPC : Form
    {
        public FormConfigyrationPC()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.Rows.Clear();

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM ConfigyrationPC";
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
                    bunifuCustomDataGrid1.Rows.Add(dbReader["ID_Configyration"], dbReader["Component_Type"], dbReader["Model"], dbReader["Manufacturer"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void FormConfigyrationPC_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Rows.Clear();
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT * FROM ConfigyrationPC WHERE ID_Configyration ={bunifuMaterialTextbox1.Text}";
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
                    bunifuCustomDataGrid1.Rows.Add(dbReader["ID_Configyration"], dbReader["Component_Type"], dbReader["Model"], dbReader["Manufacturer"]);
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
            string query = "SELECT * FROM ConfigyrationPC";
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
                    bunifuCustomDataGrid1.Rows.Add(dbReader["ID_Configyration"], dbReader["Component_Type"], dbReader["Model"], dbReader["Manufacturer"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
