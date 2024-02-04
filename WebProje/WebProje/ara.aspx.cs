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
    public partial class ara : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string aramaTerimi = Request.QueryString["BulunanOyun"];

                if (!string.IsNullOrEmpty(aramaTerimi))
                {
                    string connectionString = WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Urun WHERE urun_ad LIKE @BulunanOyun";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {

                            command.Parameters.AddWithValue("@BulunanOyun", "%" + aramaTerimi + "%");


                            connection.Open();


                            SqlDataReader reader = command.ExecuteReader();
                            ListView1.DataSource = reader;
                            ListView1.DataBind();

                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}