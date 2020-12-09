using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;
using System.Data;

namespace _3342FinalProject
{
    public partial class Login : System.Web.UI.Page
    {
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            int userId = utility.CheckLogin(txtUsername.Text, txtPw.Text);
            if (userId > 0)
            {
                Session["UserID"] = userId;
                utility.PrintToDebug(userId, "Login ID");
                Response.Redirect("Homepage.aspx");
            } 
            else
            {
                lblError.Text = "Invalid login information, please try again.";
                lblError.Visible = true;
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}