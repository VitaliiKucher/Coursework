using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using MyLib;

namespace Успішність
{
    public partial class ADMINMainForm : Form
    {
        Sounds sounds = new Sounds();
        Database database = new Database();
        int selectedRow;

        public ADMINMainForm()
        {
            InitializeComponent();
        }

        public void reads(){
            if (textBoxAvgPoints.Text == "")
            {
                pictureBoxChange.Visible = false;
                textBoxName.ReadOnly = true;
                textBoxFaculty.ReadOnly = true;
                textBoxStupin.ReadOnly = true;
                textBoxFormStudy.ReadOnly = true;
                textBoxGroup.ReadOnly = true;
                textBoxSpecial.ReadOnly = true;
                textBoxProgramma.ReadOnly = true;
            }
            else
            {
                pictureBoxChange.Visible = true;
                textBoxName.ReadOnly = false;
                textBoxFaculty.ReadOnly = false;
                textBoxStupin.ReadOnly = false;
                textBoxFormStudy.ReadOnly = false;
                textBoxGroup.ReadOnly = false;
                textBoxSpecial.ReadOnly = false;
                textBoxProgramma.ReadOnly = false;
            }
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
            reads();
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
            dataGridView1.Columns.Add("AvgPoint", "Рейтинговий бал");//8
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        public void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetInt32(8), RowState.ModifiedNew);
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

        private void ClearFields()
        {
            textBox_id.Text = "";
            textBoxName.Text = "";
            textBoxFaculty.Text = "";
            textBoxStupin.Text = "";
            textBoxFormStudy.Text = "";
            textBoxGroup.Text = "";
            textBoxSpecial.Text = "";
            textBoxProgramma.Text = "";
            textBoxAvgPoints.Text = "";
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if(dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
        }

        private void UpDate()
        {
            database.openConnection();
            for(int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[9].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from `abiturients` where id = {id}";
                    var command = new MySqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
                
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();                  
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var faculty = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var stupin = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var formstudy = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var group = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var special = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var programma = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var avgpoint = dataGridView1.Rows[index].Cells[8].Value.ToString();

                    var changeQuery = $"UPDATE `abiturients` SET `PIB` = '{name}', `Faculty` = '{faculty}', `Stupin` = '{stupin}', `FormStudy` = '{formstudy}', `Group` = '{group}', `Special` = '{special}', `Programma` = '{programma}', `AvgPoint` = '{avgpoint}' WHERE `id` = '{id}'";
                    var command = new MySqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }

        private void pictureBoxRemoveUser_Click(object sender, EventArgs e)
        {
            
            reads();
            sounds.Press();
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити запис?", "Видалення запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                sounds.Close();
                deleteRow();
                ClearFields();
                reads();
                pictureBoxChange.Visible = false;
            }
            else
            {
                sounds.Press();
                return;
            }
           
        }      
        
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            if (pictureBoxChange.Visible == false)
                pictureBoxChange.Visible = true;
            reads();
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

        private void ADMINMainForm_Load(object sender, EventArgs e)
        {
            reads();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns["isNew"].Visible = false;
        }

        private void pictureBoxAddUser_Click(object sender, EventArgs e)
        {
            reads();
            sounds.Press();
            this.Hide();//Звертаємось до вікна ADMINMainForm та ховаємо його
            AddAbiturient abitForm = new AddAbiturient();//Звертаємось до класу ADMINMainForm та створюємо на його основі деякий об'єкт mainForm і вижіляємо під нього пам'ять 
            abitForm.Show(); //Звертаємось до об'єкту mainForm і функції Show(), яка дозволить нам відкрити головне вікно AddAbiturientForm
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from `abiturients` where concat (`id`, `PIB`, `Faculty`, `Stupin`, `FormStudy`, `Group`, `Special`, `Programma`, `AvgPoint`) like '%" + textBoxSearch.Text + "%'";

            MySqlCommand com = new MySqlCommand(searchString, database.getConnection());
            database.openConnection();
            MySqlDataReader read = com.ExecuteReader();
       
            while(read.Read())            
                ReadSingleRow(dgw, read);            
            read.Close();
        } //Пошук

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            reads();
            Search(dataGridView1);
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            if (pictureBoxChange.Visible == false)
                pictureBoxChange.Visible = true;
            reads();
            sounds.Press();
            RefreshDataGrid(dataGridView1);
        }

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            if (pictureBoxChange.Visible == false)
                pictureBoxChange.Visible = true;
            reads();
            sounds.Press();
            UpDate();        
        }

        private void Change()
        {       
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = textBox_id.Text;
            var name = textBoxName.Text;
            var faculty = textBoxFaculty.Text;
            var stupin = textBoxStupin.Text;
            var formstudy = textBoxFormStudy.Text;
            var group = textBoxGroup.Text;
            var special = textBoxSpecial.Text;
            var programma = textBoxProgramma.Text;
            int avgpoint = Convert.ToInt32(textBoxAvgPoints.Text);

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {                                    
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, name, faculty, stupin, formstudy, group, special, programma, avgpoint);
                    dataGridView1.Rows[selectedRowIndex].Cells[9].Value = RowState.Modified;                                           
            }
        }
        private void pictureBoxChange_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxFaculty.Text == "" || textBoxStupin.Text == "" || textBoxStupin.Text == "" || textBoxFormStudy.Text == "" || textBoxFormStudy.Text == "" || textBoxFormStudy.Text == "" || textBoxGroup.Text == "" || textBoxSpecial.Text == "" || textBoxProgramma.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Перевірте корректність введення даних!");
                sounds.Press();
            }
            else
            {
                sounds.Press();
                Change();
                ClearFields();
                reads();
            }
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            if (pictureBoxChange.Visible == false)
                pictureBoxChange.Visible = true;
            sounds.Press();
            this.Hide();
            ListUsersForm users = new ListUsersForm();
            users.Show();
        }

        private void buttonPoints_Click(object sender, EventArgs e)
        {
            if (pictureBoxChange.Visible == false)
                pictureBoxChange.Visible = true;
            sounds.Press();
            this.Hide();
            PointForm poi = new PointForm();
            poi.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sounds.Close();
            DialogResult res = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                ADMINMainForm point = new ADMINMainForm();
                point.Show();                                                     
            }
            else
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми   
        }

        private void buttonUsers_MouseHover(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void buttonPoints_MouseHover(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxRemoveUser_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxAddUser_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxChange_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void buttonUsers_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void buttonPoints_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxRefresh_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxExit_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

      
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sounds.Invalid();
        }
    }
}