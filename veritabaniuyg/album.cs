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
    public partial class album : Form
    {
        public album()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345");
        private void album_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into album (albumid,albumadi,sanatciid) values (@p1,@p2,@p3)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
           // komut1.Parameters.AddWithValue("@p4", dateTimePicker1);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("eklendi");

        }

        private void button2_Click(object sender, EventArgs e)
        { //sil
          // Bağlantıyı açın
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from album where albumid=@p1", baglanti);

            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            MessageBox.Show("silmek istedigine emin misin", "bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guncelle
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update album set albumadi=@p1,sanatciid=@p2 where albumid=@p3", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox2.Text);
            komut3.Parameters.AddWithValue("@p2", int.Parse(textBox3.Text));
            komut3.Parameters.AddWithValue("p3", int.Parse(textBox1.Text));
           // komut3.Parameters.AddWithValue("@p4", dateTimePicker1);
            komut3.ExecuteNonQuery();
            MessageBox.Show("guncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //listeleme
            string sorgu = "select * from album";
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
