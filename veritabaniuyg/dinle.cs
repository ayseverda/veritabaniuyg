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
    public partial class dinle : Form
    {
        public dinle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345");

        private void button3_Click(object sender, EventArgs e)
        {
            // Listeleme işlemi
            string sorgu = "select * from dinlenmesayisi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void button1_Click(object sender, EventArgs e)
        {    //ekle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into dinlenmesayisi (dinlenmeid,sarkiid,kacdkdinledin,toplamdinlenmeid) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("eklendi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
