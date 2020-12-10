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

            if (!IsPostBack)
            {
                for (int i = 0; i < paymentTable.Rows.Count; i++)
                {
                    utility.PrintToDebug(paymentTable.Rows[i][0].ToString(), "Payment ID " + i);
                    PaymentControl ctrl = (PaymentControl)LoadControl("PaymentControl.ascx");
                    ctrl.PaymentID = Convert.ToInt32(paymentTable.Rows[i][0]);
                    utility.PrintToDebug(ctrl.PaymentID, "Payment ID");
                    ctrl.DataBind();
                    Form.Controls.Add(ctrl);
                    Button viewButton = new Button();
                    viewButton.ID = "btnView" + i.ToString();
                    viewButton.Text = "Make Payment";
                    viewButton.CssClass = "btn btnView";
                    viewButton.Click += new EventHandler((s, a) => viewButton_Click(s, a, ctrl.PaymentID));
                    Form.Controls.Add(viewButton);
                    TextBox txtPartial = new TextBox();
                    txtPartial.CssClass = "form-control-sm";
                    txtPartial.ID = "txtPartial" + i;
                    Form.Controls.Add(txtPartial);
                    Button partialButton = new Button();
                    partialButton.ID = "btnView" + i.ToString();
                    partialButton.Text = "Partial Payment";
                    partialButton.CssClass = "btn btnView";
                    partialButton.Click += new EventHandler((s, a) => partialButton_Click(s, a, ctrl.PaymentID));
                    Form.Controls.Add(partialButton);
                }
            }
        }

        void viewButton_Click(object sender, EventArgs e, int id)
        {
            utility.PrintToDebug(id, "Payment Click ID");
            utility.SetPaymentPaid(id);
        }

        void partialButton_Click(object sender, EventArgs e, int id)
        {

        }
    }
}
