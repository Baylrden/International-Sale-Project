using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Otomasyon
{
    public partial class SifreYenile : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        SqlDataReader dr;
        public static string SqlCon = @"Data Source=DESKTOP-S558N0I\SQLEXPRESS;Initial Catalog = 202503518; Integrated Security = True";

        
        public int sonuc = 0;

        private void SifreYenile_Load(object sender, EventArgs e)
        {
            Captcha();
        }
        public void Captcha()
        {
            Random r = new Random();
            int n1 = r.Next(0, 50);
            int n2 = r.Next(0, 50);
            lblCaptcha.Text = n1.ToString() + "+" + n2.ToString() + "=";
            sonuc = n1 + n2;

        }


        public SifreYenile()
        {
            InitializeComponent();
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (txtCaptcha.Text==sonuc.ToString())
            {
                if (txtYeniSifre.Text==txtYeniSifreTekrar.Text)
                {
                    EskiSifreKontrol();
                }
                else
                {
                    MessageBox.Show("Yeni şifreyle tekrarı eşleşmiyor.");
                    Captcha();
                }


            }
            else
            {
                MessageBox.Show("Captcha Hatalı Girildi.");
                Captcha();
            }


        }

        public void EskiSifreKontrol()
        {
            string sorgu = "select * from Tbl_Yonetici where kullaniciadi='admin1' and sifre=@password";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);

            
            cmd.Parameters.AddWithValue("@password", Veritabani.Md5sifrele(txtEskiSifre.Text));



            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                guncelle();

                con.Close();
            }
            else
            {
                MessageBox.Show("Eski Şifreniz hatalı.");

                con.Close();

               
            }
        }
        public void guncelle()
        {
            string updatesorgu = "update Tbl_Yonetici set sifre=@pass where kullaniciadi='admin1'";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(updatesorgu, con);
            cmd.Parameters.AddWithValue("@pass", Veritabani.Md5sifrele(txtYeniSifre.Text));
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Degisti");
            con.Close();


        }

       
    }
}
