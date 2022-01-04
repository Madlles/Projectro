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
    public partial class FormInformattionAdmin : Form
    {
        public FormInformattionAdmin()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
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

        private void FormInformattionAdmin_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            //Проверим количество выбранных строк
            if (bunifuCustomDataGrid1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = bunifuCustomDataGrid1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (bunifuCustomDataGrid1.Rows[index].Cells[0].Value == null ||
                bunifuCustomDataGrid1.Rows[index].Cells[1].Value == null ||
                bunifuCustomDataGrid1.Rows[index].Cells[2].Value == null ||
                bunifuCustomDataGrid1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString();
            string Con_ID = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
            string loc = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
            string Rper = bunifuCustomDataGrid1.Rows[index].Cells[3].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO DB VALUES (" + id + ", '" + Con_ID + "', '" + loc + "', '" + Rper + "')";//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = bunifuCustomDataGrid1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (bunifuCustomDataGrid1.Rows[index].Cells[0].Value == null ||
                bunifuCustomDataGrid1.Rows[index].Cells[1].Value == null ||
                bunifuCustomDataGrid1.Rows[index].Cells[2].Value == null ||
                bunifuCustomDataGrid1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString();
            string Con_ID = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
            string loc = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
            string Rper = bunifuCustomDataGrid1.Rows[index].Cells[3].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "UPDATE DB SET ID_Configyration='" + Con_ID + "',Location='" + loc + "',Responsible_Person='" + Rper + "' WHERE PC_ID=" + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            //Проверим количество выбранных строк
            if (bunifuCustomDataGrid1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = bunifuCustomDataGrid1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (bunifuCustomDataGrid1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = bunifuCustomDataGrid1.Rows[index].Cells[0].Value.ToString();

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
                bunifuCustomDataGrid1.Rows.RemoveAt(index);
            }

            //Закрываем соеденение с БД
            dbConnection.Close();
        }
    }
}
