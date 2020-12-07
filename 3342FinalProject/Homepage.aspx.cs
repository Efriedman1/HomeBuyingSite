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
            if (!IsPostBack)
            {
                DataTable propertiesTable = utility.GetProperties().Tables[0];             
                for (int i = 0; i < propertiesTable.Rows.Count; i++)
                {
                    PropertyControl ctrl = (PropertyControl)LoadControl("PropertyControl.ascx");
                    ctrl.PropertyID = Convert.ToInt32(propertiesTable.Rows[i][0]);
                    ctrl.DataBind();
                    Form.Controls.Add(ctrl);
                }
            }
        }
    }
}