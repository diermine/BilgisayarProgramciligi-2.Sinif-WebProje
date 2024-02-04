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
    public partial class siparis : System.Web.UI.Page
    {
        SqlConnection baglan = new SqlConnection(WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Label6.Visible = false;
            if (Session["uye_id"] != null)
            {
                string kullanici_id = Session["uye_id"].ToString();

                string query = "SELECT * FROM Siparis WHERE uye_id = @uye_id";
                SqlCommand cmd = new SqlCommand(query, baglan);
                cmd.Parameters.AddWithValue("@uye_id", kullanici_id);

                try
                {
                    baglan.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label6.Visible = true;

                        Label6.Text = "Siparişiniz Yoktur";
                        GridView1.Visible = false;
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
            else
            {
                Response.Redirect("giris.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}