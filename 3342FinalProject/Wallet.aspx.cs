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
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
            DataSet userData = utility.GetUserByID(1);
            lblFunds.Text = "Funds: $" + userData.Tables[0].Rows[0][4].ToString();
            lblName.Text = userData.Tables[0].Rows[0][1].ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                utility.AddFunds(Convert.ToDouble(txtAmount.Text), 1);
            }
            catch
            {
                //Error adding funds
            }
        }
    }
}