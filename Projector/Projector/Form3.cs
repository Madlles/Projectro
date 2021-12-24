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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

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
                    dataGridView1.Rows.Add(dbReader["ID_Configyration"], dbReader["Component_Type"], dbReader["Model"], dbReader["Manufacturer"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = $"SELECT * FROM ConfigyrationPC WHERE ID_Configyration ={textBox1.Text}";
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
                    dataGridView1.Rows.Add(dbReader["ID_Configyration"], dbReader["Component_Type"], dbReader["Model"], dbReader["Manufacturer"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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
                    dataGridView1.Rows.Add(dbReader["ID_Configyration"], dbReader["Component_Type"], dbReader["Model"], dbReader["Manufacturer"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();

        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Owner = this;
            frm1.Show();
            Hide();
        }

        private void конфигурацияПКToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Owner = this;
            frm3.Show();
            Hide();
        }

        private void главноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Owner = this;
            frm2.Show();
            Hide();
        }

        async private void Form3_Load(object sender, EventArgs e)
        {
            for (Opacity = 0; Opacity < 1; Opacity += 0.01)
                await Task.Delay(1);
        }
    }
    
}
