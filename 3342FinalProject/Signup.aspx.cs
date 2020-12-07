using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;

namespace _3342FinalProject
{
    public partial class Signup : System.Web.UI.Page
    {
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (rbType.SelectedIndex != -1)
            {
                utility.AddUser(txtUsername.Text, txtPw2.Text, rbType.SelectedIndex);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}