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
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
            if (!IsPostBack)
            {

            }
                  
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            try
            {
                hdID.Value = utility.GetUserIDByEmail(email).ToString();
                DataSet userData = utility.GetUserByID(Convert.ToInt32(hdID.Value));
                utility.PrintToDebug(Convert.ToInt32(hdID.Value), "USER ID RETRIEVE PW");
                hdAnswer.Value = SelectRandomSecurityQuestion(userData.Tables[0].Rows[0][3].ToString());
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
            txtEmail.Visible = false;
            btnSend.Visible = false;
            lblEmail.Visible = false;
            
            string[] answers = securityAnswers.Split(',');
            string[] questions = { "What is the name of your first pet?", "What is your mother's maiden name?", "What is the name of your kindergarten teacher?" };
            Random rnd = new Random();
            int index = rnd.Next(2);
            lblSecurity.Text = questions[index];
            return answers[index];
        }

        protected void btnSecurity_Click(object sender, EventArgs e)
        {
            if (txtSecurity.Text == hdAnswer.Value)
            {
                DataSet userData = utility.GetUserByID(Convert.ToInt32(hdID.Value));
                lblStatus.Text = "Your password is " + userData.Tables[0].Rows[0][2].ToString();
                lblStatus.Visible = true;
            }
        }
    }
}