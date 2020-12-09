using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;
using System.Drawing;

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
            String[] fields = { txtAddress.Text, txtBilling.Text, txtEmail.Text, txtPw1.Text, txtPw2.Text, txtSecurity1.Text, txtSecurity2.Text, txtSecurity3.Text, txtUsername.Text };
            //check all fields for blanks
            if (rbType.SelectedIndex != -1 && !utility.isNullOrEmpty(fields))
            {
                utility.PrintToDebug("TRUE", "validation");
                //Check if username is taken
                if (utility.CheckUserNameTaken(txtUsername.Text))
                {
                    lblError.Visible = true;
                    lblError.ForeColor = Color.Red;
                    lblError.Text = "This Username is taken, try another";
                    return;
                }
                //utility.AddUser(txtUsername.Text, txtPw2.Text, rbType.SelectedIndex);
            }
            else
            {
                utility.PrintToDebug("FALSE", "validation");
            }            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }        
    }
}