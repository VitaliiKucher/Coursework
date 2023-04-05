using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using MyLib;

namespace Успішність
{

    public partial class USERMainForm : Form
    {
        Database database = new Database();
        Sounds sounds = new Sounds();
        int selectedRow;

        public USERMainForm()
        {
            InitializeComponent();
        }

        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");//0
            dataGridView1.Columns.Add("PIB", "Прізвище, Ім'я, По-батькові");//1
            dataGridView1.Columns.Add("Faculty", "Факультет");//2
            dataGridView1.Columns.Add("Stupin", "Освітній ступінь");//3
            dataGridView1.Columns.Add("FormStudy", "Форма навчання");//4
            dataGridView1.Columns.Add("Group", "Група");//5
            dataGridView1.Columns.Add("Special", "Спеціальність");//6
            dataGridView1.Columns.Add("Programma", "Освітня програма");//7
            dataGridView1.Columns.Add("AvgPoint", "Середній бал");//8
        }

        public void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetInt32(8));
        }

        public void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from abiturients";
            MySqlCommand command = new MySqlCommand(queryString, database.getConnection());
            database.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                ReadSingleRow(dgw, reader);            
            reader.Close();
        }

        private void USERMainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns["id"].Visible = false;
        }

        private void RegisterlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); //Звертаємось до вікна RegisterForm та ховаємо його, тобто ховаєто вікно авторизації
            LoginForm autorizationForm = new LoginForm();//Звертаємось до класу LoginForm та створюємо на його основі деякий об'єкт autorizationForm і вижіляємо під нього пам'ять 
            autorizationForm.Show();//Звертаємось до об'єкту autorizationForm і функції Show(), яка дозволить нам відкрити вікно реєстрації loginForm.cs
        }

        private void USERMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//Якщо вікно закривається, то відбувається завершення програми
        }
       
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBoxName.Text = row.Cells[1].Value.ToString();
                textBoxFaculty.Text = row.Cells[2].Value.ToString();
                textBoxStupin.Text = row.Cells[3].Value.ToString();
                textBoxFormStudy.Text = row.Cells[4].Value.ToString();
                textBoxGroup.Text = row.Cells[5].Value.ToString();
                textBoxSpecial.Text = row.Cells[6].Value.ToString();
                textBoxProgramma.Text = row.Cells[7].Value.ToString();
                textBoxAvgPoints.Text = row.Cells[8].Value.ToString();
            }
        }

        private void buttonPoints_Click(object sender, EventArgs e)
        {
            sounds.Press();
            this.Hide();
            UsersRaiting point = new UsersRaiting();
            point.Show();
        }

        private void buttonPoints_MouseHover(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            sounds.Press();
            sounds.Press();
            DialogResult result = MessageBox.Show("Ви дійсно хочете вийти з облікового запису?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                sounds.Close();
                this.Hide(); //Звертаємось до вікна RegisterForm та ховаємо його, тобто ховаєто вікно авторизації
                LoginForm autorizationForm = new LoginForm();//Звертаємось до класу LoginForm та створюємо на його основі деякий об'єкт autorizationForm і вижіляємо під нього пам'ять 
                autorizationForm.Show();//Звертаємось до об'єкту autorizationForm і функції Show(), яка дозволить нам відкрити вікно реєстрації loginForm.cs
            }
            else
            {
                sounds.Press();
                return;
            }
        }

        private void pictureBoxExit_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void buttonPoints_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from `abiturients` where concat (`id`, `PIB`, `Faculty`, `Stupin`, `FormStudy`, `Group`, `Special`, `Programma`, `AvgPoint`) like '%" + textBoxSearch.Text + "%'";
            MySqlCommand com = new MySqlCommand(searchString, database.getConnection());
            database.openConnection();
            MySqlDataReader read = com.ExecuteReader();

            while (read.Read())           
                ReadSingleRow(dgw, read);          
            read.Close();
        } //Пошук

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
    }
}