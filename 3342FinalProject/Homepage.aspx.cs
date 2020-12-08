using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PropertyLibrary;

namespace _3342FinalProject
{
    public partial class Homepage : System.Web.UI.Page
    {
        Utility utility = new Utility();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable propertiesTable = utility.GetProperties().Tables[0];
            utility.PrintToDebug(propertiesTable.Rows.Count, "Count");
            for (int i = 0; i < propertiesTable.Rows.Count; i++)
            {
                PropertyControl ctrl = (PropertyControl)LoadControl("PropertyControl.ascx");
                ctrl.PropertyID = Convert.ToInt32(propertiesTable.Rows[i][0]);
                ctrl.DataBind();
                Form.Controls.Add(ctrl);
                Button viewButton = new Button();
                viewButton.ID = "btnView" + i.ToString();
                viewButton.Text = "View Property";
                viewButton.CssClass = "btn btnView";
                viewButton.Click += new EventHandler((s, a) => viewButton_Click(s, a, ctrl.PropertyID));
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