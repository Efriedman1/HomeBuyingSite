using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using PropertyLibrary;
using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;       // needed for the Web Request

namespace _3342FinalProject
{
    public partial class Homepage : System.Web.UI.Page
    {
        String webApiUrl = "https://localhost:44328/api/properties/";

        Utility utility = new Utility();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                DataTable propertiesTable = utility.GetProperties().Tables[0];
                utility.PrintToDebug(propertiesTable.Rows.Count, "Count");

                WebRequest request = WebRequest.Create(webApiUrl);
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Properties objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Properties> prop = js.Deserialize<List<Properties>>(data);

                for (int i = 0; i < prop.Count; i++)
                {
                    PropertyControl ctrl = (PropertyControl)LoadControl("PropertyControl.ascx");
                    //ctrl.PropertyID = prop[i].PropertyID;
                    ctrl.Address = prop[i].Address;
                    ctrl.ImageUrl = prop[i].Image;
                    ctrl.Baths = "Baths: " + prop[i].Bathrooms.ToString();
                    ctrl.Beds = "Beds: " + prop[i].Beds.ToString();
                    ctrl.Rent = "Monthly Rent: " + prop[i].MonthlyRent.ToString();

                    Form.Controls.Add(ctrl);
                    Button viewButton = new Button();
                    viewButton.ID = "btnView" + i.ToString();
                    viewButton.Text = "View Property";
                    viewButton.CssClass = "btn btnView";
                    viewButton.Click += new EventHandler((s, a) => viewButton_Click(s, a, ctrl.PropertyID));
                    Form.Controls.Add(viewButton);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Failed to display properties.')</script>");
            }
      
         
        }

        void viewButton_Click(object sender, EventArgs e, int id)
        {
            Session["PropertyID"] = id;
            Response.Redirect("Property.aspx");
        }
    }
}