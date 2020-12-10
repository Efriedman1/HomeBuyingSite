using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Net.Mail;

namespace _3342FinalProject
{
    public partial class RetrievePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SmtpClient smtpMailClient = new SmtpClient("smtp.temple.edu");
            MailMessage mail = new MailMessage();
            MailAddress toAddress = new MailAddress(txtEmail.Text);
            MailAddress fromAddress = new MailAddress("tuf97957@temple.edu");
            mail.To.Add(toAddress);
            mail.From = fromAddress;
            mail.Subject = "Your password";
            mail.Body = "TEST";

            smtpMailClient.Send(mail);
        }
    }
}