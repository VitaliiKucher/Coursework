using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using MyLib;

namespace Успішність
{
    public partial class ListUsersForm : Form
    {
        Database database = new Database();
        Sounds sound = new Sounds();
        DataTable table = new DataTable(); //Сторюємо об'єкт, з яким будемо працювати в майбутньому
        int selectedRow;

        public ListUsersForm()
        {
            InitializeComponent();
        }

        public void reads()
        {
            if (textBox_id.Text == "")
            {
                pictureBoxChange.Visible = false;
                textBoxLogin.ReadOnly = true;
                textBoxPass.ReadOnly = true;
            }
            else
            {
                pictureBoxChange.Visible = true;
                textBoxLogin.ReadOnly = false;
                textBoxPass.ReadOnly = false;
            }
        }
            private void UpDate()
            {
            database.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from `users` where id = {id}";
                    var command = new MySqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var login = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var pass = dataGridView1.Rows[index].Cells[2].Value.ToString();                
                    var changeQuery = $"UPDATE `users` SET `login` = '{login}', `pass` = '{pass}' WHERE `id` = '{id}'";
                    var command = new MySqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }

        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");//0
            dataGridView1.Columns.Add("login", "Логін");//1
            dataGridView1.Columns.Add("pass", "Пароль");//2          
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        public void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }

        public void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select * from `users`";

            MySqlCommand command = new MySqlCommand(queryString, database.getConnection());
            database.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())           
                ReadSingleRow(dgw, reader);           
            reader.Close();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = textBox_id.Text;
            var login = textBoxLogin.Text;
            var pass = textBoxPass.Text;            

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (textBoxLogin.Text == "")
                {
                    sound.Invalid();
                    MessageBox.Show("Поле 'Логін' повинно бути заповним!");
                    sound.Press();
                }
                else
           if (textBoxPass.Text == "")
                {
                    sound.Invalid();
                    MessageBox.Show("Поле 'Пароль' повинно бути заповним!");
                    sound.Press();
                }
                else
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, login, pass);
                    dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                }                
            }
        }

        private void ListUsersForm_Load(object sender, EventArgs e)
        {
            reads();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CreateColumns();
            RefreshDataGrid(dataGridView1);
            dataGridView1.Columns["isNew"].Visible = false;
        }

        private void ListUsersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sound.Close();
            DialogResult result = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)          
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми           
            else
            if (result == DialogResult.No)
            {
                ListUsersForm point = new ListUsersForm();
                point.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox_id.Text = row.Cells[0].Value.ToString();
                textBoxLogin.Text = row.Cells[1].Value.ToString();
                textBoxPass.Text = row.Cells[2].Value.ToString();
                reads();
            }
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from `users` where concat (`id`, `login`, `pass`) like '%" + textBoxSearch.Text + "%'";

            MySqlCommand com = new MySqlCommand(searchString, database.getConnection());
            database.openConnection();
            MySqlDataReader read = com.ExecuteReader();

            while (read.Read())            
                ReadSingleRow(dgw, read);            
            read.Close();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
        }

        private void pictureBoxRemoveUser_Click(object sender, EventArgs e)
        {
            reads();
            sound.Press();
            deleteRow();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            reads();
            sound.Press();
            RefreshDataGrid(dataGridView1);
        }

        private void pictureBoxAddUser_Click(object sender, EventArgs e)
        {
            reads();
            sound.Press();
            this.Hide();
            regForm reg = new regForm();
            reg.Show();
        }    

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            reads();
            sound.Press();
            UpDate();
        }

        private void pictureBoxChange_Click(object sender, EventArgs e)
        {
            reads();         
            sound.Press();
            Change();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            sound.Press();
            this.Hide();
            ADMINMainForm adm = new ADMINMainForm();
            adm.Show();
        }

        private void buttonPoints_Click(object sender, EventArgs e)
        {
            sound.Press();
            this.Hide();
            PointForm poi = new PointForm();
            poi.Show();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            reads();
            sound.Press();
            DialogResult result = MessageBox.Show("Ви дійсно хочете вийти з облікового запису?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                sound.Close();
                this.Hide(); //Звертаємось до вікна RegisterForm та ховаємо його, тобто ховаєто вікно авторизації
                LoginForm autorizationForm = new LoginForm();//Звертаємось до класу LoginForm та створюємо на його основі деякий об'єкт autorizationForm і вижіляємо під нього пам'ять 
                autorizationForm.Show();//Звертаємось до об'єкту autorizationForm і функції Show(), яка дозволить нам відкрити вікно реєстрації loginForm.cs
            }
            else
            {
                sound.Press();
                return;
            }
        }

        private void pictureBoxRemoveUser_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void pictureBoxAddUser_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void pictureBoxChange_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void buttonUsers_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void buttonPoints_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void pictureBoxRefresh_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void pictureBoxExit_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sound.Invalid();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }
    }
}