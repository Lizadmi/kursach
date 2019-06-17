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
using Excel = Microsoft.Office.Interop.Excel;//подкючаем библиотеку

namespace vet_clinicka
{
    public partial class AdminForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;userid=root;password=12345;database=vet_clinicka");
        DataTable table = new DataTable();
        public string tbl_name;

        public AdminForm()
        {
            InitializeComponent();
            toolStripMenuItem1.Visible = true;
            this.Text += "/Пользователь Админ";

        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            ToolStripSeparator toolStripSeparator = new CustomSeparator();
            toolStripMenuItem1.DropDownItems.Insert(5, toolStripSeparator);
        }
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

        private void выходИзСистемыToolStripMenuItem1_Click(object sender, EventArgs e)//закрвтие всех форм по выходу из программы
        {
            Application.Exit();
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)//закрвтие всех форм по выходу из программы
        {
            Application.Exit();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            //panelToAddUser.Visible = true;
        }

        private void расчтЗарплатыЗаМесяцToolStripMenuItem_Click(object sender, EventArgs e)//открытие формы по расчеты ЗП
        {
            ZPForm zP = new ZPForm();
            Hide();
            zP.Show();
        }

        //ИМПОРТ 
        private void toolStripMenuItem13_Click(object sender, EventArgs e) //импорт таблицы Прайс-лист в БД
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите обновить прайс-лист?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(filename);
                Excel._Worksheet worksheet = (Excel._Worksheet)workbook.ActiveSheet;


                int lastrow = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                int lastcolumn = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;

                string[,] array = new string[lastrow, lastcolumn];
                for (int i = 0; i < lastrow; i++)
                {
                    for (int j = 0; j < lastcolumn; j++)
                    {
                        array[i, j] = Convert.ToString((worksheet.Cells[i + 2, j + 1] as Excel.Range).Value);
                    }
                }
                table.Columns.Add("id_service", typeof(string));
                table.Columns.Add("name_service", typeof(string));
                table.Columns.Add("description", typeof(string));
                table.Columns.Add("cost", typeof(string));

                for (int i = 0; i < lastrow - 1; i++)
                {
                    string[] ar = new string[lastcolumn];
                    for (int j = 0; j < lastcolumn; j++)
                    {
                        ar[j] = array[i, j];
                    }
                    table.LoadDataRow(ar, true);
                }
                dataGridView1.DataSource = table;
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM vet_clinicka.prays_list", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                connection.Close();
                tbl_name = "vet_clinicka.prays_list";
                UpdateDGV(tbl_name);
                CloseExcel(application, workbook);
                dataTable.Clear();
            }

        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e) //импорт таблицы диагнозов в БД
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите обновить список диагнозов?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open(filename);
                Excel._Worksheet worksheet = (Excel._Worksheet)workbook.ActiveSheet;


                int lastrow = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
                int lastcolumn = worksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;

                string[,] array = new string[lastrow, lastcolumn];
                for (int i = 0; i < lastrow; i++)
                {
                    for (int j = 0; j < lastcolumn; j++)
                    {
                        array[i, j] = Convert.ToString((worksheet.Cells[i + 2, j + 1] as Excel.Range).Value);
                    }
                }
                table.Columns.Add("id_diagnostic", typeof(string));
                table.Columns.Add("name_diagnostic", typeof(string));
                table.Columns.Add("therapy", typeof(string));
                table.Columns.Add("symptom", typeof(string));

                for (int i = 0; i < lastrow - 1; i++)
                {
                    string[] ar = new string[lastcolumn];
                    for (int j = 0; j < lastcolumn; j++)
                    {
                        ar[j] = array[i, j];
                    }
                    table.LoadDataRow(ar, true);
                }
                dataGridView1.DataSource = table;
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT *  FROM vet_clinicka.diagnostic", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                connection.Close();
                tbl_name = "vet_clinicka.diagnostic";
                UpdateDGV(tbl_name);
                CloseExcel(application, workbook);
                dataTable.Clear();
            }



        }
        public void UpdateDGV(string tbl_name) //метод вносящий изменения в БД в соответствии с импортируемым доком
        {
            string query = "";
            MySqlDataAdapter adapter;
            int i_row_Exceltbl = dataGridView1.RowCount - 1;
            int j_column_Exceltbl = dataGridView1.ColumnCount;
            int i_row_Servertbl = dataGridView2.RowCount - 1;
            MessageBox.Show(i_row_Exceltbl.ToString());
            if (i_row_Servertbl != i_row_Exceltbl)
            {
                connection.Open();
                while (i_row_Servertbl < i_row_Exceltbl)
                {

                    if (tbl_name == "vet_clinicka.diagnostic")
                    {
                        query = $"insert into {tbl_name} (name_diagnostic) values ('{i_row_Servertbl + 1}')";
                    }
                    else
                    {
                        query = $"insert into {tbl_name} (name_service) values ('{i_row_Servertbl + 1}')";
                    }
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    if (tbl_name == "vet_clinicka.diagnostic")
                    {
                        adapter = new MySqlDataAdapter("SELECT *  FROM vet_clinicka.diagnostic", connection);
                    }
                    else
                    {
                        adapter = new MySqlDataAdapter("SELECT *  FROM vet_clinicka.prays_list", connection);
                    }

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView2.DataSource = dataTable;
                    i_row_Servertbl = dataGridView2.RowCount - 1;
                }
                connection.Close();
            }
            for (int i = 0; i < i_row_Exceltbl; i++)
            {
                for (int j = 0; j < j_column_Exceltbl; j++)
                {
                    try
                    {
                        dataGridView2[j, i].Value = dataGridView1[j, i].Value;
                        Console.WriteLine(dataGridView1[j, i].Value);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            Import(tbl_name);
        }
        public void Import(string tbl_name) //метод сохраняющий вносимые изменения в БД
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT *  FROM {tbl_name}", connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);
                adapter.Update((DataTable)dataGridView2.DataSource);
                MessageBox.Show("Загрузка успевшно завершена!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
        public void CloseExcel(Excel.Application application, Excel.Workbook workbook) //метод завершения процесса Excel.exe 
        {
            workbook.Close();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            application.Quit();
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(application);
        }

        private void doctorBtn_Click(object sender, EventArgs e)
        {
            tbl_name = "doctor";
            DisplayTables(tbl_name);
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            tbl_name = "post";
            DisplayTables(tbl_name);
        }

        private void petsBtn_Click(object sender, EventArgs e)
        {
            tbl_name = "pets";
            DisplayTables(tbl_name);
        }

        private void ownerBtn_Click(object sender, EventArgs e)
        {
            tbl_name = "owner";
            DisplayTables(tbl_name);
        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            tbl_name = "user";
            DisplayTables(tbl_name);
        }

        private void jurnalBtn_Click(object sender, EventArgs e)
        {
            tbl_name = "journal_receptions";
            DisplayTables(tbl_name);
        }

        public void DisplayTables(string name_table)//отображение таблиц
        {
            dataGridView3.Columns.Clear();
            connection.Open();
            MySqlDataAdapter SDA_oll_table = new MySqlDataAdapter($"SELECT *  FROM {name_table}", connection);
            DataTable DATA_oll_table = new DataTable();
            SDA_oll_table.Fill(DATA_oll_table);
            dataGridView3.DataSource = DATA_oll_table;
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e) //удаление
        {
            int inr; int inc;
            inr = dataGridView3.CurrentCell.RowIndex;
            inc = dataGridView3.CurrentCell.ColumnIndex;
            string s = dataGridView3[0, inr].Value.ToString();
            string query = null;
            MessageBox.Show(tbl_name);
            try
            {
                connection.Open();
                if (tbl_name == "doctor")
                {
                    query = $"delete from {tbl_name} where id_doctor={s}";
                }
                if (tbl_name == "post")
                {
                    query = $"delete from {tbl_name} where id_post={s}";
                }
                if (tbl_name == "pets")
                {
                    query = $"delete from {tbl_name} where id_animal={s}";
                }
                if (tbl_name == "owner")
                {
                    query = $"delete from {tbl_name} where id_owner={s}";
                }
                if (tbl_name == "user")
                {
                    query = $"delete from {tbl_name} where Code_purchase={s}";
                }
                if (tbl_name == "user")
                {
                    query = $"delete from {tbl_name} where id={s}";
                }
                if (tbl_name == "journal_receptions")
                {
                    query = $"delete from {tbl_name} where id_receptions={s}";
                }
                MessageBox.Show(query);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                DisplayTables(tbl_name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + ex.Message);
                connection.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e) //сохранение изменений
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT *  FROM {tbl_name}", connection);
                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);
                adapter.Update((DataTable)dataGridView3.DataSource);
                connection.Close();
                MessageBox.Show("Сохранение прошло успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!" + ex.Message);
                connection.Close();
            }


        }

        private void редактированиеШтатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDoctorForm addDoctor = new AddDoctorForm();
            Hide();
            addDoctor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_name = "prays_list";
            DisplayTables(tbl_name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbl_name = "diagnostic";
            DisplayTables(tbl_name);
        }
    }


}

