﻿using Npgsql;
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
    public partial class sarkilar : Form
    {
        public sarkilar()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=sarkilar; user Id=postgres; password=12345");
        private void button1_Click(object sender, EventArgs e)
        {

            //ekle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into sarkilar (sarkiid,sarkiadi,sanatciid,turid,dil,sure) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut1.Parameters.AddWithValue("@p5", textBox5.Text);
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));

            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("eklendi");

        }

        private void button2_Click(object sender, EventArgs e)
        {//sil
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from sarkilar where sarkiid=@p1", baglanti);

            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut2.ExecuteNonQuery();
            MessageBox.Show("silmek istedigine emin misin", "bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //guncelle
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update sarkilar set sarkiadi=@p2,sanatciid=@p3,turid=@p4,dil=@p5,sure=@p6 where sarkiid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut3.Parameters.AddWithValue("@p2", textBox2.Text);
            komut3.Parameters.AddWithValue("@p3", int.Parse(textBox3.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
            komut3.Parameters.AddWithValue("@p5", textBox5.Text);
            komut3.Parameters.AddWithValue("@p6", int.Parse(textBox6.Text));
            komut3.ExecuteNonQuery();
            MessageBox.Show("guncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //listeleme
            string sorgu = "select * from sarkilar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form= new Form1();
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sarkiAdi = textBox7.Text;
            string sorgu = "SELECT * FROM sarkilar WHERE sarkiadi ILIKE @p1";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", "%" + sarkiAdi + "%");

            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
