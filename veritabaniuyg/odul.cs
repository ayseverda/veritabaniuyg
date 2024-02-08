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
    public partial class odul : Form
    {
        public odul()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {
            //ekle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into odul (odulid,oduladi,sarkiid,sanatciid) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3",int.Parse(sarkibox.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox3.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sil
            // Bağlantıyı açın
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from odul where odulid=@p1", baglanti);

            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            MessageBox.Show("silmek istedigine emin misin", "bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guncelle
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update odul set oduladi=@p1,sarkiid=@p2,sanatciid=@p3 where odulid=@p4", baglanti);
            komut3.Parameters.AddWithValue("@p1", textBox2.Text);
            komut3.Parameters.AddWithValue("@p2", int.Parse(sarkibox.Text));
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox3.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("guncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Listeleme işlemi
            string sorgu = "select * from odul";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            // odulalanSanatciSayisi adlı SQL fonksiyonunu çağırma ve sonucu dataGridView2'ye atama
            try
            {
                using (var conn = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345"))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("SELECT odulalanSanatciSayisi(@sanatci_id)", conn))
                    {
                        cmd.Parameters.AddWithValue("@sanatci_id", int.Parse(textBox3.Text));

                        NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(cmd);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        dataGridView2.DataSource = ds1.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
            try
            {
                using (var conn = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345"))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("SELECT odulalanSarkiSayisi(@sarki_id)", conn))
                    {
                        cmd.Parameters.AddWithValue("@sarki_id", int.Parse(sarkibox.Text));

                        NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);
                        dataGridView3.DataSource = ds2.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


        

    }
}
