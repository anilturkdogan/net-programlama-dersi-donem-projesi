using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje
{
    public partial class Form1 : Form
    {
        SqlConnection baglan;
        SqlCommand komut;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox2.Text;
            string pass = textBox3.Text;
            SqlConnection baglan = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=kargo;Integrated Security=True");
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "SELECT * FROM tblUser where username='" + textBox2.Text + "' AND password='" + textBox3.Text + "'";
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Başarılı bir şekilde giriş yaptınız. Yönlendiriliyorsunuz.");
                baglan.Close();
                Form2 ff2 = new Form2();
                ff2.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int agr;
            agr = Convert.ToInt32(textBox1.Text);
            
            if (agr<10)
            {
                MessageBox.Show("Ücret:20TL");
            }
            else if (agr<20)
            {
                MessageBox.Show("Ücret:30TL");
            }
            else if (agr<30)
            {
                MessageBox.Show("Ücret:50TL");
            }
            else if (agr<1000)
            {
                MessageBox.Show("Ücret: En az 60TL");
            }
        }
    }
}
