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
    public partial class detay : System.Web.UI.Page
    {
        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);


        static int mevcutStok = 0;
        static int sepetAdet = 0;
        static int satiss = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand oku = new SqlCommand("select * from urun where urun_id=@id", baglan);
            oku.Parameters.AddWithValue("@id", Request.QueryString["urunID"]);
            SqlDataReader dr = oku.ExecuteReader();
            ListView1.DataSource = dr;
            ListView1.DataBind();
            baglan.Close();
        }






        Boolean StokyeterliMi(string urun, int adet)
        {
            SqlCommand oku = new SqlCommand("select * from urun where urun_id=@id", baglan);
            oku.Parameters.AddWithValue("@id", urun);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(oku);
            da.Fill(dt);
            mevcutStok = Convert.ToInt32(dt.Rows[0][6]);
            satiss = Convert.ToInt32(dt.Rows[0][7]);
            if (adet < mevcutStok)
                return true;
            else
                return false;
        }

        Boolean SepetKontrol(string urun, string kullanici)
        {
            SqlCommand oku = new SqlCommand("select * from Sepet where urun_id=@u_id and uye_id=@k_id", baglan);
            oku.Parameters.AddWithValue("@u_id", urun);
            oku.Parameters.AddWithValue("@k_id", kullanici);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(oku);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                sepetAdet = Convert.ToInt32(dt.Rows[0][3]);
                return true;
            }
            else
                return false;

        }
        void SepetAdetArttir(string urun, int secilenadet)
        {
            SqlCommand guncelle = new SqlCommand("update sepet set adet=@adet where urun_id=@urun", baglan);
            guncelle.Parameters.AddWithValue("@adet", sepetAdet + secilenadet);
            guncelle.Parameters.AddWithValue("@urun", urun);
            guncelle.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sepete Eklendi'); window.location.href='anasayfa.aspx';", true);

        }
        void StokGuncelle(string urun, int secilenadet)
        {
            SqlCommand guncelle = new SqlCommand("update urun set stok=@stok where urun_id=@urun", baglan);
            guncelle.Parameters.AddWithValue("@stok", mevcutStok - secilenadet);
            guncelle.Parameters.AddWithValue("@satis", satiss + secilenadet);
            guncelle.Parameters.AddWithValue("@urun", urun);
            guncelle.ExecuteNonQuery();

        }

        void Yeni_Kayit_Ekle(string urun, string kullanici, int adet)
        {
            SqlCommand ekle = new SqlCommand("insert into Sepet Values(@urun,@adet,@kullanici)", baglan);
            ekle.Parameters.AddWithValue("@adet", adet);
            ekle.Parameters.AddWithValue("@kullanici", kullanici);
            ekle.Parameters.AddWithValue("@urun", urun);
            ekle.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sepete Eklendi'); window.location.href='anasayfa.aspx';", true);

        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            
            string secilen_urun = Request.QueryString["urunID"].ToString();
            int secilenadet = 0;
            Button btn = (Button)sender; 
            DropDownList adetliste = (DropDownList)btn.Parent.FindControl("DropDownList1");

            if (adetliste.SelectedIndex > 0)
            {
                secilenadet = Convert.ToInt32(adetliste.SelectedValue);
                if (Session["uye_id"] != null)
                {
                    string kullanici = Session["uye_id"].ToString();
                    baglan.Open();
                    if (StokyeterliMi(secilen_urun, secilenadet) == true)
                    {
                        if (SepetKontrol(secilen_urun, kullanici) == true)
                        {
                            SepetAdetArttir(secilen_urun, secilenadet);
                            StokGuncelle(secilen_urun, secilenadet);

                        }
                        else
                        {
                            Yeni_Kayit_Ekle(secilen_urun, kullanici, secilenadet);
                            StokGuncelle(secilen_urun, secilenadet);

                        }


                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Stok yetersiz!..');", true);



                }
                else
                    Response.Redirect("Login.aspx?returnURL=" + Request.RawUrl);

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Lütfen ürün adedini seçin');", true);
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}