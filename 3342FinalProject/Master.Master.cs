using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342FinalProject
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if ((int)Session["userType"] == 0)
                {
                    //user is a renter
                    btnWallet.Visible = true;
                    btnHome.Visible = true;
                    btnMyRentals.Visible = true;
                }
                else if((int)Session["userType"] == 1)
                {
                    //user is a landlord
                    btnWallet.Visible = false;
                    btnMyRentals.Visible = false;
                }
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnMyRentals_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyRentals.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void btnWallet_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wallet.aspx");
        }
    }
}