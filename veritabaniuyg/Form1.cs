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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        private void button2_Click(object sender, EventArgs e)
            {
                // Form2'yi oluşturup göster
                sanatci form2 = new sanatci();
                form2.Show();

                // Form1'i kapat
                this.Hide();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                album form3 = new album();
                form3.Show();
                this.Hide();
            }

            private void button11_Click(object sender, EventArgs e)
            {
                sanatcideger form4 = new sanatcideger();
                form4.Show();
                this.Hide();
            }

            private void button16_Click(object sender, EventArgs e)
            {
                // Form2'yi oluşturup göster
                grupuye form2 = new grupuye();
                form2.Show();

                // Form1'i kapat
                this.Hide();
            }

            private void button8_Click(object sender, EventArgs e)
            {
                kullanici form2 = new kullanici();
                form2.Show();

                // Form1'i kapat
                this.Hide();

            }

            private void button13_Click(object sender, EventArgs e)
            {
                tur form2 = new tur();
                form2.Show();
                this.Hide();
            }

            private void button5_Click(object sender, EventArgs e)
            {
                ens form = new ens();
                form.Show();
                this.Hide();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                sarkilar form = new sarkilar();
                form.Show();
                this.Hide();

            }

            private void button12_Click(object sender, EventArgs e)
            {
                Form2 form = new Form2();
                form.Show();
                this.Hide();
            }

            private void button4_Click(object sender, EventArgs e)
            {
                playlist form = new playlist();
                form.Show();
                this.Hide();
            }

        private void button7_Click(object sender, EventArgs e)
        {
            odul form = new odul();
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gecmis form = new gecmis();
            form.Show(); this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            indir form = new indir();
            form.Show(); this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dinle form5 = new dinle();
            form5.Show();
            this.Hide();
        }
    }
    }
