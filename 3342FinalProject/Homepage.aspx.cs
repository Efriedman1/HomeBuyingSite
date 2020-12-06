using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342FinalProject
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PropertyControl ctrl = (PropertyControl)LoadControl("PropertyControl.ascx");
            ctrl.Name = "Name";
            ctrl.Address = "474 Willow St";
            ctrl.ImageUrl = "img/houses/00.jpg";

            Form.Controls.Add(ctrl);
        }
    }
}