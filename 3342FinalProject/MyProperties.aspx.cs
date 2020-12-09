using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;

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
            lblImage.Visible = tf;
            ddImage.Visible = tf;
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
            Properties prop = new Properties
            {
                Image = ddImage.Text,
                Address = tbAddress.Text,
                Owner = Session["Name"].ToString(),
                Beds = Convert.ToInt32(tbBeds.Text),
                Bathrooms = Convert.ToInt32(tbBaths.Text),
                MonthlyRent = Convert.ToInt32(tbRent.Text),
                Description = tbDescription.Text
                
                
            };
        }
    }
}