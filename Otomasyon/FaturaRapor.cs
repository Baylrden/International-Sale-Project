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
    public partial class FaturaRapor : Form
    {
       //public static SqlConnection con;
        //public static SqlDataAdapter da;
        //public static SqlCommand cmd;
        //public static DataSet ds;
        //public static SqlDataReader dr;
        public static string SqlCon = @"Data Source=DESKTOP-S558N0I\SQLEXPRESS;Initial Catalog = 202503518; Integrated Security = True";

        public FaturaRapor()
        {
            InitializeComponent();
        }

        private void FaturaRapor_Load(object sender, EventArgs e)
        { string sorgu ="select kullanici,ToplamTutar,telefon,eposta,IslemTarihi,IslemSaati from Tbl_Fatura INNER JOIN Tbl_Musterikayit on Tbl_Musterikayit.id=Tbl_Fatura.MusteriId";
            
            SqlConnection con = new SqlConnection(SqlCon);
            SqlDataAdapter da = new SqlDataAdapter(sorgu,con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds,sorgu);
            con.Close();

            crystalReport11.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = crystalReport11;







        }
    }
}
