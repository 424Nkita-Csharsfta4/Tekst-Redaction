using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text_redaction
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection
                        //1.	Разработать простейший текстовый редактор,
                        //который позволяет выполнять основные операции редактирования текста,
                        //открывать и сохранять текстовый файл.

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tvc\source\repos\text_redaction\Database1.mdf;Integrated Security=True");
            cn.Open();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public  void textBox1_TextChanged(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Articles\Code\RegistrationAndLogin\Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e, SqlConnection cn)
        {
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Text_redactor text_Redactor = new Text_redactor();
            text_Redactor.Show();
            this.Width = 0;
            this.Height = 0;
          

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
