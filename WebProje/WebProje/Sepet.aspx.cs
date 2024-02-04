using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje
{
    public partial class Sepet : System.Web.UI.Page
    {
        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string kullanici_id = Session["uye_id"].ToString();
            baglan.Open();
            SqlCommand oku = new SqlCommand("select Urun.urun_ad,Urun.urun_fiyat,Urun.urun_resim,Urun.urun_aciklama,Sepet.adet from Sepet Inner Join Urun on Sepet.urun_id=Urun.urun_id where uye_id=@kullanici", baglan);
            oku.Parameters.AddWithValue("@kullanici", kullanici_id);
            SqlDataReader dr23 = oku.ExecuteReader();




            double tutar = 0.0;
            double toplamTutar = 0.0;
            while (dr23.Read())
            {

                int adet = Convert.ToInt32(dr23["adet"]);
                double fiyat = Convert.ToDouble(dr23["urun_fiyat"]);
                tutar = adet * fiyat;
                toplamTutar += tutar;

            }
            dr23.Close();
            SqlDataAdapter adp3 = new SqlDataAdapter(oku);
            DataTable dt34 = new DataTable();
            adp3.Fill(dt34);
            sptlbl.Text= toplamTutar.ToString();
            ListView1.DataSource = dt34;
            ListView1.DataSourceID = "";
            ListView1.DataBind();
            baglan.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (baglan.State != ConnectionState.Open)
                baglan.Open();

            SqlCommand komut344 = new SqlCommand("insert into siparis values ('" + Session["uye_id"].ToString() + "','" + sptlbl.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", baglan);
            komut344.ExecuteNonQuery();
            SqlCommand komut322 = new SqlCommand("delete from sepet where uye_id = '" + Session["uye_id"].ToString() + "'", baglan);
            komut322.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sipariş Tamamlandı'); window.location.href='Sepet.aspx';", true);
            baglan.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString))
            {
                baglan.Open();

                string uye_id = Session["uye_id"].ToString();

                SqlTransaction transaction = null;

                transaction = baglan.BeginTransaction();

                using (SqlCommand komutUpdateStok = new SqlCommand(
                         @"UPDATE urun
                              SET stok = urun.stok + CONVERT(INT, s.adet)
                              FROM urun
                              INNER JOIN sepet s ON urun.urun_id = s.urun_id
                              WHERE s.uye_id = @uye_id;", baglan, transaction))
                {
                    komutUpdateStok.Parameters.AddWithValue("@uye_id", uye_id);
                    komutUpdateStok.ExecuteNonQuery();
                }
                using (SqlCommand komutDeleteSepet = new SqlCommand(
                    @"DELETE FROM sepet
              WHERE uye_id = @uye_id;", baglan, transaction))
                {
                    komutDeleteSepet.Parameters.AddWithValue("@uye_id", uye_id);
                    komutDeleteSepet.ExecuteNonQuery();
                }

                transaction.Commit();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sepet Temizlendi'); window.location.href='Sepet.aspx';", true);

            }
        }
    }
}