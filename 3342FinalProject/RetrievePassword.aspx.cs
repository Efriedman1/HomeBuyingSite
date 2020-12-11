using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Net.Mail;
using PropertyLibrary;
using System.Data;

namespace _3342FinalProject
{
    public partial class RetrievePassword : System.Web.UI.Page
    {
        Utility utility;
        string securityAnswer;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //SmtpClient smtpMailClient = new SmtpClient("smtp.temple.edu");
            //MailMessage mail = new MailMessage();
            //MailAddress toAddress = new MailAddress(txtEmail.Text);
            //MailAddress fromAddress = new MailAddress("tuf97957@temple.edu");
            //mail.To.Add(toAddress);
            //mail.From = fromAddress;
            //mail.Subject = "Your password";
            //mail.Body = "TEST";
            //smtpMailClient.Send(mail);

            String email = txtEmail.Text;
            try
            {
                int userID = utility.GetUserIDByEmail(email);
                DataSet userData = utility.GetUserByID(userID);
                utility.PrintToDebug(userID, "USER ID RETRIEVE PW");
                securityAnswer = SelectRandomSecurityQuestion(userData.Tables[0].Rows[0][3].ToString());
                lblSecurity.Visible = true;
                txtSecurity.Visible = true;
                btnSecurity.Visible = true;
                lblStatus.Visible = false;
            }
            catch
            {
                lblStatus.Text = "This email is not in our system";
                lblStatus.Visible = true;                    
            }
        }

        private string SelectRandomSecurityQuestion(string securityAnswers)
        {
            string[] answers = securityAnswers.Split(',');
            string[] questions = { "What is the name of your first pet?", "What is your mother's maiden name?", "What is the name of your kindergarten teacher?" };
            Random rnd = new Random();
            int index = rnd.Next(2);
            lblSecurity.Text = questions[index];
            return answers[index];
        }

        protected void btnSecurity_Click(object sender, EventArgs e)
        {
            if (txtSecurity.Text == securityAnswer)
            {
                lblStatus.Text = "SUCCESS";
            }
        }
    }
}