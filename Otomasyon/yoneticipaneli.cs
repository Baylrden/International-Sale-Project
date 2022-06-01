using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Otomasyon
{
    public partial class yoneticipaneli : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public static string SqlCon = @"Data Source=DESKTOP-S558N0I\SQLEXPRESS;Initial Catalog = 202503518; Integrated Security = True";
        public yoneticipaneli()
        {
            InitializeComponent();
            islemler();
            txtkullanici.Text = yoneticigiris.yoneticikullanici;
            yoneticiarama();
            btn_guncelle.Visible = false;
            urun_guncelle.Enabled = false;

            comboBox1.Items.Add("Modal");
            comboBox1.Items.Add("Star");
            comboBox1.Items.Add("Retro");


        }
        public void yoneticiarama()
        {
            txteposta.Visible = false;
            msktelefon.Visible = false;
            txtsirketisim.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            
            Veritabani.yoneticiara("Select * from Tbl_Yonetici where kullaniciadi='"+txtkullanici.Text +"'");
            
        }

        public void temizle()
        {
            txt_urunadi.Clear();
            txt_urunfiyati.Clear();
            comboBox1.Text = "";
            pictureBox1.Image = null;
        }

        public void islemler()
        {
            gb_guncelle.Visible = false;
            gb_sil.Visible = false;
            gb_edit.Visible = false;
            gb_fatura.Visible = false;
            
        }
        

        private void hesapAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islemler();
            gb_guncelle.Visible = true;
            gb_sil.Visible = true;
        }

        private void geçmişFaturalarıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            islemler();
            gb_fatura.Visible = true;
            Veritabani.GrideAktar("select kullanici,ToplamTutar,telefon,eposta,IslemTarihi,IslemSaati from Tbl_Fatura INNER JOIN Tbl_Musterikayit on Tbl_Musterikayit.id=Tbl_Fatura.MusteriId", dataGridView2);
            dataGridView2.Columns[0].HeaderText = "Kullanıcı Adı";
            dataGridView2.Columns[1].HeaderText = "Toplam Tutar";
            dataGridView2.Columns[2].HeaderText = "Telefon";
            dataGridView2.Columns[3].HeaderText = "E-Posta";
            dataGridView2.Columns[4].HeaderText = "İşlem Tarihi";
            dataGridView2.Columns[5].HeaderText = "İşlem Saati";


        }

        private void duyuruYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islemler();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            islemler();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                yoneticiarama();
                txtkullanici.Text = Veritabani.kullanici;
                
                
            }
            else if (radioButton2.Checked)
            {
                
                Veritabani.kullaniciara("select * from Tbl_Musterikayit where kullanici='" + txtkullanici.Text + "'");
                

                txtkullanici.Text = Veritabani.kullanici;
                txteposta.Text = Veritabani.eposta;
                //txtsifre.Text= Veritabani.sifre;
                txtsirketisim.Text = Veritabani.sirketisim;
                msktelefon.Text = Veritabani.telefon;
            }
            btn_guncelle.Visible = true;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btn_arama.Visible = true;
            btn_guncelle.Visible = false;
            txteposta.Visible = false;
            msktelefon.Visible = false;
            txtsirketisim.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btn_arama.Visible = true;
            btn_guncelle.Visible = false;

            txteposta.Visible = true;
            msktelefon.Visible = true;
            txtsirketisim.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtsifre.Visible = true;
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                string yenisifre = Veritabani.Md5sifrele(txtsifre.Text);
                if (radioButton5.Checked & radioButton1.Checked)
                {
                    if (txtkullanici.Text!="" & txtsifre.Text!="")
                    {
                        Veritabani.yoneticiguncelle(txtkullanici.Text, yenisifre);
                    }
                    else 
                    {
                        MessageBox.Show("Boş alan bırakmayınız");
                    }
                }
                else if (radioButton5.Checked & radioButton2.Checked)
                {
                    if (txtkullanici.Text != "" & txtsifre.Text!="" & txteposta.Text != "" & txtsirketisim.Text != "" & msktelefon.Text != "")
                    {
                        Veritabani.musteriguncelle(txtkullanici.Text, txtsirketisim.Text, msktelefon.Text, txteposta.Text, yenisifre);
                    }
                    else
                    {
                        MessageBox.Show("Boş alan bırakmayınız");
                    }
                }

            }
            else 
            {
                if (radioButton2.Checked)
                {
                    if (txtkullanici.Text!="" & txteposta.Text!="" & txtsirketisim.Text!="" & msktelefon.Text!="")
                    {
                        Veritabani.musteriguncelle(txtkullanici.Text, txtsirketisim.Text, msktelefon.Text, txteposta.Text, Veritabani.sifre);
                    }

                    else
                    {
                        MessageBox.Show("Boş alan bırakmayınız");
                    }
                }
                else if (radioButton1.Checked)
                {
                    if (txtkullanici.Text!="")
                    {
                        Veritabani.yoneticiguncelle(txtkullanici.Text, Veritabani.sifre);

                    }
                    else
                    {
                        MessageBox.Show("Boş alan bırakmayınız");
                    }

                }
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            string sorgu1, sorgu2;
            if (radioButton4.Checked)
            {
                sorgu1 = "Select * From Tbl_Yonetici where kullaniciadi='" + textBox3.Text + "'";
                sorgu2 = "Delete from Tbl_Yonetici where kullaniciadi = '" + textBox3.Text + "'";
                Veritabani.kullanicikontrol(sorgu1, sorgu2);

            }
            else if (radioButton3.Checked)
            {
                sorgu1 = "Select * From Tbl_Musterikayit where kullanici='" + textBox3.Text + "'";
                sorgu2 = "Delete from Tbl_Musterikayit where kullanici = '" + textBox3.Text + "'";
                Veritabani.kullanicikontrol(sorgu1, sorgu2);
            }
            else
            {
                MessageBox.Show("Lütfen Müşteri veya Yönetici seçimi yapınız!");
            }
        }

        

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            temizle();
   
        }

        private void urun_Ekle_Click(object sender, EventArgs e)
        {
 
            if (txt_urunadi.Text!="" & txt_urunfiyati.Text!=""&comboBox1.Text!="" & pictureBox1.Image!=null)
            {
                Veritabani.urunEkle(txt_urunadi.Text,txt_urunfiyati.Text,imagepath,comboBox1.Text);
                temizle();
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
        }

        private void urun_Sil_Click(object sender, EventArgs e)
        {
            if (txt_urunadi.Text!="")
            {
                Veritabani.Urunsil(txt_urunadi.Text);
                temizle();
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
        }
        string imagepath;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seçiniz";
            openFileDialog1.Filter = "PNG dosyaları(*.png)|*.png";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;

            }
        }

        private void ürünEklesilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            islemler();
            gb_edit.Visible = true;
           



        }

        private void urun_guncelle_Click(object sender, EventArgs e)
        {
            
            if (txt_urunadi.Text!="" & txt_urunfiyati.Text!="" )
            {
                Veritabani.Urunguncelle(txt_urunadi.Text, txt_urunfiyati.Text,comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }

            
            
        }

        private void urun_Ara_Click(object sender, EventArgs e)
        {
            txt_urunfiyati.Clear();
            if (txt_urunadi.Text!="" )
            {
                Veritabani.Urunara("select * From Tbl_Urunler where UrunAdi='" + txt_urunadi.Text + "'");
                if (txt_urunadi.Text == Veritabani.UrunAdi)
                {
                   
                    txt_urunadi.Text = Veritabani.UrunAdi;
                    txt_urunfiyati.Text = Veritabani.UrunFiyati;
                    pictureBox1.ImageLocation = Veritabani.image;
                    comboBox1.Text = Veritabani.UrunKategori;
                    urun_guncelle.Enabled = true;
                    Veritabani.UrunAdi = "";
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen ürün adı giriniz.");
            }
           
        }

       void urunListele()
        {
           
            Veritabani.GrideAktar("Select UrunAdi,UrunFiyati,UrunKategori from Tbl_Urunler",dataGridView1);
            dataGridView1.Columns[0].HeaderText = "Ürün Adı";
            dataGridView1.Columns[1].HeaderText = "Ürün Fiyatı";
            dataGridView1.Columns[2].HeaderText = "Ürün Kategori";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            urunListele();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gb_edit_Enter(object sender, EventArgs e)
        {

        }
        string mkadi = "", saat="";
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            mkadi= dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            textBox6.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            textBox7.Text = Convert.ToDateTime(dataGridView2.Rows[secilen].Cells[4].Value).ToString("dd-MM-yyyy");
            textBox8.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            saat= dataGridView2.Rows[secilen].Cells[5].Value.ToString();






        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox6.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Veritabani.GrideAktar("select kullanici,ToplamTutar,telefon,eposta,IslemTarihi,IslemSaati from Tbl_Fatura INNER JOIN Tbl_Musterikayit on Tbl_Musterikayit.id=Tbl_Fatura.MusteriId", dataGridView2);
            dataGridView2.Columns[0].HeaderText = "Kullanıcı Adı";
            dataGridView2.Columns[1].HeaderText = "Toplam Tutar";
            dataGridView2.Columns[2].HeaderText = "Telefon";
            dataGridView2.Columns[3].HeaderText = "E-Posta";
            dataGridView2.Columns[4].HeaderText = "İşlem Tarihi";
            dataGridView2.Columns[5].HeaderText = "İşlem Saati";
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FaturaRapor formyazdir = new FaturaRapor();
            formyazdir.Show();
            
        }

        private void yoneticipaneli_Load(object sender, EventArgs e)
        {
            islemler();
            gb_edit.Visible = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Veritabani.FaturaSil(mkadi,saat);

        }
    }
}
