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

    public partial class ComparForm : Form
    {
        Database database = new Database();
        Sounds sounds = new Sounds();


        int[] array = new int[100];
        int j;
        int i = 0;
        public ComparForm()
        {
            InitializeComponent();
        }


        public void arrayadd(int[] a, int i)
        {
            array = a;
            j = i;
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
        }
        public void ReadSingleRow(DataGridView dataGridView1, IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), record.GetInt32(6), record.GetInt32(7), record.GetInt32(8), record.GetInt32(9));
        }

        public void RefreshDataGrid(DataGridView dataGridView1)
        {
            string queryString = $"select * from points where id = '{array[i]}'";

            MySqlCommand command = new MySqlCommand(queryString, database.getConnection());

            database.openConnection();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                ReadSingleRow(dataGridView1, reader);
            reader.Close();
        }


        private void ComparForm_Load(object sender, EventArgs e)
        {          
            CreateColumns();
            while (i <= j) 
            {
                RefreshDataGrid(dataGridView1);
                i++;
            }
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

        }

        private void ComprButton_Click(object sender, EventArgs e)
        {                   
        }

        private void Comparisonbutton_Click(object sender, EventArgs e)
        {
        //    for (; i <= j; i++)
        //    {
        //        RefreshDataGrid(dataGridView1);
        //    }
            this.Hide();
            PointForm adm = new PointForm();
            adm.Show();
        }
    }
}