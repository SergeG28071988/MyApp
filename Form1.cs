using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MyApp
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SalesDB.mdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "salesDBDataSet.Продажи". При необходимости она может быть перемещена или удалена.
            this.продажиTableAdapter.Fill(this.salesDBDataSet.Продажи);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Продажи WHERE [Код товара] =" + kod;
            OleDbCommand command = new OleDbCommand(query,myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Товар удалён");
            this.продажиTableAdapter.Fill(this.salesDBDataSet.Продажи);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Продажи SET Товар ='" + textBox3.Text + "'WHERE [Код товара]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Товар изменён");
            this.продажиTableAdapter.Fill(this.salesDBDataSet.Продажи);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Продажи SET Покупатель ='" + textBox4.Text + "'WHERE [Код товара]=" + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Покупатель изменён");
            this.продажиTableAdapter.Fill(this.salesDBDataSet.Продажи);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Owner = this;
            f2.Show();        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.продажиTableAdapter.Fill(this.salesDBDataSet.Продажи);
        }

        private void товарПоЦенеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Owner = this;
            f3.Show();

        }

        private void поПокупателюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Owner = this;
            f4.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Owner = this;
            f5.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
