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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        async private void Login_Load_1(object sender, EventArgs e)
        {
            for (Opacity = 0; Opacity < 1; Opacity += 0.01)
                await Task.Delay(1);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       async private void guna2CustomGradientPanel1_MouseEnter(object sender, EventArgs e)
        {
            while (guna2CustomGradientPanel1.Location.Y != 137)
            {
                await Task.Delay(1);
                guna2CustomGradientPanel1.Location = new Point(guna2CustomGradientPanel1.Location.X, guna2CustomGradientPanel1.Location.Y + (50 - guna2CustomGradientPanel1.Location.Y) / 20);
                if (guna2CustomGradientPanel1.Location.Y <= 137)
                {
                    guna2CustomGradientPanel1.Location = new Point(guna2CustomGradientPanel1.Location.X, 137);
                }
            }
        }

       async private void panel4_MouseEnter(object sender, EventArgs e)
        {
            while (guna2CustomGradientPanel1.Location.Y != 370)
            {
                await Task.Delay(1);
                guna2CustomGradientPanel1.Location = new Point(guna2CustomGradientPanel1.Location.X, guna2CustomGradientPanel1.Location.Y - (50 - guna2CustomGradientPanel1.Location.Y) / 20);
                if (guna2CustomGradientPanel1.Location.Y >= 370)
                {
                    guna2CustomGradientPanel1.Location = new Point(guna2CustomGradientPanel1.Location.X, 370);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обратитесь к заведующей!");
        }

        private void bunifuImageButton1_MouseClick(object sender, MouseEventArgs e)
        {
            if(bunifuMaterialTextbox3.isPassword == true)
            {
                bunifuMaterialTextbox3.isPassword = false;
            }

            else if(bunifuMaterialTextbox3.isPassword == false)
                {
                    bunifuMaterialTextbox3.isPassword = true;
                }
            
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox5.isPassword == true)
            {
                bunifuMaterialTextbox5.isPassword = false;
            }

            else if (bunifuMaterialTextbox5.isPassword == false)
            {
                bunifuMaterialTextbox5.isPassword = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string admin = "admin";
            string adminPass = "admin";

            var log = Convert.ToString(bunifuMaterialTextbox2.Text);

            var pas = Convert.ToString(bunifuMaterialTextbox3.Text);


            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=AYTH.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);


            OleDbCommand MyOleDbComm2 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm2.CommandText = "Select Login from LogPas " +
                                       " Where LogPas.Login='" + bunifuMaterialTextbox2.Text + "'";
            MyOleDbComm2.Connection = dbConnection;

            var result = MyOleDbComm2.ExecuteScalar();

            dbConnection.Close();

            OleDbCommand MyOleDbComm1 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm1.CommandText = "Select Password from LogPas " +
                                       " Where LogPas.Password='" + bunifuMaterialTextbox3.Text + "'";
            MyOleDbComm1.Connection = dbConnection;

            var result1 = MyOleDbComm1.ExecuteScalar();

            dbConnection.Close();

            if (log == admin && pas == adminPass)
            {

            }

            else if (result == null && result1 == null || result == null || result1 == null)
            {
                MessageBox.Show("Данные введены не верно!");

            }

            else
            {
                MessageBox.Show($"Добро пожаловать,{result}!");
                Worker wk = new Worker();
                wk.Owner = this; //Передаём вновь созданной форме её владельца.
                wk.Show();
                Hide();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(bunifuMaterialTextbox1.Text);
                string login = Convert.ToString(bunifuMaterialTextbox4.Text);
                string password = Convert.ToString(bunifuMaterialTextbox5.Text);
                string mail = Convert.ToString(bunifuMaterialTextbox6.Text);


                Regex reg = new Regex(@"\b[^_+.+][-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}\b", RegexOptions.IgnoreCase);
                MatchCollection mc = reg.Matches(mail);

                string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=AYTH.mdb";//строка соеденения
                OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение


                OleDbCommand MyOleDbComm2 = new OleDbCommand();
                dbConnection.Open();

                MyOleDbComm2.CommandText = "Select Login from LogPas " +
                                           " Where LogPas.Login='" + bunifuMaterialTextbox4.Text + "'";
                MyOleDbComm2.Connection = dbConnection;

                var result = MyOleDbComm2.ExecuteScalar();

                dbConnection.Close();

                OleDbCommand MyOleDbComm1 = new OleDbCommand();
                dbConnection.Open();

                MyOleDbComm1.CommandText = "Select Password from LogPas " +
                                           " Where LogPas.Password='" + bunifuMaterialTextbox5.Text + "'";
                MyOleDbComm1.Connection = dbConnection;

                var result1 = MyOleDbComm1.ExecuteScalar();

                dbConnection.Close();


                if (mc.Count > 0 && result == null && result1 == null && login != "admin" && password != "admin")
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
