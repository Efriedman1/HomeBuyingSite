using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using PropertyLibrary;
using System.Data;


namespace _3342FinalProject
{
    public partial class PaymentControl : System.Web.UI.UserControl
    {
        Utility utility;
        int paymentID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
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
        public String DueDate
        {
            get { return lblDue.Text; }
            set { lblDue.Text = value; }
        }

        public override void DataBind()
        {
            //Address, Rent, Beds, Baths, Description, ImageUrl
            utility = new Utility();
            try
            {
                DataRow propertyRow = utility.GetPaymentByID(paymentID).Tables[0].Rows[0];
                lblRent.Text = "$" + propertyRow[3].ToString();
                lblDue.Text = "Due by: " + propertyRow[1].ToString();
            }
            catch (Exception e)
            {
                utility.PrintToDebug("No Payments for this user", "Payment DataBind Error");
            }
        }
    }
}