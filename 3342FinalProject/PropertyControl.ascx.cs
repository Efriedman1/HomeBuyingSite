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
        String imageUrl;
        String propertyName;
        String propertyAddress;
        String propertyDescription;
        int bedAmount;
        int bathAmount;
        double rentAmount;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Category("Misc")]
        public String ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }

        [Category("Misc")]
        public String Name
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

        [Category("Misc")]
        public String Address
        {
            get { return propertyAddress; }
            set { propertyAddress = value; }
        }

        [Category("Misc")]
        public String Description
        {
            get { return propertyDescription; }
            set { propertyDescription = value; }
        }

        [Category("Misc")]
        public int Beds
        {
            get { return bedAmount; }
            set { bedAmount = value; }
        }

        [Category("Misc")]
        public int Baths
        {
            get { return bathAmount; }
            set { bathAmount = value; }
        }
    }
}