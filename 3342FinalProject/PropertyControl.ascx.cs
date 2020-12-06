using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace _3342FinalProject
{
    public partial class PropertyControl : System.Web.UI.UserControl
    {  
        double rentAmount;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Category("Misc")]
        public String ImageUrl
        {
            get { return imgProperty.ImageUrl; }
            set { imgProperty.ImageUrl = value; }
        }

        [Category("Misc")]
        public String Name
        {
            get { return lblProperty.Text; }
            set { lblProperty.Text = value; }
        }

        [Category("Misc")]
        public String Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
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
    }
}