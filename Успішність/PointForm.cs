using System;
using System.Data;
using System.Windows.Forms;
using MyLib;
using MySql.Data.MySqlClient;

namespace Успішність
{
    public partial class PointForm : Form
    {
        Database database = new Database();
        Sounds sounds = new Sounds();
        int selectedRow;

        public PointForm()
        {
            InitializeComponent();
            Fillcombo();           
        }

        private void PointForm_Load(object sender, EventArgs e)
        {
            reads();

            CreateColumns();
            RefreshDataGrid(dataGridView1);

            Comparisonbutton.Visible = false;
            Comparison.Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns["check"].Visible = false;
            dataGridView1.Columns["isNew"].Visible = false;

        }

        public void reads()
        {
            if (textBoxid.Text == "")
            {
                pictureBoxChange.Visible = false;
                comboBoxPIB.Visible = false;
                     comboBox1.Visible = true;
                EnglishUpDown.ReadOnly = true;
                ProgrammingUpDown.ReadOnly = true;
                CultureUpDown.ReadOnly = true;
                PhysicUpDown.ReadOnly = true;
                UkrainianUpDown.ReadOnly = true;
                WEBUpDown.ReadOnly = true;
                MathUpDown.ReadOnly = true;
                ComputerUpDown.ReadOnly = true;
            }
            else
            {
                pictureBoxChange.Visible = true;
                comboBoxPIB.Visible = true;
                     comboBox1.Visible = false;
                EnglishUpDown.ReadOnly = false;
                ProgrammingUpDown.ReadOnly = false;
                CultureUpDown.ReadOnly = false;
                PhysicUpDown.ReadOnly = false;
                UkrainianUpDown.ReadOnly = false;
                WEBUpDown.ReadOnly = false;
                MathUpDown.ReadOnly = false;
                ComputerUpDown.ReadOnly = false;
            }
        }

        public void CheckToEmpty()
        {
            if (EnglishUpDown.Text == "")
                EnglishUpDown.Text = "0";

            if (ProgrammingUpDown.Text == "")
                ProgrammingUpDown.Text = "0";

            if (CultureUpDown.Text == "")
                CultureUpDown.Text = "0";

            if (PhysicUpDown.Text == "")
                PhysicUpDown.Text = "0";

            if (UkrainianUpDown.Text == "")
                UkrainianUpDown.Text = "0";

            if (WEBUpDown.Text == "")
                WEBUpDown.Text = "0";

            if (MathUpDown.Text == "")
                MathUpDown.Text = "0";

            if (ComputerUpDown.Text == "")
                ComputerUpDown.Text = "0";            
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

            DataGridViewCheckBoxColumn dgvcheckbox = new DataGridViewCheckBoxColumn();
            dgvcheckbox.ValueType = typeof(bool);
            dgvcheckbox.Name = "check";
            dgvcheckbox.HeaderText = "Порівняння";
            dataGridView1.Columns.Add(dgvcheckbox);
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

        private void ClearFields()
        {
            textBoxid.Text = "";
            comboBoxPIB.Text = "";
            EnglishUpDown.Text = "";
            ProgrammingUpDown.Text = "";
            CultureUpDown.Text = "";
            PhysicUpDown.Text = "";
            UkrainianUpDown.Text = "";
            WEBUpDown.Text = "";
            MathUpDown.Text = "";
            ComputerUpDown.Text = "";
        }

        private void buttonAbiturients_Click(object sender, EventArgs e)
        {
            sounds.Press();
            this.Hide();
            ADMINMainForm adm = new ADMINMainForm();
            adm.Show();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            sounds.Press();
            this.Hide();
            ListUsersForm list = new ListUsersForm();
            list.Show();
        }

        private void pictureBoxRefresh_Click(object sender, EventArgs e)
        {
            reads();
            RefreshDataGrid(dataGridView1);
            sounds.Press();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
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

        private void UpDate()
        {          
            database.openConnection();
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[10].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from `points` where `id` = {id}";
                    var command = new MySqlCommand(deleteQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString(); ;
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var engl = dataGridView1.Rows[index].Cells[2].Value.ToString() ;
                    var prgrm = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var foot = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var phsc = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var ukr = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var VT = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var iLoveMeth = dataGridView1.Rows[index].Cells[8].Value.ToString();
                    var AK = dataGridView1.Rows[index].Cells[9].Value.ToString();
                    var avg = textBoxAvg.Text;

                    var changeQuery = $"UPDATE `points` SET `PIB` = '{name}', `English` = '{engl}', `Programing` = '{prgrm}', `PhysicalCulture` = '{foot}', `Physic` = '{phsc}', `Ukrainian` = '{ukr}', `WEB` = '{VT}', `Math` = '{iLoveMeth}', `Computer` = '{AK}' WHERE `id` = '{id}'";
                    var changeQuery1 = $"UPDATE `abiturients` SET `AvgPoint` = '{avg}' WHERE `PIB` = '{name}'";

                    var command = new MySqlCommand(changeQuery, database.getConnection());
                    var command1 = new MySqlCommand(changeQuery1, database.getConnection());
                    command.ExecuteNonQuery();
                    command1.ExecuteNonQuery();
                }
            }
            database.closeConnection();
        }


        private void pictureBoxRemoveUser_Click(object sender, EventArgs e)
        {          
            reads();
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити запис?", "Видалення запису", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                sounds.Press();
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

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;
        }

        private void pictureBoxAddUser_Click(object sender, EventArgs e)
        {
            reads();
            sounds.Press();
            this.Hide();
            addPointForm add = new addPointForm();
            add.Show();
        }

        private void Comparisonbutton_Click(object sender, EventArgs e)
        {
            int[] array = new int[100];
            int j = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[10].Value) == true)
                {
                    array[j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    j++;
                }
            }
                if (j > 0)
                {
                    this.Hide();
                    ComparForm f = new ComparForm();
                    f.arrayadd(array, j);
                    f.Show();
                }
            
            }

        private void pictureBoxSave_Click(object sender, EventArgs e)
        {          
            reads();
            sounds.Press();
            UpDate();
        }

        private void Change()
        {
            if (EnglishUpDown.Text == "" || CultureUpDown.Text == "" || PhysicUpDown.Text == "" || MathUpDown.Text == "" || ProgrammingUpDown.Text == "" || UkrainianUpDown.Text == "" || WEBUpDown.Text == "" || ComputerUpDown.Text == "")
            {
                MessageBox.Show("Перевірте корректність введення даних!");
                return;
            }
            if (isUserExists())
                return;
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;         
            var id = textBoxid.Text;
            var name = comboBoxPIB.Text;

            var engl = EnglishUpDown.Text; //Залік            
            var foot = CultureUpDown.Text; //Залік
            var phsc = PhysicUpDown.Text; //Залік
            var iLoveMeth = MathUpDown.Text; //Залік

            var ukr = UkrainianUpDown.Text;  //Екзамен
            var VT = ComputerUpDown.Text; //Екзамен
            var prgrm = ProgrammingUpDown.Text; //Екзамен
            var AK = ComputerUpDown.Text;//Екзамен        

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {                                        
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, name, engl, prgrm, foot, phsc, ukr, VT, iLoveMeth, AK);
                    dataGridView1.Rows[selectedRowIndex].Cells[10].Value = RowState.Modified;                                       
            }

        }
        private void pictureBoxChange_Click(object sender, EventArgs e)
        {
            if (comboBoxPIB.Text == "" || EnglishUpDown.Text == "" || ProgrammingUpDown.Text == "" || CultureUpDown.Text == "" || PhysicUpDown.Text == "" || UkrainianUpDown.Text == "" || WEBUpDown.Text == "" || ComputerUpDown.Text == "" || MathUpDown.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Перевірте корректність введеня даних");
                sounds.Press();
                return;
            }
            else
            {
                sounds.Press();
                Change();
                ClearFields();
                reads();
            }
        }
       

        public void raiting()
        {
            CheckToEmpty();
            int eng = Convert.ToInt32(EnglishUpDown.Text);//Залік
                                                        
            int cltr = Convert.ToInt32(CultureUpDown.Text);//Залік
            int phsc = Convert.ToInt32(PhysicUpDown.Text);//Залік
            int mat = Convert.ToInt32(MathUpDown.Text);//Залік

            int prog = Convert.ToInt32(ProgrammingUpDown.Text);//Екзамен
            int uk = Convert.ToInt32(UkrainianUpDown.Text); //Екзамен
            int wt = Convert.ToInt32(WEBUpDown.Text); //Екзамен
            int ak = Convert.ToInt32(ComputerUpDown.Text);//Екзамен

            int exam = 0, zalik = 0;

            if (EnglishUpDown.Text != "")
                zalik++;
            if (CultureUpDown.Text != "")
                zalik++;
            if ( PhysicUpDown.Text != "")
                zalik++;
            if (MathUpDown.Text != "")
                zalik++;

            if (ProgrammingUpDown.Text != "")
                exam++;
            if (ComputerUpDown.Text != "")
                exam++;
            if (WEBUpDown.Text != "")
                exam++;
            if (UkrainianUpDown.Text != "")
                exam++;

            if (exam == 0 && zalik == 0)
            {
                textBoxAvg.Text = "0";
                return;
            }
                double summ = (2 * (prog + wt + uk + ak) + (eng + cltr + phsc + mat)) / (2 * exam + zalik);
            if (summ > 100)
                summ = 100;
            //float summ = (eng + prog + cltr + phsc + uk + wt + mat + ak) / check;
            textBoxAvg.Text = Convert.ToString(summ);
        } //для підрахунку середнього значення

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            reads();
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBoxid.Text = row.Cells[0].Value.ToString();
                comboBoxPIB.Text = row.Cells[1].Value.ToString();
                EnglishUpDown.Text = row.Cells[2].Value.ToString();
                ProgrammingUpDown.Text = row.Cells[3].Value.ToString();
                CultureUpDown.Text = row.Cells[4].Value.ToString();
                PhysicUpDown.Text = row.Cells[5].Value.ToString();
                UkrainianUpDown.Text = row.Cells[6].Value.ToString();
                WEBUpDown.Text = row.Cells[7].Value.ToString();
                MathUpDown.Text = row.Cells[8].Value.ToString();
                ComputerUpDown.Text = row.Cells[9].Value.ToString();
                reads();
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
               ReadSingleRow(dgw, read);           
            read.Close();
        } //Пошук

        private void Comparison_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns["check"].Visible == false)
            {
                Comparisonbutton.Visible = true;
                textBoxSearch.ReadOnly = true;
                dataGridView1.Columns["check"].Visible = true;
            }
            else
            {
                Comparisonbutton.Visible = false;
                textBoxSearch.ReadOnly = false;
                dataGridView1.Columns["check"].Visible = false;
            }

        }

        public Boolean isUserExists() //Boolean(Булев, Логічний тип даних) - примітивний тип даних, які можуть приймати два можливі значення: true та false.
        {
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(); //Сторюємо об'єкт, з яким будемо працювати в майбутньому          
            MySqlCommand command = new MySqlCommand("SELECT * FROM `points` WHERE `PIB` = @uL", database.getConnection());//Вказали деяку команду, яка повинна виконатись по відношенню до бази даних. Вказали до якої бази даних м підключаємось - db.getConnection() 

            //@uL та @uP це деякі 'Заглушки', які збільшують рівень захисту бази данних

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = comboBoxPIB.Text; //Замість 'заглушки @uL' вказали конктрентну змінну loginField
            adapter.SelectCommand = command; //Обрали потрібну комманду та виконали її

            adapter.Fill(table); //Всі ті данні які ми отримали, ми помістили всередину об'єкта table, який просто являється табличкою, в якій ми можемо зручно працювати з кожним іх об'єктів

            if (table.Rows.Count > 0) //Якщо кількість рядків у об'єкта table більше 0, то 
            {
                sounds.Invalid();
                DialogResult result = MessageBox.Show("Оцінки цьому абітурєнту вже виставлені, впевнені що хочете продовжити?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Якщо умова істинна, то можемо стверджувати що користувач інсує             
                if (result == DialogResult.No)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            reads();
            Search(dataGridView1);
        }

        void Fillcombo()
        {
            string comstring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select * from termpaper.abiturients ;";
            MySqlConnection conDataBase = new MySqlConnection(comstring);
            MySqlCommand cmd = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string sname = myReader.GetString("PIB");
                    comboBoxPIB.Items.Add(sname);
                }
            }
            catch
            {

            }
        }

        private void comboBoxPIB_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboBoxPIB.DropDownStyle = ComboBoxStyle.DropDownList;
        }

       
        //Виклик messagebox при закривання форми
        private void PointForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sounds.Close();
            DialogResult result = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                PointForm point = new PointForm();
                point.Show();
            }
            else
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми                      
        }

        //При виході із певних текстбоксів викликається фу-я raiting()
        private void textBoxEnglish_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxPrograming_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxPhysicalCulture_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxPhysic_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxUkrainian_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxWEB_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxMath_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxComputer_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void comboBoxPIB_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxid_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        //Відтворення звукових еффектів нижче
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

        private void buttonAbiturients_MouseEnter(object sender, EventArgs e)
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
        
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sounds.Invalid();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        //Введення тільки чисел в textbox       

        private void textBoxAvg_KeyPress(object sender, KeyPressEventArgs e)
        {
            raiting();
        }

        private void textBoxAvg_Enter(object sender, EventArgs e)
        {
            raiting();
        }

        private void textBoxAvg_MouseEnter(object sender, EventArgs e)
        {

            raiting();
        }

        private void EnglishUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void ProgrammingUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void CultureUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void PhysicUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void UkrainianUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void WEBUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void MathUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void ComputerUpDown_Leave(object sender, EventArgs e)
        {
            raiting();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Comparisonbutton_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void EnglishUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void ProgrammingUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void CultureUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void PhysicUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void UkrainianUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void WEBUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void MathUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }

        private void ComputerUpDown_ValueChanged(object sender, EventArgs e)
        {
            reads();
        }
    }
}