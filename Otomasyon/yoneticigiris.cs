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
    public partial class yoneticigiris : Form
    {
   
        
        public yoneticigiris()
        {
            InitializeComponent();
            
        }


        public static string yoneticikullanici;

        private void button1_Click(object sender, EventArgs e)
        {
            yoneticikullanici = txtkullanici.Text;
            Veritabani.yoneticilogin(txtkullanici.Text, txtsifre.Text);
            
        }

        
    }
}

