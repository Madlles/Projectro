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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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
                    dataGridView1.Rows.Add(dbReader["PC_ID"], dbReader["ID_Configyration"], dbReader["Location"], dbReader["Responsible_Person"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string number = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string location = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string responsible = dataGridView1.Rows[index].Cells[3].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO DB VALUES (" + id + ", " + location + ", '" + responsible + "', '" + number + "')";//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            //Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string number = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string location = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string responsible = dataGridView1.Rows[index].Cells[3].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "UPDATE DB SET Location='" + location + "',Responsible_Person='" + responsible + "',ID_Configyration=" + number + " WHERE PC_ID = " + id;//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //Проверим количество выбранных строк
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "DELETE FROM DB WHERE PC_ID = " + id;//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные удалены!", "Внимание!");
                //Удаляем данные из таблицы в форме
                dataGridView1.Rows.RemoveAt(index);
            }

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        }
    }
}
