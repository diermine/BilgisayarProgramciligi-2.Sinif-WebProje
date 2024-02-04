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
    public partial class adminpel : System.Web.UI.Page
    {
        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            FileUpload1.Attributes["title"] = "Resim Seç";
            if (Session["uye_id"] != null)//giriş yapılmış mı
            {
                if (Session["yetki"].ToString() != "admin") //yetki admin değil ise 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Lütfen Admin Hesabıyla Giriş Yapınn');", true);
                    Response.Redirect("Login.aspx?returnURL=" + Request.RawUrl);
                }

            }
            else
                Response.Redirect("Login.aspx?returnURL=" + Request.RawUrl);

            DataTable dt = new DataTable();
            dt = Kategori_oku();
            GridView1.DataSource = dt;
            GridView1.DataBind();

            DataTable dt2 = new DataTable();
            dt2 = Kullanici_oku();
            GridView2.DataSource = dt2;
            GridView2.DataBind();

            DataTable dt3 = new DataTable();
            dt3 = siparis_oku();
            GridView3.DataSource = dt3;
            GridView3.DataBind();

        }
        DataTable Kategori_oku()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Urun", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglan.Close();
            return dt;


        }
        DataTable Kullanici_oku()
        {
            baglan.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Uye", baglan);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            baglan.Close();
            return dt2;
        }

        DataTable siparis_oku()
        {
            baglan.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from Siparis", baglan);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            baglan.Close();
            return dt3;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Kategori_oku();



            int secilen_satir = Convert.ToInt32(e.CommandArgument);
            TextBox6.Text = dt.Rows[secilen_satir][0].ToString();
            TextBox1.Text = dt.Rows[secilen_satir][1].ToString();
            TextBox2.Text = dt.Rows[secilen_satir][2].ToString();
            TextBox3.Text = dt.Rows[secilen_satir][3].ToString();
            TextBox4.Text = dt.Rows[secilen_satir][4].ToString();
            TextBox5.Text = dt.Rows[secilen_satir][6].ToString();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string urunAd = TextBox6.Text;
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update Urun set urun_ad=@ad, urun_aciklama=@aciklama, urun_fiyat=@fiyat, urun_turu=@turu, stok=@stok where urun_id=@id", baglan);
            guncelle.Parameters.AddWithValue("@ad", TextBox1.Text);
            guncelle.Parameters.AddWithValue("@aciklama", TextBox2.Text);
            guncelle.Parameters.AddWithValue("@fiyat", TextBox3.Text);
            guncelle.Parameters.AddWithValue("@turu", TextBox4.Text);
            guncelle.Parameters.AddWithValue("@stok", TextBox5.Text);
            guncelle.Parameters.AddWithValue("@id", urunAd);
            guncelle.ExecuteNonQuery();
            baglan.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ürün Güncellendi!'); window.location.href='adminpel.aspx';", true);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
        

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                {
                    string folderPath = Server.MapPath("~/images/oyun/");

                    string filePath = folderPath + FileUpload1.FileName;

                    FileUpload1.SaveAs(filePath);

                    baglan.Open();
                    SqlCommand ekle = new SqlCommand("insert into Urun(urun_ad, urun_aciklama, urun_fiyat, urun_turu, urun_resim, stok,satis) values (@ad, @aciklama, @fiyat, @turu, @resim, @stok,0)", baglan);
                    ekle.Parameters.AddWithValue("@ad", TextBox7.Text);
                    ekle.Parameters.AddWithValue("@aciklama", TextBox8.Text);
                    ekle.Parameters.AddWithValue("@fiyat", TextBox9.Text);
                    ekle.Parameters.AddWithValue("@turu", TextBox10.Text);
                    ekle.Parameters.AddWithValue("@resim", FileUpload1.FileName); 
                    ekle.Parameters.AddWithValue("@stok", TextBox12.Text);
                    ekle.ExecuteNonQuery();
                    baglan.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Yeni Ürün Eklendi!'); window.location.href='adminpel.aspx';", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Geçersiz Dosya Uzantısı Seçtiniz');", true);

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Lütfen Resim Seçinn');", true);

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string secilen_kategori = e.Values[0].ToString();
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from Urun where urun_id=@id", baglan);
            sil.Parameters.AddWithValue("@id", secilen_kategori);
            sil.ExecuteNonQuery();
            baglan.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ürün Silindi!'); window.location.href='adminpel.aspx';", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = Kullanici_oku();



            int secilen_satir = Convert.ToInt32(e.CommandArgument);
            TextBox18.Text = dt2.Rows[secilen_satir][0].ToString();
            TextBox13.Text = dt2.Rows[secilen_satir][1].ToString();
            TextBox14.Text = dt2.Rows[secilen_satir][2].ToString();
            TextBox15.Text = dt2.Rows[secilen_satir][3].ToString();
            TextBox16.Text = dt2.Rows[secilen_satir][4].ToString();
            TextBox17.Text = dt2.Rows[secilen_satir][5].ToString();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand ekle = new SqlCommand("insert into Uye(adsoyad, kadi, parola, mail, yetki) values (@ad, @kadi, @parola, @mail, @turu)", baglan);
            ekle.Parameters.AddWithValue("@ad", TextBox13.Text);
            ekle.Parameters.AddWithValue("@kadi", TextBox14.Text);
            ekle.Parameters.AddWithValue("@parola", TextBox15.Text);
            ekle.Parameters.AddWithValue("@mail", TextBox16.Text);
            ekle.Parameters.AddWithValue("@turu", TextBox17.Text);
            ekle.ExecuteNonQuery();
            baglan.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Yeni Kullanici Eklendi!'); window.location.href='adminpel.aspx';", true);

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string uyead = TextBox18.Text;
            baglan.Open();
            SqlCommand guncelle = new SqlCommand("update Uye set adsoyad=@ad, kadi=@kadi, parola=@parola, mail=@mail, yetki=@yetki where uye_id=@id", baglan);
            guncelle.Parameters.AddWithValue("@ad", TextBox13.Text);
            guncelle.Parameters.AddWithValue("@aciklama", TextBox14.Text);
            guncelle.Parameters.AddWithValue("@fiyat", TextBox15.Text);
            guncelle.Parameters.AddWithValue("@turu", TextBox16.Text);
            guncelle.Parameters.AddWithValue("@stok", TextBox17.Text);
            guncelle.Parameters.AddWithValue("@id", uyead);
            guncelle.ExecuteNonQuery();
            baglan.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Üye Güncellendi!'); window.location.href='adminpel.aspx';", true);
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string secilen_kategori = e.Values[0].ToString();
            baglan.Open();
            SqlCommand sil = new SqlCommand("delete from Uye where uye_id=@id", baglan);
            sil.Parameters.AddWithValue("@id", secilen_kategori);
            sil.ExecuteNonQuery();
            baglan.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Üye Silindi!'); window.location.href='adminpel.aspx';", true);
        }
    }
}