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
        }
    }
}