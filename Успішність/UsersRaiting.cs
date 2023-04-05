using System;
using System.Data;
using System.Windows.Forms;
using MyLib;
using MySql.Data.MySqlClient;


namespace Успішність
{
    public partial class UsersRaiting : Form
    {
        Database database = new Database();
        Sounds sounds = new Sounds();
        int selectedRow;

        public UsersRaiting()
        {
            InitializeComponent();
        }

        private void UsersRaiting_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns["isNew"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
        }

        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "№");//0
            dataGridView1.Columns.Add("PIB", "Прізвище, Ім'я, По-батькові");//1
            dataGridView1.Columns.Add("English", "Англійська");//2
            dataGridView1.Columns.Add("Programing", "Програмування");//3
            dataGridView1.Columns.Add("PhysicalCulture", "Фізкультура");//4
            dataGridView1.Columns.Add("Physic", "Фізика");//5
            dataGridView1.Columns.Add("Ukrainian", "Українська");//6        
            dataGridView1.Columns.Add("WEB", "Веб-технології");//7
            dataGridView1.Columns.Add("Math", "Математика");//8
            dataGridView1.Columns.Add("Computer", "Архітектура комп'ютера");//9
            dataGridView1.Columns.Add("isNew", String.Empty);//10
        }

        public void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), record.GetInt32(6), record.GetInt32(7), record.GetInt32(8), record.GetInt32(9), RowState.ModifiedNew);
        }

        public void RefreshDataGrid(DataGridView dgw)
        {

            dgw.Rows.Clear();
            string queryString = $"select * from `points`";
            MySqlCommand command = new MySqlCommand(queryString, database.getConnection());
            database.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())            
              ReadSingleRow(dgw, reader);           
            reader.Close();
        }

        public void raiting()
        {
            if (textBoxEnglish.Text == "")
                return;
            int eng = Convert.ToInt32(textBoxEnglish.Text);
            int prog = Convert.ToInt32(textBoxPrograming.Text);
            int cltr = Convert.ToInt32(textBoxPhysicalCulture.Text);
            int phsc = Convert.ToInt32(textBoxPhysic.Text);
            int uk = Convert.ToInt32(textBoxUkrainian.Text);
            int wt = Convert.ToInt32(textBoxWEB.Text);
            int mat = Convert.ToInt32(textBoxMath.Text);
            int ak = Convert.ToInt32(textBoxComputer.Text);
            int check = 0;
            if (textBoxEnglish.Text != "")
                check++;
            if (textBoxPrograming.Text != "")
                check++;
            if (textBoxPhysicalCulture.Text != "")
                check++;
            if (textBoxPhysic.Text != "")
                check++;
            if (textBoxUkrainian.Text != "")
                check++;
            if (textBoxWEB.Text != "")
                check++;
            if (textBoxMath.Text != "")
                check++;
            if (textBoxComputer.Text != "")
                check++;
            if (check == 0)
                textBoxAvg.Text = "Оцінки ще не виставлені!";
            float summ = (eng + prog + cltr + phsc + uk + wt + mat + ak) / check;
            textBoxAvg.Text = Convert.ToString(summ);
        } //для підрахунку середнього значення


        private void buttonAbiturients_Click(object sender, EventArgs e)
        {
            sounds.Press();
            this.Hide();
            USERMainForm user = new USERMainForm();
            user.Show();
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBoxid.Text = row.Cells[0].Value.ToString();
                textBoxPIB.Text = row.Cells[1].Value.ToString();
                textBoxEnglish.Text = row.Cells[2].Value.ToString();
                textBoxPrograming.Text = row.Cells[3].Value.ToString();
                textBoxPhysicalCulture.Text = row.Cells[4].Value.ToString();
                textBoxPhysic.Text = row.Cells[5].Value.ToString();
                textBoxUkrainian.Text = row.Cells[6].Value.ToString();
                textBoxWEB.Text = row.Cells[7].Value.ToString();
                textBoxMath.Text = row.Cells[8].Value.ToString();
                textBoxComputer.Text = row.Cells[9].Value.ToString();
                raiting();
            }
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from `points` where concat (`id`, `PIB`, `English`, `Programing`, `PhysicalCulture`, `Physic`, `Ukrainian`, `WEB`, `Math`, `Computer`) like '%" + textBoxSearch.Text + "%'";

            MySqlCommand com = new MySqlCommand(searchString, database.getConnection());
            database.openConnection();
            MySqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        } //Пошук

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void UsersRaiting_FormClosed(object sender, FormClosedEventArgs e)
        {
            sounds.Close();
            DialogResult result = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми           
            else
            if (result == DialogResult.No)
            {
                UsersRaiting point = new UsersRaiting();
                point.Show();
            }
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
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

        private void buttonAbiturients_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }
    }
}