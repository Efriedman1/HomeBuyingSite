using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PropertyLibrary;
using System.Data;
using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;       // needed for the Web Request

namespace _3342FinalProject
{
    public partial class Property : System.Web.UI.Page
    {
        String webApiUrl = "https://localhost:44328/api/properties/";

        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
            //try
            //{
            //    DataRow propertyRow = utility.GetPropertyByID(Convert.ToInt32(Session["PropertyID"])).Tables[0].Rows[0];
            //    lblAddress.Text = propertyRow[0].ToString();
            //    lblRent.Text = propertyRow[1].ToString();
            //    lblBedAmount.Text = propertyRow[2].ToString();
            //    lblBathAmount.Text = propertyRow[3].ToString();
            //    lblDescription.Text = propertyRow[4].ToString();
            //    imgProperty.ImageUrl = propertyRow[5].ToString();
            //}
            //catch (Exception ex)
            //{
            //    utility.PrintToDebug(ex.ToString(), "Error loading property");
            //}
            displayProperties();

        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            //Add properties to user list

        }

        public void displayProperties()
        {
            try{
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

                gvProperties.DataSource = prop;
                gvProperties.DataBind();
                gvProperties.HeaderRow.TableSection = TableRowSection.TableHeader;
            } 
            catch (Exception ex)
            {
                Response.Write("<script>alert('Failed to display properties.')</script>");
            }
           

        }
    }
}