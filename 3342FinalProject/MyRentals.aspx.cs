using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;
using System.Data;
using System.Drawing;

namespace _3342FinalProject
{
    public partial class MyRentals : System.Web.UI.Page
    {
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
            DataSet userData = utility.GetUserByID((int)Session["UserID"]);
            decimal funds = Convert.ToDecimal(userData.Tables[0].Rows[0][4]);
            lblFunds.Text = "Funds: $" + funds.ToString("#.##");

            DataSet paymentData = utility.GetPaymentsByUserID((int)Session["UserID"]);
            DataTable paymentTable = paymentData.Tables[0];
            utility.PrintToDebug(paymentTable.Rows.Count, "Count");

            for (int i = 0; i < paymentTable.Rows.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
                    new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                utility.PrintToDebug(paymentTable.Rows[i][0].ToString(), "Payment ID " + i);

                PaymentControl ctrl = (PaymentControl)LoadControl("PaymentControl.ascx");
                ctrl.PaymentID = Convert.ToInt32(paymentTable.Rows[i][0]);
                utility.PrintToDebug(ctrl.PaymentID, "Payment ID");
                ctrl.DataBind();
                Form.Controls.Add(ctrl);
                Button viewButton = new Button();
                viewButton.ID = "btnView" + i.ToString();
                viewButton.Text = "Quick Pay";
                viewButton.CssClass = "btn btn-primary m-2";
                viewButton.Click += new EventHandler((s, a) => viewButton_Click(s, a, ctrl.PaymentID));
                newDiv.Controls.Add(viewButton);

                Button partialButton = new Button();
                partialButton.ID = "btnPartial" + i.ToString();
                partialButton.Text = "Partial Payment";
                partialButton.CssClass = "btn btn-primary m-2";
                partialButton.Click += new EventHandler((s, a) => partialButton_Click(s, a, ctrl.PaymentID));
                newDiv.Controls.Add(partialButton);                
            }
        }

        void viewButton_Click(object sender, EventArgs e, int id)
        {
            //Make payment
            utility.PrintToDebug(id, "Payment Click ID");
            utility.SetPaymentPaid(id);
        }

        void partialButton_Click(object sender, EventArgs e, int id)
        {
            //Make partial payment
            Session["PaymentID"] = id;
            Response.Redirect("Payment.aspx");
        }
    }
}
