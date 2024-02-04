using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection baglanti = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["kadi"] != null)
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
            Panel2.Visible = false;
        }

        protected void Password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (baglanti.State != System.Data.ConnectionState.Open)
                baglanti.Open();
            SqlCommand komur5 = new SqlCommand("select * from Uye where kadi = '" + TextBox1.Text + "' and parola = '" + TextBox2.Text + "'", baglanti);
            SqlDataReader dr3987 = komur5.ExecuteReader();

            if (dr3987.Read())
            {
                Session["kadi"] = dr3987["kadi"].ToString();
                Session["yetki"] = dr3987["yetki"].ToString();
                Session["uye_id"] = dr3987["uye_id"].ToString();
            }
            dr3987.Close();
            baglanti.Close();
            Response.Redirect("anasayfa.aspx");

            if (CheckBox1.Checked)
            {
                HttpCookie eklemecerez = new HttpCookie("beniHatirla");
                eklemecerez.Values.Add("yetki", Session["yetki"].ToString());
                eklemecerez.Values.Add("kadi", Session["kadi"].ToString());
                eklemecerez.Values.Add("uye_id", Session["uye_id"].ToString());
                eklemecerez.Expires = DateTime.Now.AddDays(20);
                Response.Cookies.Add(eklemecerez);
            }
            FormsAuthentication.SetAuthCookie(Session["kadi"].ToString(), CheckBox1.Checked);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
                {
                    string folderPath = Server.MapPath("~/images/üye/");

                    string filePath = folderPath + FileUpload1.FileName;

                    FileUpload1.SaveAs(filePath);
                    SqlCommand komut599 = new SqlCommand("INSERT INTO Uye (adsoyad, kadi, parola, mail, yetki, katilim_tarih,uye_resim) VALUES (@adsoyad, @kadi, @parola, @mail, @yetki, @katilim_tarih,@resim)", baglanti);

                    komut599.Parameters.AddWithValue("@adsoyad", TextBox3.Text);
                    komut599.Parameters.AddWithValue("@kadi", TextBox4.Text);
                    komut599.Parameters.AddWithValue("@parola", TextBox5.Text);
                    komut599.Parameters.AddWithValue("@mail", TextBox6.Text);
                    komut599.Parameters.AddWithValue("@yetki", "musteri");
                    komut599.Parameters.AddWithValue("@resim", FileUpload1.FileName);
                    DateTime katilimTarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    komut599.Parameters.AddWithValue("@katilim_tarih", katilimTarih);

                    baglanti.Open();
                    komut599.ExecuteNonQuery();
                    baglanti.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Kayıt İşlemi Tamamlandı'); window.location.href='Login.aspx';", true);
                }
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    }
}