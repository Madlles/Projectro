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
    public partial class FormConfigyrationPCAdmin : Form
    {
        public FormConfigyrationPCAdmin()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
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

        private void FormConfigyrationPCAdmin_Load(object sender, EventArgs e)
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
            string type = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
            string model = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
            string manufacture = bunifuCustomDataGrid1.Rows[index].Cells[3].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "INSERT INTO ConfigyrationPC VALUES (" + id + ", '" + type + "', '" + model + "', '" + manufacture + "')";//строка запроса
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
            string type = bunifuCustomDataGrid1.Rows[index].Cells[1].Value.ToString();
            string model = bunifuCustomDataGrid1.Rows[index].Cells[2].Value.ToString();
            string manufacture = bunifuCustomDataGrid1.Rows[index].Cells[3].Value.ToString();

            //Создаем соеденение
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=SystemDataBase.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "UPDATE ConfigyrationPC SET Component_Type='" + type + "',Model='" + model + "',Manufacturer='" + manufacture + "' WHERE ID_Configyration=" + id;
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
            string query = "DELETE FROM ConfigyrationPC WHERE ID_Configyration = " + id;//строка запроса
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
