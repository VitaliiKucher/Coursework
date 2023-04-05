using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MyLib;



namespace Успішність
{
    public partial class LoginForm : Form
    {
        Database db = new Database();
        Sounds sound = new Sounds();
        public LoginForm()
        {
            InitializeComponent();
            passField.Text = "Введіть пароль...";
            passField.ForeColor = Color.Gray;
            loginField.Text = "Введіть логін...";
            passField.ForeColor = Color.Gray;
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

        public void loginField_Enter(object sender, EventArgs e) //Створено подію Enter, яка спрацьовує при введенні чого-небудь в TextBox з назвою loginField.
        {          
            if (loginField.Text == "Введіть логін...") // Якщо текст всередині поля дорівнює "Введіть логін...", то
            {
                loginField.Text = ""; // Якщо умова істинна, то відбувається очищення поля від тексту, в інших випадках елемент очищатися не буде
                loginField.ForeColor = Color.Black; //Якщо умова істинна, то відбувається задання чорного кольору для тексту всередині поля
            }
        }
        public void loginField_Leave(object sender, EventArgs e) //Створено подію Leave, яка спрацьовує при виході із елемента управління TextBox з назвою loginField. 
        {        
            if (loginField.Text == "") //Якщо текст всередині поля пустий, то
            {
                loginField.Text = "Введіть логін..."; // Якщо умова істинна, то текст всередині поля буде "Введіть логін..."
                loginField.ForeColor = Color.Gray; // Якщо умова істинна, то відбувається задання сірого кольору для тексту всередині поля
            }
        }

      
        public void buttonLogin_Click(object sender, EventArgs e) // Працюємо з елементом управління "Кнопка" з назвою buttonLogin
        {              
            sound.Press();
            String loginUser = loginField.Text;//В змінну loginUser записуємо данні, які ми отримали від користувача
            String passUser = passField.Text;//В змінну passUser записуємо данні, які ми отримали від користувача
                                             //
            DataTable table = new DataTable(); //Сторюємо об'єкт, з яким будемо працювати в майбутньому
            MySqlDataAdapter adapter = new MySqlDataAdapter(); //Сторюємо об'єкт, з яким будемо працювати в майбутньому

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.getConnection());//Вказали деяку команду, яка повинна виконатись по відношенню до бази даних. Вказали до якої бази даних м підключаємось - db.getConnection() 
            //@uL та @uP це деякі 'Заглушки', які збільшують рівень захисту бази данних
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser; //Замість 'заглушки @uL' вказали конктрентну змінну loginUser
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser; //Замість 'заглушки @UP' вказали конктрентну змінну passUser
            adapter.SelectCommand = command; //Обрали потрібну комманду та виконали її
            adapter.Fill(table); //Всі ті данні які ми отримали, ми помістили всередину об'єкта table, який просто являється табличкою, в якій ми можемо зручно працювати з кожним іх об'єктів

            if (loginField.Text == "Введіть логін...") //Якщо поле порожнє, то 
            {
                sound.Invalid();
                MessageBox.Show("Введіть логін!");// Якщо умова істинна, то буде виведене вікно з надписом "Вигадайте логін!"
                sound.Press();
                return; //Вихід з функції
            }

            if (passField.Text == "")//Якщо поле порожнє, то 
            {
                sound.Invalid();
                MessageBox.Show("Введіть пароль!");//Якщо умова істинна, то буде виведене вікно з надписом "Вигадайте пароль!"
                sound.Press();
                return;//Вихід з функції
            }


            if (loginField.Text == "admin" && passField.Text == "admin") //Якщо в полях написне слово admin , то 
            {
                MessageBox.Show("Вітаю Ваше Святосте!!!");// Якщо умова істинна, то буде виведене вікно з надписом "Вітаю Ваше Святосте!!!"
                sound.Press();
                this.Hide(); //Звертаємось до вікна LoginForm та ховаємо його, тобто ховаєто вікно авторизації
                ADMINMainForm mainForm = new ADMINMainForm(); //Звертаємось до класу ADMINMainForm та створюємо на його основі деякий об'єкт mainForm і вижіляємо під нього пам'ять 
                mainForm.Show();//Звертаємось до вікна RegisterForm та ховаємо його, тобто ховаєто вікно авторизації
                return;//Вихід з функції
            }
            else
            if (table.Rows.Count > 0) //Якщо кількість рядків у об'єкта table більше 0, то 
            {
                MessageBox.Show("Ви успішно авторизувалися!"); // Якщо умова істинна, то можемо стверджувати що користувач інсує і він авторизований
                sound.Press();
                this.Hide(); //Звертаємось до вікна LoginForm та ховаємо його, тобто ховаєто вікно авторизації
                USERMainForm mainForm = new USERMainForm();//Звертаємось до класу USERMainForm та створюємо на його основі деякий об'єкт mainForm і вижіляємо під нього пам'ять 
                mainForm.Show();////Звертаємось до об'єкту mainForm і функції Show(), яка дозволить нам відкрити головне вікно USERMainForm
            }
            else
            {
                sound.Invalid();
                MessageBox.Show("Невірний логін або пароль!"); // Якщо ж умова хибна, то користувача не існує
                sound.Press();
            }
        }  
  
        public void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sound.Press();
            this.Hide(); //Звертаємось до вікна LoginForm та ховаємо його, тобто ховаєто вікно авторизації
            RegisterForm registerForm = new RegisterForm();//Звертаємось до класу RegisterForm та створюємо на його основі деякий об'єкт registerForm і вижіляємо під нього пам'ять 
            registerForm.Show();//Звертаємось до об'єкту registerForm і функції Show(), яка дозволить нам відкрити вікно реєстрації RegisterForm.cs
        }

        public void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sound.Close();
        }

        public void pictureBoxvisible_Click(object sender, EventArgs e)
        {
            sound.Press();
            if (passField.Text == "Введіть пароль...")
            {
                pictureBoxvisible.Image = Image.FromFile(@"C://Users//admin//source//repos//КУРСОВА//Успішність//Resources//hidden.png");
                passField.UseSystemPasswordChar = false;
            }
            else
            if (passField.UseSystemPasswordChar == true)
            {
                pictureBoxvisible.Image = Image.FromFile(@"C://Users//admin//source//repos//КУРСОВА//Успішність//Resources//view1.png"); 
                passField.UseSystemPasswordChar = false;
            }
            else
            {
                pictureBoxvisible.Image = Image.FromFile(@"C://Users//admin//source//repos//КУРСОВА//Успішність//Resources//hidden.png");
                passField.UseSystemPasswordChar = true;
            }
            sound.Press();
        }

        private void pictureBoxvisible_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void buttonLogin_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }

        private void RegisterlinkLabel_MouseEnter(object sender, EventArgs e)
        {
            sound.Hovering();
        }
    }
}