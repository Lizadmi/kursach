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
    public partial class UsersForm : Form
    {

        public UsersForm(string id)
        {
            InitializeComponent();
            connection.Open();
            this.id = id;
            MySqlCommand command = new MySqlCommand($"SELECT surname,name FROM vet_clinicka.doctor where id_doctor={id}", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.Text += $"/Пользователь {reader[0]} {reader[1]}";
            }
            reader.Close();
            MySqlDataAdapter sda_owner = new MySqlDataAdapter("SELECT surname,name FROM vet_clinicka.owner ", connection);
            DataTable tbl_owner = new DataTable();
            sda_owner.Fill(tbl_owner);
            for (int i = 0; i < tbl_owner.Rows.Count; i++)
            {
                comboBox2.Items.Add(tbl_owner.Rows[i][0].ToString() + " " + tbl_owner.Rows[i][1].ToString());
            }
            connection.Close();
        }
        public string id;

        private void UsersForm_Load(object sender, EventArgs e)
        {
            ToolStripSeparator toolStripSeparator = new CustomSeparator();
            toolStripMenuItem2.DropDownItems.Insert(4, toolStripSeparator);
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=12345;database=vet_clinicka");
        public string range = "";
        public string dateOfRange = "";
        DateTime date;

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.Show();
        }

        private void toolStripTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Arrow;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            panelToDisplayJurnal.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            range = comboBox1.SelectedItem.ToString();
            //MessageBox.Show(range);
            switch (range)
            {
                case "Сегодня":
                    dateOfRange = DateTime.Today.ToString("yyyy.MM.dd 18:00:00");
                    break;
                case "Завтра":
                    //date = new DateTime(DateTime.Today.Year,DateTime.Today.Month,DateTime.Today.Day+1);
                    date = DateTime.Today.AddDays(1);
                    dateOfRange = date.ToString("yyyy.MM.dd 18:00:00");
                    break;
                case "3 дня":
                    //date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day + 3);
                    date = DateTime.Today.AddDays(3);
                    dateOfRange = date.ToString("yyyy.MM.dd 18:00:00");
                    break;
                case "Неделя":
                    date = DateTime.Today.AddDays(7);
                    dateOfRange = date.ToString("yyyy.MM.dd 18:00:00");
                    break;
                case "Месяц":
                    //date = new DateTime(DateTime.Today.Year, DateTime.Today.Month+1, DateTime.Today.Day );
                    date = DateTime.Now.AddMonths(1);
                    dateOfRange = date.ToString("yyyy.MM.dd 18:00:00");
                    break;
            };
            MessageBox.Show(dateOfRange);
            MySqlDataAdapter SDA_jurnal = new MySqlDataAdapter("select * from  journal_receptions " +
               $"where journal_receptions.data_ between '{Convert.ToString(DateTime.Today.ToString("yyyy.MM.dd  hh:mm:ss"))}' and '{dateOfRange}' and id_doctor={id}", connection);
            DataTable DATA_jurnal = new DataTable();
            SDA_jurnal.Fill(DATA_jurnal);
            dataGridView1.DataSource = DATA_jurnal;
            connection.Close();
        }

        private void выходИзСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void историяПриемовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelToDisplayJurnal.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label1.Visible = false;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox1.Visible = false;
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            string fio = comboBox2.SelectedItem.ToString();
            String[] words = fio.Split(new char[] { ' ' });
            string surname = words[0];
            string name = words[1];
            MySqlDataAdapter sda_owner = new MySqlDataAdapter("select name_animal from pets join owner on pets.id_owner = owner.id_owner " +
                $"where surname='{surname}' and name='{name}'", connection);
            DataTable tbl_owner = new DataTable();
            sda_owner.Fill(tbl_owner);
            for (int i = 0; i < tbl_owner.Rows.Count; i++)
            {
                comboBox3.Items.Add(tbl_owner.Rows[i][0].ToString());
            }
            connection.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pets = comboBox3.SelectedItem.ToString();
            MySqlDataAdapter sda_owner = new MySqlDataAdapter("select journal_receptions.* from journal_receptions join pets on journal_receptions.id_animal = pets.id_animal" +
                $" where name_animal='{pets}' ", connection);
            MessageBox.Show("select journal_receptions.* from journal_receptions join pets on journal_receptions.id_animal = pets.id_animal" +
                $" where name_animal='{pets}' ");
            DataTable tbl_owner = new DataTable();
            sda_owner.Fill(tbl_owner);
            dataGridView1.DataSource = tbl_owner;
        }

        private void записьНаПриемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceptionsForm receptionsForm = new ReceptionsForm(id);
            Hide();
            receptionsForm.Show();
        }
    }

}