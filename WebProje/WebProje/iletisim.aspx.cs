using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProje
{
    public partial class iletisim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string konu = TextBox1.Text;
            string mailAdresi = "baranalyar7@gmail.com";
            string aliciMailAdresi = TextBox3.Text;
            string icerik = TextBox2.Text;

            Gonder(mailAdresi, aliciMailAdresi, konu, icerik);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mailiniz Yollandı');", true);

        }

        private void Gonder(string gonderenMail, string aliciMail, string konu, string icerik)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(gonderenMail, "aecs odob wzaw liby");
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gonderenMail);
            mail.To.Add(aliciMail);
            mail.Subject = konu; 
            mail.Body = icerik;

            smtp.Send(mail);
        }
    }
    
}