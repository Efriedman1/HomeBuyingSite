using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342FinalProject
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string display = "TEST STRING";
            this.Title = display;
            this.lblFunds.Text = display;

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string display = "UPDATE AJAX";
            this.lblFunds.Text = display;
        }
    }
}