using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342FinalProject
{
    public partial class MyProperties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load and display all properties for Landlord
        }

        public void displayAddProp(bool tf)
        {
            lblName.Visible = tf;
            tbName.Visible = tf;
            lblAddress.Visible = tf;
            tbAddress.Visible = tf;
            lblBeds.Visible = tf;
            tbBeds.Visible = tf;
            lblBaths.Visible = tf;
            tbBaths.Visible = tf;
            lblRent.Visible = tf;
            tbRent.Visible = tf;
            lblDescription.Visible = tf;
            tbDescription.Visible = tf;
            btnBack.Visible = tf;
            btnSave.Visible = tf;
        }

            protected void btnCreate_Click(object sender, EventArgs e)
        {
            displayAddProp(true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            displayAddProp(false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}