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
using MyLib;

namespace Успішність
{
    public partial class addPointForm : Form
    {
        Database database = new Database();
        Sounds sounds = new Sounds();

        public addPointForm()
        {
            InitializeComponent();
            Fillcombo();
        }
        void Fillcombo()
        {
            database.openConnection();
            string Query = "select * from termpaper.abiturients ;";

            MySqlCommand cmd = new MySqlCommand(Query, database.getConnection());
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

           while (myReader.Read())
           {
                string sname = myReader.GetString("PIB");
                comboBoxPIB.Items.Add(sname);
           }
            database.closeConnection();
   
        }

        private void addPointForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sounds.Close();
            DialogResult result = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)           
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми          
            else
            if (result == DialogResult.No)
            {
                addPointForm point = new addPointForm();
                point.Show();
            }
        }

        private void buttonAdd_MouseHover(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            sounds.Press();
            database.openConnection();
            string namee = comboBoxPIB.Text;
            string englih = EnglishUpDown.Text;
            string programing = ProgrammingUpDown.Text;
            string cultur = CultureUpDown.Text;
            string phisic = PhysicUpDown.Text;
            string ukrainains = UkrainianUpDown.Text;
            string webs = WEBUpDown.Text;
            string meth = MathUpDown.Text;
            string arch = ComputerUpDown.Text;

            if (isUserExists())
               return;

            if (comboBoxPIB.Text == "" || EnglishUpDown.Text == "" || ProgrammingUpDown.Text == "" || CultureUpDown.Text == "" || PhysicUpDown.Text == "" || UkrainianUpDown.Text == "" || WEBUpDown.Text == "" || ComputerUpDown.Text == "" || MathUpDown.Text == "")
            {
                sounds.Invalid();
                MessageBox.Show("Перевірте корректність введеня даних");
                sounds.Press();
                return;              
            }

            else                   
            {
                var addQuery = $"insert into `points` (`PIB`, `English`, `Programing`, `PhysicalCulture`, `Physic`, `Ukrainian`, `WEB`, `Math`, `Computer`) values ('{namee}', '{englih}', '{programing}', '{cultur}', '{phisic}', '{ukrainains}', '{webs}', '{meth}', '{arch}')";
                var command = new MySqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Оцінка виставлена!");                
            }
            database.closeConnection();
            this.Hide();
            PointForm point = new PointForm();
            point.Show();
     
        }
      
        private void linkLabelback_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PointForm sh = new PointForm();
            sh.Show();
            sounds.Press();
        }

        private void comboBoxPIB_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.comboBoxPIB.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void linkLabelback_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
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
    }
}