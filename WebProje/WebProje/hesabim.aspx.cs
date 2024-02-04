using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje
{
    public partial class hesabim : System.Web.UI.Page
    {
        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uye_id"] != null)
                {
                    string kullanici_id = Session["uye_id"].ToString();

                    string query = "SELECT adsoyad, kadi, mail,parola, uye_resim, katilim_tarih FROM Uye WHERE uye_id = @uye_id";
                    SqlCommand cmd = new SqlCommand(query, baglan);
                    cmd.Parameters.AddWithValue("@uye_id", kullanici_id);

                    try
                    {
                        baglan.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            TextBox1.Text = reader["adsoyad"].ToString();
                            TextBox2.Text = reader["kadi"].ToString();
                            TextBox3.Text = reader["mail"].ToString();
                            TextBox4.Text = reader["parola"].ToString();
                            TextBox5.Text = reader["katilim_tarih"].ToString();
                            string resimYolu = reader["uye_resim"].ToString();
                            if (!string.IsNullOrEmpty(resimYolu))
                            {
                                imgUyeResim.ImageUrl = "images/üye/" + resimYolu;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        baglan.Close();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("siparis.aspx");
        }
    }
}