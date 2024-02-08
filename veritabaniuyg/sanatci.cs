using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veritabaniuyg
{
    public partial class sanatci : Form
    {
        public sanatci()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345");

        private void button1_Click(object sender, EventArgs e)
        {
            //ekle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into sanatci (sanatciid,sanatciadi,sanatciulke,solosanatciid) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", textBox3.Text);
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));

            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sil
            // Bağlantıyı açın
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from sanatci where sanatciid=@p1", baglanti);

            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            MessageBox.Show("silmek istedigine emin misin", "bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guncelle
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update sanatci set sanatciadi=@p1,sanatciulke=@p2,solosanatciid=@p4 where sanatciid=@p3", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox2.Text);
            komut3.Parameters.AddWithValue("@p2", textBox3.Text);
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("guncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //listeleme
            string sorgu = "select * from sanatci";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();

            this.Close();

        }
    }
}