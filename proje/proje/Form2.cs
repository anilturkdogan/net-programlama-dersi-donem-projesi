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
    public partial class Form2 : Form
    {
        SqlConnection baglan;
        SqlCommand komut;
        SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }
        void musterigetir()
        {
            SqlConnection baglan = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=kargo;Integrated Security=True");
            baglan.Open();
            da = new SqlDataAdapter("SELECT*FROM musteri1", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            musterigetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(3000000, 4000000);

            SqlConnection baglan = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=kargo;Integrated Security=True");

            string sorgu="INSERT INTO musteri1(takipno,ad,soyad,cikis,varis,agirlik) VALUES (@takipno,@ad,@soyad,@cikis,@varis,@agirlik)";
            baglan.Open();
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@takipno", sayi);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@cikis", comboBox1.Text);
            komut.Parameters.AddWithValue("@varis", comboBox2.Text);
            komut.Parameters.AddWithValue("@agirlik", textBox5.Text);
            
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt başarılı, size kayıtlı iletişim bilgileriniz üzerinden ulaşacağız.");
            musterigetir();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
