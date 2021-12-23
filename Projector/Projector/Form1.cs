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
using System.Text.RegularExpressions;

namespace Projector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Mouseenter(object sender, EventArgs e)
        {
            
        }
        
        private void MouseLeave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string admin = "admin";
            string adminPass = "admin";

            string login = "";
            string password = "";

            int check = 0;

            var log = Convert.ToString(textBox2.Text);

            var pas = Convert.ToString(textBox1.Text);


            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=AYTH.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);


            OleDbCommand MyOleDbComm2 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm2.CommandText = "Select Login from LogPas " +
                                       " Where LogPas.Login='" + textBox2.Text + "'";
            MyOleDbComm2.Connection = dbConnection;

            var result = MyOleDbComm2.ExecuteScalar();

            dbConnection.Close();

            OleDbCommand MyOleDbComm1 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm1.CommandText = "Select Password from LogPas " +
                                       " Where LogPas.Password='" + textBox1.Text + "'";
            MyOleDbComm1.Connection = dbConnection;

            var result1 = MyOleDbComm1.ExecuteScalar();

            dbConnection.Close();

            if (result == null && result1 == null || result == null || result1 == null)
            {
                MessageBox.Show("Данные введены не верно!");
                
            }
                
            else
            {
                MessageBox.Show($"Добро пожаловать,{result}!");
                Form2 frm2 = new Form2();
                frm2.Owner = this; //Передаём вновь созданной форме её владельца.
                frm2.Show();
                Hide();
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            while(panel1.Location.X != 258)
            {
                panel1.Location = new Point(panel1.Location.X - 30, panel1.Location.Y);
                if(panel1.Location.X <= 258 )
                {
                    panel1.Location = new Point(258, panel1.Location.Y);
                }
            }
                
           
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            while (panel1.Location.X != 659)
            {
                panel1.Location = new Point(panel1.Location.X + 30, panel1.Location.Y);
                if (panel1.Location.X >= 659)
                {
                    panel1.Location = new Point(659, panel1.Location.Y);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string mail = Convert.ToString(textBox5.Text);

                string login = Convert.ToString(textBox3.Text);

                string password = Convert.ToString(textBox4.Text);

                int id = Convert.ToInt32(textBox6.Text);

                Regex reg = new Regex(@"\b[^_+.+][-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}\b", RegexOptions.IgnoreCase);
                MatchCollection mc = reg.Matches(mail);

                string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=AYTH.mdb";//строка соеденения
                OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение


                OleDbCommand MyOleDbComm2 = new OleDbCommand();
                dbConnection.Open();

                MyOleDbComm2.CommandText = "Select Login from LogPas " +
                                           " Where LogPas.Login='" + textBox3.Text + "'";
                MyOleDbComm2.Connection = dbConnection;

                var result = MyOleDbComm2.ExecuteScalar();

                dbConnection.Close();

                OleDbCommand MyOleDbComm1 = new OleDbCommand();
                dbConnection.Open();

                MyOleDbComm1.CommandText = "Select Password from LogPas " +
                                           " Where LogPas.Password='" + textBox4.Text + "'";
                MyOleDbComm1.Connection = dbConnection;

                var result1 = MyOleDbComm1.ExecuteScalar();

                dbConnection.Close();


                if (mc.Count > 0 && result == null && result1 == null)
                {

                    dbConnection.Open();//открываем соеденение
                    string query = "INSERT INTO LogPas VALUES (" + id + ", '" + login + "', '" + password + "', '" + mail + "')";//строка запроса
                    OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

                    //Выполняем запрос
                    if (dbCommand.ExecuteNonQuery() != 1)
                        MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
                    else
                        MessageBox.Show("Данные добавлены!", "Внимание!");

                    //Закрываем соеденение с БД
                    dbConnection.Close();

                }

                else
                {
                    MessageBox.Show("Данные введен не верно или такой пользователь уже существует!");

                }
            }
            catch
            {
                MessageBox.Show("Ошибка, заполните все поля!.");
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }

          
}
