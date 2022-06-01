using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace Otomasyon
{
    class Veritabani
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        static DataSet ds;
        static SqlDataReader dr;
        public static string SqlCon = @"Data Source=DESKTOP-S558N0I\SQLEXPRESS;Initial Catalog = 202503518; Integrated Security = True";


        public static string Md5sifrele(string metin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(metin);

            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }

        public static void yoneticilogin(string kullanciciadi,string sifre)
        {
            string sorgu = "select * from Tbl_Yonetici where kullaniciadi=@user and sifre=@password";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);

            cmd.Parameters.AddWithValue("@user", kullanciciadi);
            cmd.Parameters.AddWithValue("@password", Veritabani.Md5sifrele(sifre));



            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş başarılı");

                

                yoneticipaneli formyonetici = new yoneticipaneli();
                Form.ActiveForm.Hide();
                formyonetici.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                
                con.Close();
            }
        }

        public static string musterikullanici,musterid;
        public static void musterilogin(string kullanciciadi, string sifre)
        {
            musterikullanici = kullanciciadi;
            string sorgu = "select * from Tbl_Musterikayit where kullanici=@user and sifre=@password";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);

            cmd.Parameters.AddWithValue("@user", kullanciciadi);
            cmd.Parameters.AddWithValue("@password", Veritabani.Md5sifrele(sifre));



            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş başarılı");
                musterid = dr["id"].ToString();
                urunSiparisi uS = new urunSiparisi();
                
                musterigiris.ActiveForm.Hide();
                uS.Show();


            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");

                con.Close();
            }
        }


        public static void kayit(string kullanici, string sirketisim, string telefon, string eposta, string sifre)
        {
            con = new SqlConnection(SqlCon);
            string insertsorgu = " insert into Tbl_Musterikayit(kullanici,sirketisim,telefon,eposta,sifre) values (@kullanici,@sirket,@telefon,@eposta,@sifre)";
            cmd = new SqlCommand(insertsorgu, con);

            cmd.Parameters.AddWithValue("@kullanici", kullanici);
            cmd.Parameters.AddWithValue("@sirket", sirketisim);
            cmd.Parameters.AddWithValue("@telefon", telefon);
            cmd.Parameters.AddWithValue("@eposta", eposta);
            cmd.Parameters.AddWithValue("@sifre", Veritabani.Md5sifrele(sifre));

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }


        public static bool BaglantiDurum()
        {
            using (con = new SqlConnection(SqlCon))
            {
                
                try
                {

                    con.Open();
                    return true;
                    
                }
                catch (SqlException)
                {
                    return false;
                }
                
            }
        }
        public static string id,kullanici, sirketisim, telefon, eposta, sifre;
        public static void kullaniciara(string sorgu)
        {

            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr["id"].ToString();
                kullanici = dr["kullanici"].ToString();
                sirketisim = dr["sirketisim"].ToString();
                telefon = dr["telefon"].ToString();
                eposta = dr["eposta"].ToString();
                sifre = dr["sifre"].ToString();

                con.Close();
            }
            else
            {
                MessageBox.Show("Kayıtlarda bu kullanıcı bulunamadı.");                                
            }


        }
        public static void yoneticiara(string sorgu)
        {

            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr["id"].ToString();
                kullanici = dr["kullaniciadi"].ToString();
                sifre = dr["sifre"].ToString();
                con.Close();
            }
           
            else
            {
                MessageBox.Show("Kayıtlarda bu kullanıcı bulunamadı.");
            }
        }


        public static void musteriguncelle(string kullanici, string sirketisim, string telefon, string eposta, string sifre)
        {
            con = new SqlConnection(SqlCon);
            string insertsorgu = " update Tbl_Musterikayit set kullanici=@kullanici,sirketisim=@sirket,telefon=@telefon,eposta=@eposta,sifre=@sifre where id='" + Veritabani.id + "'";
            cmd = new SqlCommand(insertsorgu, con);

            cmd.Parameters.AddWithValue("@kullanici", kullanici);
            cmd.Parameters.AddWithValue("@sirket", sirketisim);
            cmd.Parameters.AddWithValue("@telefon", telefon);
            cmd.Parameters.AddWithValue("@eposta", eposta);
            cmd.Parameters.AddWithValue("@sifre", sifre);

            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Bilgiler başarıyla güncellendi.");
            con.Close();
        }



        public static void yoneticiguncelle(string kullanici,string sifre)
        {
            con = new SqlConnection(SqlCon);
            string insertsorgu = " update Tbl_Yonetici set kullaniciadi=@kullanici,sifre=@sifre where id='" + Veritabani.id + "'";
            cmd = new SqlCommand(insertsorgu, con);

            cmd.Parameters.AddWithValue("@kullanici", kullanici);
            cmd.Parameters.AddWithValue("@sifre", sifre);

            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Bilgiler başarıyla güncellendi.");
            con.Close();
        }

        public static void kullanicisil(string sorgu)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı başarıyla silindi.");
            con.Close();
        }

        public static void kullanicikontrol(string sorgu,string sorgu2)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                kullanicisil(sorgu2); 

            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı");

                
            }
            con.Close();
        }


        public static void urunEkle(string urunAdi,string urunFiyati,string imagepath,string urunKategori)
        {
           
           
            

            
            if (Urunkontrol(urunAdi)==false)
            {
                con = new SqlConnection(SqlCon);
                string insertsorgu = " insert into Tbl_Urunler(UrunAdi,UrunFiyati,UrunResim,UrunKategori) values (@UrunAdi,@UrunFiyati,@UrunResim,@UrunKategori)";
                cmd = new SqlCommand(insertsorgu, con);

                cmd.Parameters.AddWithValue("@UrunAdi", urunAdi);
                cmd.Parameters.AddWithValue("@UrunFiyati", urunFiyati);
                cmd.Parameters.AddWithValue("@UrunResim", imagepath);
                cmd.Parameters.AddWithValue("@UrunKategori", urunKategori);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün başarıyla eklendi.");
                con.Close();
            }
            else
            {
                
                MessageBox.Show("Ürün zaten ekli.");
            }

           
        }


        public static void Urunsil(string UrunAdi)
        {
           
            
            if (Urunkontrol(UrunAdi))
            {
                con = new SqlConnection(SqlCon);
                cmd = new SqlCommand("Delete Tbl_Urunler where UrunAdi=@UrunAdi", con);
                cmd.Parameters.AddWithValue("@UrunAdi", UrunAdi);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün başarıyla silindi.");
                con.Close();
                
            }
            else
            {
                MessageBox.Show("Ürün bulunamadı");
            }
           
           
        }


        public static void Urunguncelle(string UrunAdi, string UrunFiyati,string UrunKategori)
        {
            con = new SqlConnection(SqlCon);
            string insertsorgu = " update Tbl_Urunler set UrunFiyati=@UrunFiyati,UrunKategori=@UrunKategori where UrunAdi=@UrunAdi";
            cmd = new SqlCommand(insertsorgu, con);

            cmd.Parameters.AddWithValue("@UrunFiyati", UrunFiyati);
            cmd.Parameters.AddWithValue("@UrunAdi", UrunAdi);
            cmd.Parameters.AddWithValue("@UrunKategori", UrunKategori);

            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ürün fiyatı başarıyla güncellendi.");
            con.Close();
        }


        public static bool Urunkontrol(string UrunAdi)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand("Select * From Tbl_Urunler where UrunAdi=@UrunAdi", con);
            cmd.Parameters.AddWithValue("@UrunAdi", UrunAdi);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                con.Close();
                return true;
              
            }
            else
            {
                

                con.Close();
                return false;
            }
            
        }
        public static string UrunAdi, UrunFiyati, image, UrunKategori;
        
        public static void Urunara(string sorgu)
        {

            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               UrunAdi = dr["UrunAdi"].ToString();
                UrunFiyati = dr["UrunFiyati"].ToString();
                image = dr["UrunResim"].ToString();
                UrunKategori = dr["UrunKategori"].ToString();
                
               

                con.Close();
            }
            else
            {
                MessageBox.Show("Kayıtlarda bu ürün bulunamadı.");
            }


        }

        public static void cmb_aktar(ComboBox cmb, string sorgu,string x)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);

            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb.Items.Add(dr[x].ToString());
            }
        }
        public static string urunAd, urunFiyati, urunResim;
        public static void urunAktar(string UrunAdi)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand("Select * from Tbl_Urunler where UrunAdi=@urunAdi", con);
            cmd.Parameters.AddWithValue("@urunAdi", UrunAdi);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 urunAd = dr["UrunAdi"].ToString();
                 urunFiyati = dr["UrunFiyati"].ToString();
                 urunResim= dr["UrunResim"].ToString();
                con.Close();
            }
        }


        public static void FaturaEkle(string ToplamTutar)
        {
            if (ToplamTutar!="")
            {
                con = new SqlConnection(SqlCon);
                string insertsorgu = " insert into Tbl_Fatura(ToplamTutar,MusteriId,IslemTarihi,IslemSaati) values (@ToplamTutar,@MusteriId,@IslemTarihi,@IslemSaati)";
                cmd = new SqlCommand(insertsorgu, con);
                
                cmd.Parameters.AddWithValue("@ToplamTutar", ToplamTutar);
                cmd.Parameters.AddWithValue("@MusteriId",musterid);
                cmd.Parameters.AddWithValue("@IslemTarihi", Convert.ToString(DateTime.Now.ToShortDateString()));
                cmd.Parameters.AddWithValue("@IslemSaati", Convert.ToString(DateTime.Now.ToShortTimeString()));
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Siparişiniz tamamlanmıştır.");
                con.Close();
            }
            else
            {
                MessageBox.Show("Siparişiniz tamamlanamamıştır.");
            }
            
        }

        public static void GrideAktar(string sorgu,DataGridView dt)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sorgu);
            dt.DataSource = ds.Tables[sorgu];
            con.Close();
        }

       
        public static void FaturaSil(string kadi,string saat )
        {

                con = new SqlConnection(SqlCon);
                cmd = new SqlCommand("delete Tbl_Fatura  from Tbl_Fatura INNER JOIN Tbl_Musterikayit on  kullanici=@kullanici where  IslemSaati=@IslemSaati", con);
                cmd.Parameters.AddWithValue("@kullanici",kadi );
                cmd.Parameters.AddWithValue("@IslemSaati", saat);
            con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Fatura başarıyla silindi.");
                con.Close();

        }
    }
}
