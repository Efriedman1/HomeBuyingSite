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
    public partial class Wallet : System.Web.UI.Page
    {
        Utility utility;
        Decimal funds;
        DataSet userData;

        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();

            try
            {
                if ((int)Session["userType"] < 0)
                {
                    //user is a not a renter or landlord, automatic redirect
                    Response.Redirect("Login.aspx");
                }
            }
            catch
            {
                //user has not signed in, automatic redirect to login screen
                Response.Redirect("Login.aspx");
            }

            userData = utility.GetUserByID((int)Session["UserID"]);
            funds = Convert.ToDecimal(userData.Tables[0].Rows[0][4]);
            this.lblFunds.Text = "Funds: $" + funds.ToString("#.##");
            lblName.Text = userData.Tables[0].Rows[0][1].ToString();
        }

        private void AjaxUpdateWallet(decimal amount)
        {            
            funds = Convert.ToDecimal(userData.Tables[0].Rows[0][4]);
            this.lblFunds.Text = "Funds: $" + funds.ToString("#.##");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount;
            try
            {
                amount = Convert.ToDecimal(txtAmount.Text);
                if (utility.isValidMoneyDecimal(amount))
                {
                    utility.AddFunds(amount + funds, (int)Session["UserID"]);
                    userData = utility.GetUserByID((int)Session["UserID"]);
                    AjaxUpdateWallet(amount);
                    UpdatePanel1.Update();
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