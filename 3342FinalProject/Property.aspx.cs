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
    public partial class Property : System.Web.UI.Page
    {
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
            try
            {
                DataRow propertyRow = utility.GetPropertyByID(Convert.ToInt32(Session["PropertyID"])).Tables[0].Rows[0];
                lblAddress.Text = propertyRow[0].ToString();
                lblRent.Text = propertyRow[1].ToString();
                lblBedAmount.Text = propertyRow[2].ToString();
                lblBathAmount.Text = propertyRow[3].ToString();
                lblDescription.Text = propertyRow[4].ToString();
                imgProperty.ImageUrl = propertyRow[5].ToString();
            }
            catch (Exception ex)
            {
                utility.PrintToDebug(ex.ToString(), "Error loading property");
            }
            
        }

        protected void btnRent_Click(object sender, EventArgs e)
        {

        }
    }
}