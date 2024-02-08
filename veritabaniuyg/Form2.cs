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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            //ekle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into sarkidegerlendirme (degerlendirmeid,sarkiid,puan,yorum) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));

            // textBox3'ten gelen metni alın
            string metin = textBox3.Text;

            // metni tamsayıya dönüştürmeye çalışın
            if (int.TryParse(metin, out int deger))
            {
                // Değerin 1 ile 10 arasında olup olmadığını kontrol edin
                if (deger >= 1 && deger <= 10)
                {
                    // Geçerli bir değer olduğunda parametreyi ekleyin
                    komut1.Parameters.AddWithValue("@p3", deger);
                }
                else
                {
                    // Hata mesajı veya kullanıcıya bilgi verme işlemi
                    MessageBox.Show("Lütfen 1 ile 10 arasında bir değer girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Hata mesajı veya kullanıcıya bilgi verme işlemi
                MessageBox.Show("Geçerli bir sayı değeri girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            komut1.Parameters.AddWithValue("@p4", textBox4.Text);

            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from sarkidegerlendirme where degerlendirmeid=@p1", baglanti);

            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            MessageBox.Show("silmek istedigine emin misin", "bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guncelle
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update sarkidegerlendirme set sarkiid=@p2,puan=@p3,yorum=@p4 where degerlendirmeid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text)); //sanatciid
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text)); //puan
            komut3.Parameters.AddWithValue("@p4", textBox4.Text);            //yorum
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("guncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //listeleme
            string sorgu = "select * from sarkidegerlendirme";
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

