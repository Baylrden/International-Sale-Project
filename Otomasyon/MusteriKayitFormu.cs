using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Otomasyon
{
    public partial class Musterikayitformu : Form
    {
        public Musterikayitformu()
        {
            InitializeComponent();
        }

        

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            if (txtkullanici.Text!="" & txteposta.Text!="" & txtsifre.Text!="" & txtsirketisim.Text!="" & msktelefon.Text!="")
            {
                Veritabani.kayit(txtkullanici.Text, txtsirketisim.Text, msktelefon.Text, txteposta.Text, txtsifre.Text);
                MessageBox.Show("Kayıt başarıyla tamamlandı.Giriş paneline yönlendiriliyorsunuz...");
                musterigiris formgiris = new musterigiris();
                formgiris.Show();
                this.Hide();
               
               
                
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            } 
        }
    }
}
