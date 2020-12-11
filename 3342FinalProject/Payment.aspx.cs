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
    public partial class Payment : System.Web.UI.Page
    {
        Utility utility;
        decimal funds;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();

            try
            {
                if ((int)Session["userType"] != 0)
                {
                    //user is a not a renter, automatic redirect
                    Response.Redirect("Login.aspx");
                }
            }
            catch
            {
                //user has not signed in, automatic redirect to login screen
                Response.Redirect("Login.aspx");
            }

            DataSet userData = utility.GetUserByID(1);
            funds = Convert.ToDecimal(userData.Tables[0].Rows[0][4]);
            lblFunds.Text = "Funds: $" + funds.ToString("#.##");
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            decimal amount;
            try
            {
                amount = Convert.ToDecimal(txtAmount.Text);
                if (utility.isValidMoneyDecimal(amount))
                {
                    //Make Partial Payment   
                    Response.Redirect("MyRentals.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Please enter a valid amount of money.";
                    return;
                }
            }
            catch
            {
                lblError.Visible = true;
                lblError.Text = "Please enter a valid amount of money.";
            }
        }
    }
}