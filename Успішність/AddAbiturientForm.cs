using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using MyLib;

namespace Успішність
{
    public partial class AddAbiturient : Form
    {
        Database database = new Database();
        Sounds sounds = new Sounds();

        public AddAbiturient()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            database.openConnection();
            string name = textBoxName.Text;
            string faculty = textBoxFaculty.Text;
            string stupin = textBoxStupin.Text;
            string formstudy = textBoxFormStudy.Text;
            string group = textBoxGroup.Text;
            string special = textBoxSpecial.Text;
            string programma = textBoxProgramma.Text;
            int avgpoint = 0;        
            
            if (textBoxName.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'ПІБ' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxFaculty.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Факультет' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxStupin.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Освітній ступінь' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxFormStudy.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Форма навчання' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxGroup.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Группа' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxSpecial.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Спеціальність' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxSpecial.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Спеціальність' повинно бути заповним!");
                sounds.Press();
            }
            else
            if (textBoxProgramma.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Поле 'Освітня программа' повинно бути заповним!");
                sounds.Press();
            }          
            else                  
            {               
                var addQuery = $"insert into `abiturients` (`id`, `PIB`, `Faculty`, `Stupin`, `FormStudy`, `Group`, `Special`, `Programma`, `AvgPoint`) values (NULL, '{name}', '{faculty}', '{stupin}', '{formstudy}', '{group}', '{special}', '{programma}', '{avgpoint}')";
                var command = new MySqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Абітурієнт успішно доданий!");
                this.Hide();
                ADMINMainForm adminForm = new ADMINMainForm();
                adminForm.Show();
            }            
            database.closeConnection();
        }

        private void AddAbiturient_FormClosed(object sender, FormClosedEventArgs e)
        {
            sounds.Close();
            DialogResult result = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)           
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми           
            else
            if (result == DialogResult.No)
            {
                AddAbiturient point = new AddAbiturient();
                point.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sounds.Press();
            this.Hide();
            ADMINMainForm admin = new ADMINMainForm();
            admin.Show();
        }

        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }
    }
}