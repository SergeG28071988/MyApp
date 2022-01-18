using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MyApp
{
    public partial class Form2 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SalesDB.mdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string product = textBox2.Text;
            string buyer = textBox3.Text;
            string price = textBox4.Text;
            string quantity = textBox5.Text;
            string profit = textBox6.Text;
            string query = "INSERT INTO Продажи ([Код товара],Товар, Покупатель,Цена,Количество,Прибыль) VALUES (" + kod + ",'" + product + "','" + buyer + "','" + price + "','" + quantity + "','" + profit + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные добавлены");           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
