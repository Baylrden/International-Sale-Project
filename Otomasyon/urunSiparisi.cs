using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon
{
    public partial class urunSiparisi : Form
    {
        public static double uruntoplam=0;
        public static double urunfiyat = 0;
        
        public urunSiparisi()
        {
            InitializeComponent();

            Veritabani.cmb_aktar(comboBox_Kategori, "Select distinct UrunKategori from Tbl_Urunler","UrunKategori");
            pictureBox4.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //kargo formu
            secimKARGO formkargo = new secimKARGO();
            formkargo.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //sifre guncelle
            MusteriSifreYenile Ms = new MusteriSifreYenile();
            Ms.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sepet bosalt
            comboBox_Kategori.Text = "";
            comboBox_Model.Text = "";
            numericupdown1.Value = 0;
            pictureBox4.Image = null;
            lbltoplam.Text = "0.00$";
            uruntoplam = 0;
            
           
        }

        

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            urunfiyat = Convert.ToDouble(Veritabani.urunFiyati);
            double numeric = Convert.ToDouble(numericupdown1.Value);
            uruntoplam = (urunfiyat * numeric) + uruntoplam;
            lbltoplam.Text ="Toplam Tutar:"+ uruntoplam.ToString("0.00")+"$";
            
        }

        private void comboBox_Kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Model.Items.Clear();

            Veritabani.cmb_aktar(comboBox_Model, "Select * from Tbl_Urunler where UrunKategori='" + comboBox_Kategori.Text + "'","UrunAdi");
        }

        private void comboBox_Model_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            Veritabani.urunAktar(comboBox_Model.Text);

            double fiyat = Convert.ToDouble(Veritabani.urunFiyati);
            lbl_urunFiyat.Text = fiyat.ToString("0.00")+"$";
            pictureBox4.ImageLocation = Veritabani.urunResim;
            urunIsim.Text = Veritabani.urunAd;
        }

        private void urunSiparisi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
