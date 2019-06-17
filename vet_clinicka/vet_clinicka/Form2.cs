using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace vet_clinicka
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            connection.Open();
        }
        public string login;
        public string password;
        public string id = "";
        public bool check = false;

        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=12345;database=vet_clinicka");


        private void btn_entry_Click(object sender, EventArgs e)
        {

            login = textBox1.Text.ToString();
            password = textBox2.Text.ToString();
            MySqlCommand command = new MySqlCommand("SELECT * FROM vet_clinicka.user ", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[1].ToString() == login && reader[2].ToString() == password)
                {
                    check = true;
                    id = Convert.ToString(reader[1]);
                    break;
                }

            }
            reader.Close();
            if (check)
            {
                MessageBox.Show("Вход выполнен!");
                if (id == "admin")
                {
                    connection.Close();
                    Hide();
                    AdminForm form1 = new AdminForm();
                    form1.Show();
                }
                else
                {
                    connection.Close();
                    Hide();
                    UsersForm form2 = new UsersForm(id);
                    form2.Show();
                    
                }

            }
            else MessageBox.Show("Неверный логин или пароль!");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else textBox2.UseSystemPasswordChar = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

