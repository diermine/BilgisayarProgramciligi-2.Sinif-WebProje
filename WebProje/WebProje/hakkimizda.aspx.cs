using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje
{
    public partial class hakkimizda : System.Web.UI.Page
    {
        protected string ColorsJson { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] colors = { "#FF0000", "#FF7F00", "#FFFF00", "#00FF00", "#0000FF", "#4B0082", "#8B00FF" };
            ColorsJson = new JavaScriptSerializer().Serialize(colors);
        }
    }
}