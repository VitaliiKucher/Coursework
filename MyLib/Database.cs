using MySql.Data.MySqlClient;

namespace MyLib
{
    public class Database
    {
        //Команда для підключення до бази данних MySql
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=termpaper");
             
        public void openConnection() //Функція яка відкриває з'єднання з базою данних
        {
            if (connection.State == System.Data.ConnectionState.Closed) //Перевірка: Якщо стан бази даних закритий, то
                connection.Open(); // Відкриваємо з'єднання з базою даних
        }
    
        public void closeConnection()  //Функція яка закриває з'єднання з базою данних
        {
            if (connection.State == System.Data.ConnectionState.Open) //Перевірка: Якщо стан бази даних відкритий, то
                connection.Close(); // Закриваємо з'єднання з базою даних
        }

        //Функція, яка повертає з'єднання з базою даних
        public MySqlConnection getConnection() //Ця функція повертає коткретний об'єкт від класу MySqlConnection(Саме цей об'єкт ми повертаємо) 
        {
            return connection; //Повертається об'єкт з назвою connection
        }
    }
}