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
    internal partial class secimKARGO : Form
    {
        double toplam = 0;
        public secimKARGO()
        {
            InitializeComponent();
           toplam = urunSiparisi.uruntoplam;
            lbl_toplamtutar.Text ="Toplam Tutar:"+ toplam.ToString("0.00")+"$";
           
        }

        public double toplamkargo;
        
        private void button1_Click(object sender, EventArgs e)
        {
            urunSiparisi urun = new urunSiparisi();
            urun.Show();
            this.Hide();
            
        }

        

        private void btn_siparis_tamamla_Click(object sender, EventArgs e)
        {
            if (rb_kara.Checked || rb_hava.Checked || rb_deniz.Checked)
            {
                
                Veritabani.FaturaEkle(toplam.ToString());
                
            }
            else
            {
                MessageBox.Show("Lütfen kargo türü seçiniz.");
            }
            

        }

        private void rb_kara_CheckedChanged(object sender, EventArgs e)
        {
            toplamkargo = 1000;
            toplam = urunSiparisi.uruntoplam + toplamkargo;
            lbl_toplamtutar.Text = "Toplam Tutar:" + toplam.ToString("0.00") + "$";
        }

        private void rb_hava_CheckedChanged(object sender, EventArgs e)
        {
            toplamkargo = 2000;
            toplam = urunSiparisi.uruntoplam + toplamkargo;
            lbl_toplamtutar.Text = "Toplam Tutar:" + toplam.ToString("0.00") + "$";
        }

        private void rb_deniz_CheckedChanged(object sender, EventArgs e)
        {
            toplamkargo = 750;
            toplam = urunSiparisi.uruntoplam + toplamkargo;
            lbl_toplamtutar.Text = "Toplam Tutar:" + toplam.ToString("0.00") + "$";
        }
     }
       
    }
