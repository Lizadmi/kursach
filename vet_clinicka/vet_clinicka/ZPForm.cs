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
    public partial class ZPForm : Form
    {
        public ZPForm()
        {
            InitializeComponent();

        }
        private void ZPForm_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection("server=localhost;userid=root;password=12345;database=vet_clinicka");
            connection.Open();
        }
        MySqlConnection connection;
        MySqlDataAdapter SDA_ZP;
        public string FIO;
        public string range;
        public string surname = "";
        public string name = "";
        DateTime start_date = new DateTime();
        DateTime finis_hdata = new DateTime();
        public string start_date1 = "";
        public string finish_date1 = "";
        private void расчитатьДляToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label1.Text += " для:";
            MySqlDataAdapter command = new MySqlDataAdapter("SELECT surname,name  FROM vet_clinicka.doctor", connection);
            DataTable table_cb = new DataTable();
            command.Fill(table_cb);
            //comboBox1.DataSource = table_cb;
            for (int i = 0; i < table_cb.Rows.Count; i++)
            {
                comboBox2.Items.Add(table_cb.Rows[i][0].ToString() + " " + table_cb.Rows[i][1].ToString());
            }
        }

        private void расчитатьДляВсехToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label1.Text = "Расчитать З/П за месяц";
            surname = "";
            name = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayDGV(surname, name);
        }

        private void ZPForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FIO = comboBox2.SelectedItem.ToString();
            String[] words = FIO.Split(new char[] { ' ' });
            surname = words[0];
            name = words[1];
            //MessageBox.Show(surname+"----"+name);

        }
        public void DisplayDGV(string s, string n)
        {
            DateTime date = new DateTime();
            date = DateTime.Today;
            if (date >= new DateTime(date.Year, date.Month, 5))
            {
                start_date = date.AddMonths(-1);
                start_date1 = start_date.ToString("yyyy.MM.05 09:00:00");
                finis_hdata = new DateTime(date.Year, date.Month, 5);
                finish_date1 = finis_hdata.ToString("yyyy.MM.05 18:00:00");

            }
            else if (date < new DateTime(date.Year, date.Month, 5))
            {
                start_date = date.AddMonths(-2);
                start_date1 = start_date.ToString("yyyy.MM.05 ");
                finis_hdata = new DateTime(date.Year, date.Month - 1, 5);
                finish_date1 = finis_hdata.ToString("yyyy.MM.05 ");
            }
            if ((s != "") && (n != ""))
            {
                MessageBox.Show(start_date1 + " 1 " + finish_date1);
                SDA_ZP = new MySqlDataAdapter("select surname,name,post.post,salary+sum(summa)*perc_bonus/100 " +
                            "from doctor join post on post.id_post = doctor.id_post join journal_receptions on doctor.id_doctor = journal_receptions.id_doctor " +
                            $"where surname='{s}' and name='{n}' and (date(data_) between '{start_date1}' and '{finish_date1}')" +
                            "group by surname, name; ", connection);
            }
            else
            {
                MessageBox.Show(start_date1 + " vce " + finish_date1);
                SDA_ZP = new MySqlDataAdapter("select surname,name,post.post,salary+sum(summa)*perc_bonus/100 " +
                            "from doctor join post on post.id_post = doctor.id_post join journal_receptions on doctor.id_doctor = journal_receptions.id_doctor" +
                            $" where  (date(data_) between '{start_date1}' and '{finish_date1}') " +
                            "group by surname, name; ", connection);
            }
            DataTable DATA_ZP = new DataTable();
            SDA_ZP.Fill(DATA_ZP);
            dataGridView1.DataSource = DATA_ZP;
        }

        private void вернутьсяНаГлавныйЭкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            Hide();
            adminForm.Show();
        }
    }
}

