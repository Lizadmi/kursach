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
    public partial class ReceptionsForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=12345;database=vet_clinicka");
        public string id;
        public string id_reception;
        public string id_pets;
        public string pets;
        public string id_doctor;
        public string id_service;
        public string data;
        public ReceptionsForm(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ReceptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }


        private void ReceptionsForm_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlDataAdapter sda_owner = new MySqlDataAdapter("SELECT surname,name FROM vet_clinicka.owner ", connection);
            DataTable tbl_owner = new DataTable();
            sda_owner.Fill(tbl_owner);
            for (int i = 0; i < tbl_owner.Rows.Count; i++)
            {
                comboBox_owner.Items.Add(tbl_owner.Rows[i][0].ToString() + " " + tbl_owner.Rows[i][1].ToString());
            }
            MySqlDataAdapter sda_doctor = new MySqlDataAdapter("SELECT surname,name FROM vet_clinicka.doctor ", connection);
            DataTable tbl_doctor = new DataTable();
            sda_doctor.Fill(tbl_doctor);
            for (int i = 0; i < tbl_doctor.Rows.Count; i++)
            {
                comboBox_doctor.Items.Add(tbl_doctor.Rows[i][0].ToString() + " " + tbl_doctor.Rows[i][1].ToString());
            }
            MySqlDataAdapter sda_service = new MySqlDataAdapter("SELECT name_service FROM vet_clinicka.prays_list ", connection);
            DataTable tbl_service = new DataTable();
            sda_service.Fill(tbl_service);
            for (int i = 0; i < tbl_service.Rows.Count; i++)
            {
                comboBox_service.Items.Add(tbl_service.Rows[i][0].ToString());
            }
            MySqlCommand command = new MySqlCommand("SELECT max(id_receptions)+1 FROM vet_clinicka.journal_receptions ", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
            }
            reader.Close();
            connection.Close();
        }

        private void comboBox_owner_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            comboBox_pets.Items.Clear();
            comboBox_pets.Text = "";
            string fio = comboBox_owner.SelectedItem.ToString();
            String[] words = fio.Split(new char[] { ' ' });
            string surname = words[0];
            string name = words[1];
            MySqlDataAdapter sda_owner = new MySqlDataAdapter("select name_animal from pets join owner on pets.id_owner = owner.id_owner " +
                $"where surname='{surname}' and name='{name}'", connection);
            DataTable tbl_owner = new DataTable();
            sda_owner.Fill(tbl_owner);
            for (int i = 0; i < tbl_owner.Rows.Count; i++)
            {
                comboBox_pets.Items.Add(tbl_owner.Rows[i][0].ToString());
            }
            connection.Close();
        }
        private void comboBox_pets_SelectedIndexChanged(object sender, EventArgs e)
        {
            pets = comboBox_pets.SelectedItem.ToString();
            connection.Open();
            MySqlCommand command = new MySqlCommand($"SELECT id_animal FROM vet_clinicka.pets where name_animal='{pets}' ", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id_pets = reader[0].ToString();
            }
            reader.Close();
            connection.Close();
        }
        private void comboBox_doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string doctor;
            doctor = comboBox_doctor.SelectedItem.ToString();
            String[] words = doctor.Split(new char[] { ' ' });
            string surname = words[0];
            string name = words[1];
            MessageBox.Show(surname+","+ name);
            connection.Open();
            MySqlCommand command = new MySqlCommand($"SELECT id_doctor FROM vet_clinicka.doctor where surname='{surname}' and name='{name}' ", connection);
            MessageBox.Show($"SELECT id_doctor FROM vet_clinicka.doctor where surname='{surname}' and name='{name}' ");
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show("1");
                id_doctor = reader[0].ToString();
            }
            reader.Close();
            connection.Close();
            MessageBox.Show(id_doctor);
        }

        private void comboBox_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_service = comboBox_service.SelectedItem.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UsersForm userForm = new UsersForm(id);
            Hide();
            userForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id_reception = textBox1.Text.ToString();
            data = dateTimePicker1.Value.ToString("yyyy.MM.dd hh:mm");
            try
            {
                connection.Open();
                string id = "";
                string  query_for_juornal = $"insert into vet_clinicka.journal_receptions (id_receptions,id_animal,service,id_doctor,data_) values ({id_reception},{id_pets},'{id_service}',{id_doctor},'{data}')";
                MessageBox.Show(query_for_juornal);
                MySqlCommand command = new MySqlCommand(query_for_juornal, connection);
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Запись добавлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
