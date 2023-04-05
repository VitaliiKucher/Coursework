using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyLib;
using MySql.Data.MySqlClient;
namespace Успішність
{
    public partial class regForm : Form
    {
        Database db = new Database();
        DataTable table = new DataTable(); //Сторюємо об'єкт, з яким будемо працювати в майбутньому
        Sounds sounds = new Sounds();

        public regForm()
        {
            InitializeComponent();

            loginField.Text = "Введіть логін..."; //Розміщуємо текст всередині поля
            loginField.ForeColor = Color.Gray; //Задання сірого кольору для тексту всередині поля
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введіть пароль...") // Якщо текст всередині поля дорівнює "Введіть логін...", то
            {
                passField.UseSystemPasswordChar = true;// Повертає або задає значення, яке вказує, що текст в полі повинен відображуватися як знак пароля по замовчуванню
                passField.Text = ""; // Якщо умова істинна, то відбувається очищення поля від тексту, в інших випадках елемент очищатися не буде
                passField.ForeColor = Color.Black; //Якщо умова істинна, то відбувається задання чорного кольору для тексту всередині поля
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "") //Якщо текст всередині поля пустий, то
            {
                passField.UseSystemPasswordChar = false;// Повертає або задає значення, яке вказує, що текст в полі повинен відображуватися як знак пароля по замовчуванню
                passField.Text = "Введіть пароль..."; // Якщо умова істинна, то текст всередині поля буде "Введіть логін..."
                passField.ForeColor = Color.Gray; // Якщо умова істинна, то відбувається задання сірого кольору для тексту всередині поля
            }
        }

        //Для додавання підсказок в TextBox потрібне використання коду, так як елементу по типу PlaceHolder в VS Windows Forms не існує
        public void loginField_Enter(object sender, EventArgs e) //Створено подію Enter, яка спрацьовує при введенні чого-небудь в TextBox з назвою loginField.
        {
            if (loginField.Text == "Введіть логін...") // Якщо текст всередині поля дорівнює "Введіть логін...", то
            {
                loginField.Text = ""; //Якщо умова істинна, то поле очищується від тексту, в інших випадках елемент очищатися не буде
                loginField.ForeColor = Color.Black; //Задання чорного кольору для тексту всередині поля
            }
        }
        public void loginField_Leave(object sender, EventArgs e) //Створено подію Leave, яка спрацьовує при виході із елемента управління TextBox з назвою loginField. 
        {
            if (loginField.Text == "") //Якщо поле порожнє, то
            {
                loginField.Text = "Введіть логін..."; // Якщо умова істинна, то текст всередині поля буде "Введіть логін..."
                loginField.ForeColor = Color.Gray; // Якщо умова істинна, то відбувається задання сірого кольору для тексту всередині поля
            }
        }
 
        public void buttonRegister_Click(object sender, EventArgs e)
        {
            sounds.Press();
            if (loginField.Text == "Введіть логін...") //Якщо поле порожнє, то 
            {
                sounds.Invalid();
                MessageBox.Show("Вигадайте логін!");// Якщо умова істинна, то буде виведене вікно з надписом "Вигадайте логін!"
                sounds.Press();
                return; //Вихід з функції
            }

            if (passField.Text == "")//Якщо поле порожнє, то 
            {
                sounds.Invalid();
                MessageBox.Show("Вигадайте пароль!");//Якщо умова істинна, то буде виведене вікно з надписом "Вигадайте пароль!"
                sounds.Press();
                return;//Вихід з функції
            }

            if (isUserExists()) //Якщо функція повернає істинне значення, то
                return; //Вихід з функції

            Database db = new Database();//Створено об'єкт на основі класа Database, через який ми можемо звертатися до функцій в класі Database
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`) VALUES (@login, @password);", db.getConnection()); //Команда, яка вбудовує данні в локальну табличку MySql 
           
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginField.Text; // Замість 'Заглушок' встановили певні значення, які будуть вміщені 
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passField.Text;// Замість 'Заглушок' встановили певні значення, які будуть вміщені 
           
            db.openConnection(); //Підключаємось до бази даних за допомогою об'єкта db і використовуємо в ньому функцію openConnection()

            if (command.ExecuteNonQuery() != 0)// Якщо запит успішний, то
            {
                MessageBox.Show("Ви успішно зареєстрували користувача!"); //Якщо умова істинна, то виводиться дікно з надписом "Ви успішно зареєструвалися!"
                sounds.Press();
                this.Hide();//Звертаємось до вікна RegisterForm та ховаємо його, тобто ховаєто вікно регістраціх
                ListUsersForm mainForm = new ListUsersForm();//Звертаємось до класу USERMainForm та створюємо на його основі деякий об'єкт mainForm і вижіляємо під нього пам'ять 
                mainForm.Show(); //Звертаємось до об'єкту mainForm і функції Show(), яка дозволить нам відкрити головне вікно mainForm
            }
            else
            {
                sounds.Invalid();
                MessageBox.Show("Перевірте корректність введення даних");//Якщо умова хибна, то виводиться дікно з надписом "Ви успішно зареєструвалися!"
                sounds.Press();
            }
            db.closeConnection();//Закриваємо з'єдання з базою даних
        }

        public Boolean isUserExists() //Boolean(Булев, Логічний тип даних) - примітивний тип даних, які можуть приймати два можливі значення: true та false.
        {
            
            MySqlDataAdapter adapter = new MySqlDataAdapter(); //Сторюємо об'єкт, з яким будемо працювати в майбутньому

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());//Вказали деяку команду, яка повинна виконатись по відношенню до бази даних. Вказали до якої бази даних м підключаємось - db.getConnection() 
            //@uL та @uP це деякі 'Заглушки', які збільшують рівень захисту бази данних
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text; //Замість 'заглушки @uL' вказали конктрентну змінну loginField

            adapter.SelectCommand = command; //Обрали потрібну комманду та виконали її
            adapter.Fill(table); //Всі ті данні які ми отримали, ми помістили всередину об'єкта table, який просто являється табличкою, в якій ми можемо зручно працювати з кожним іх об'єктів

            if (table.Rows.Count != 0) //Якщо кількість рядків у об'єкта table більше 0, то 
            {
                sounds.Invalid(); sounds.Press();
                MessageBox.Show("Такий логін вже існує!"); // Якщо умова істинна, то можемо стверджувати що користувач інсує
                sounds.Press();
                return true; // Якщо користувач інсує, то повертається істинне значення            
            }
            else
                return false; //А якщо ж користувача НЕ інсує, то повертається хибне значення
        }

        public void regForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sounds.Close();
            DialogResult result = MessageBox.Show("Ви впевненні?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();//Якщо вікно закривається, то відбувається завершення програми
            
            else
            if (result == DialogResult.No)
            {
                regForm point = new regForm();
                point.Show();
            }
        }

        public void pictureBoxvisible_Click(object sender, EventArgs e)
        {
            sounds.Press();
            if (passField.Text == "Введіть пароль...")
            {
                pictureBoxvisible.Image = Image.FromFile("C:\\Users\\admin\\source\\repos\\КУРСОВА\\Успішність\\Resources\\hidden.png");
                passField.UseSystemPasswordChar = false;
            }
            if (passField.UseSystemPasswordChar == true)
            {
                pictureBoxvisible.Image = Image.FromFile("C:\\Users\\admin\\source\\repos\\КУРСОВА\\Успішність\\Resources\\view1.png");
                passField.UseSystemPasswordChar = false;
            }
            else
            {
                pictureBoxvisible.Image = Image.FromFile("C:\\Users\\admin\\source\\repos\\КУРСОВА\\Успішність\\Resources\\hidden.png");
                passField.UseSystemPasswordChar = true;
            }
        }
     
        private void pictureBoxvisible_Click_1(object sender, EventArgs e)
        {
            sounds.Press();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sounds.Press();
            this.Hide();
            ListUsersForm list = new ListUsersForm();
            list.Show();
        }
 
        private void buttonRegister_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void pictureBoxvisible_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }

        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            sounds.Hovering();
        }
    }
}