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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            if(Veritabani.BaglantiDurum())
            {
               MessageBox.Show("Veritabanı Bağlantısı başarıyla gerçekleştirildi.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musterigiris mgiris = new musterigiris();
            mgiris.Show();
            this.Hide();
        }

        private void btn_Satici_Click(object sender, EventArgs e)
        {
            yoneticigiris frmyoneticigiris = new yoneticigiris();
            frmyoneticigiris.Show();
            this.Hide();
        }

       
    }
}
