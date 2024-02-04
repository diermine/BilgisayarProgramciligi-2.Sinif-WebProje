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

    public partial class MainMaster : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Panel2.Visible= false;
            Panel3.Visible=false;
            
            HttpCookie beniHatirla = Request.Cookies["beniHatirla"];

            if (beniHatirla != null)
            {
                Session["yetki"] = beniHatirla.Values["yetki"];
                Session["uye_id"] = beniHatirla.Values["uye_id"];
                Session["kadi"] = beniHatirla.Values["kadi"];
            }

            if (Session["kadi"] != null)
            {
                string deger = "";
                if (Session["yetki"].ToString() == "admin")
                {
                    deger = "Yönetici";
                    Panel2.Visible = true;
                    Panel3.Visible = true;

                }
                else if (Session["yetki"].ToString() == "musteri")
                {
                    Label2.Visible = true;
                    Label3.Visible = true;
                    Label4.Visible = true;
                    Panel3.Visible = true;

                    deger = "Müşteri";

                    string uye_id = Session["uye_id"].ToString();
                    int toplamAdet = 0;

                    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString))
                    {
                        connection.Open();

                        string query = "SELECT ISNULL(SUM(CAST(adet AS int)), 0) AS ToplamAdet FROM Sepet WHERE uye_id = @uye_id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@uye_id", uye_id);

                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                toplamAdet = Convert.ToInt32(result);
                            }
                        }
                    }

                    if (toplamAdet == null)
                    {

                        Label2.Text = "0";
                    }
                    else
                    {


                        Label2.Text = toplamAdet.ToString();
                    }
                }

                Label1.Text = "Hoşgeldin " + Session["kadi"].ToString() + "\n" + deger;
                iletisim.Text = "Çıkış Yap";
            }
            else
            {
                Session["yetki"] = "";
                Label1.Text = "Hoşgeldin Misafir";
                iletisim.Text = "Giriş Yap";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
          

        }

        protected void benihatirla_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void iletisim_Click(object sender, EventArgs e)
        {
            if (Session["kadi"] != null || Session["yetki"] != null || Session["uye_id"] != null)
            {
                Session["kadi"] = null;
                Session["yetki"] = null;
                Session["uye_id"] = null;
                Label1.Text = "Hoşgeldin Misafir";
                iletisim.Text = "Giriş Yap";
                Response.Redirect("Login.aspx");

            }
            else
            {

            }
        }

        protected void tümü_Click(object sender, EventArgs e)
        {
            if (Session["yetki"].ToString() != "")
            {
                Response.Redirect("sepet.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Giriş Yapmadınız Lütfen Giriş Yapın');", true);

            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            string aramaTerimi = txtArama.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Urun WHERE urun_ad LIKE @BulunanOyun";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BulunanOyun", "%" + aramaTerimi + "%");

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    Response.Redirect("ara.aspx?BulunanOyun=" + aramaTerimi);
                }
            }
        }
    }
}