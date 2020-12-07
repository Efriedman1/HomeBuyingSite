using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using PropertyLibrary;
using System.Data;

namespace _3342FinalProject
{
    public partial class PropertyControl : System.Web.UI.UserControl
    {  
        Utility utility;
        int propertyID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int PropertyID
        {
            get { return propertyID; }
            set { propertyID = value; }
        }

        [Category("Misc")]
        public String ImageUrl
        {
            get { return imgProperty.ImageUrl; }
            set { imgProperty.ImageUrl = value; }
        }

        [Category("Misc")]
        public String Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
        }

        [Category("Misc")]
        public String Rent
        {
            get { return lblRent.Text; }
            set { lblRent.Text = value; }
        }

        [Category("Misc")]
        public String Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        [Category("Misc")]
        public String Beds
        {
            get { return lblBedAmount.Text ; }
            set { lblBedAmount.Text = value; }
        }

        [Category("Misc")]
        public String Baths
        {
            get { return lblBathAmount.Text; }
            set { lblBathAmount.Text = value; }
        }

        public override void DataBind()
        {
            //Address, Rent, Beds, Baths, Description, ImageUrl
            utility = new Utility();
            utility.PrintToDebug(propertyID, "PropertyID");
            DataRow propertyRow = utility.GetPropertyByID(propertyID).Tables[0].Rows[0];
            lblAddress.Text = propertyRow[0].ToString();
            lblRent.Text = propertyRow[1].ToString();
            lblBedAmount.Text = propertyRow[2].ToString();
            lblBathAmount.Text = propertyRow[3].ToString();
            lblDescription.Text = propertyRow[4].ToString();
        }
    }
}