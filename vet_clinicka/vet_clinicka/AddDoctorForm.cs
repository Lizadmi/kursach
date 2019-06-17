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
    public partial class AddDoctorForm : Form
    {
        public AddDoctorForm()
        {
            InitializeComponent();
        }

        public int id_doc;
        public string surname;
        public string name;
        public string phone;
        public string password;
        public string id_post;
        public string post;
        public string query_for_doctor;
        public string query_for_user;
        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=12345;database=vet_clinicka");

        private void AddDoctorForm_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT max(id_doctor)+111 FROM vet_clinicka.doctor ", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
            }
            reader.Close();
            MySqlDataAdapter sda_post = new MySqlDataAdapter("SELECT post FROM vet_clinicka.post ", connection);
            DataTable tbl_post = new DataTable();
            sda_post.Fill(tbl_post);
            for (int i = 0; i < tbl_post.Rows.Count; i++)
            {
                comboBox1.Items.Add(tbl_post.Rows[i][0].ToString());
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            id_doc = Convert.ToInt32(textBox1.Text);
            surname = textBox2.Text.ToString();
            name = textBox3.Text.ToString();
            phone = textBox6.Text.ToString();
            password = textBox5.Text.ToString();
            id_post = textBox4.Text.ToString();

            try
            {
                connection.Open();
                string id="";
                MySqlCommand command_id = new MySqlCommand("select max(id)+1 from user ", connection);
                MySqlDataReader reader = command_id.ExecuteReader();
                while (reader.Read())
                {
                    id = reader[0].ToString();
                }
                reader.Close();
                query_for_doctor = $"insert into vet_clinicka.doctor values ({id_doc},'{surname}','{name}',{id_post},'{post}','{phone}')";
                query_for_user = $"insert into vet_clinicka.user values ({id},{id_doc},'{password}')";
                MessageBox.Show(query_for_doctor);
                MessageBox.Show(query_for_user);
                MySqlCommand command = new MySqlCommand(query_for_doctor, connection);
                command.ExecuteNonQuery();
                MySqlCommand command2 = new MySqlCommand(query_for_user, connection);
                command2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Запись добавлена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            Hide();
            adminForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            post = comboBox1.SelectedItem.ToString();
            connection.Open();
            MySqlCommand command = new MySqlCommand($"SELECT id_post FROM vet_clinicka.post where post='{post}' ", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox4.Text = reader[0].ToString();
            }
            reader.Close();
            connection.Close();
        }

        private void AddDoctorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
