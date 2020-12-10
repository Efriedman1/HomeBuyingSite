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
            if (!IsPostBack)
            {
                Session["UserType"] = -1;
            }
            if (!IsPostBack && Request.Cookies["HomeRentalCookie"] != null && Request.Cookies["HomeRentalCookie"].Values["Name"] != "")
            {
                HttpCookie cookie = Request.Cookies["HomeRentalCookie"];
                txtUsername.Text = cookie.Values["Name"].ToString();
                txtPw.Text = cookie.Values["Password"].ToString();
                btnDeleteCookie.Visible = true;
            }
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
                Session["UserType"] = utility.GetUserByID(userId).Tables[0].Rows[0][5];
                utility.PrintToDebug(userId, "Login ID");
                utility.PrintToDebug((int)Session["UserType"], "Login User Type");
                if (chkCookies.Checked)
                {
                    saveCookies();
                }
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

        protected void btnLostPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("RetrievePassword.aspx");
        }

        void saveCookies()
        {
            HttpCookie myCookie = new HttpCookie("HomeRentalCookie");
            myCookie.Values["Name"] = txtUsername.Text;
            myCookie.Values["Password"] = txtPw.Text;            
            myCookie.Expires = new DateTime(2025, 1, 1);
            Response.Cookies.Add(myCookie);            
        }

        protected void btnDeleteCookie_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["HomeRentalCookie"];
            myCookie.Values["Name"] = "";
            myCookie.Values["Password"] = "";
            myCookie.Expires = DateTime.Today.AddDays(-1);
            btnDeleteCookie.Visible = false;
        }
    }
}