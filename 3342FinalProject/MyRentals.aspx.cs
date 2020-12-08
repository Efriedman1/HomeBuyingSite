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
            DataTable propertiesTable = utility.GetProperties().Tables[0];
            utility.PrintToDebug(propertiesTable.Rows.Count, "Count");
            for (int i = 0; i < propertiesTable.Rows.Count; i++)
            {
                PaymentControl ctrl = (PaymentControl)LoadControl("PaymentControl.ascx");
                ctrl.DataBind();
                Form.Controls.Add(ctrl);
                Button viewButton = new Button();
                viewButton.ID = "btnView" + i.ToString();
                viewButton.Text = "View Property";
                viewButton.CssClass = "btn btnView";
                viewButton.Click += new EventHandler((s, a) => viewButton_Click(s, a, ctrl.PaymentID));
                Form.Controls.Add(viewButton);
            }
        }

        void viewButton_Click(object sender, EventArgs e, int id)
        {
            Session["PropertyID"] = id;
            Response.Redirect("Property.aspx");
        }
    }
}
