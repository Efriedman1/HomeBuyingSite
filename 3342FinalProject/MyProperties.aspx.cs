using PropertyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;
using Utilities;
using System.Data.SqlClient;
// needed for DataSet class

namespace _3342FinalProject
{
    public partial class MyProperties : System.Web.UI.Page
    {
        String webApiUrl = "https://localhost:44328/api/properties/";

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
            Properties prop = new Properties();

            prop.OwnerID = 10;
            prop.Image = ddImage.Text;
            prop.Address = tbAddress.Text;
            prop.Owner = tbName.Text;
            prop.Beds = Convert.ToInt32(tbBeds.Text);
            prop.Bathrooms = Convert.ToInt32(tbBaths.Text);
            prop.MonthlyRent = Convert.ToDecimal(tbRent.Text);
            prop.Description = tbDescription.Text;


            // Serialize a Property object into a JSON string.
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonProp = js.Serialize(prop);

            try
            {
                //Send the Property object to the Web API that will be used to store a new property record in the database.
                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.

                WebRequest request = WebRequest.Create(webApiUrl + "AddProperty/");
                request.Method = "POST";
                request.ContentLength = jsonProp.Length;
                request.ContentType = "application/json";


               // Write the JSON data to the Web Request
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonProp);
                writer.Flush();
                writer.Close();

               // Read the data from the Web Response, which requires working with streams.
                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                {
                    Response.Write("<script>alert('The property was successfully saved to the database..')</script>");

                }
                else
                {
                    Response.Write("<script>alert('A problem occurred while adding the customer to the database. The data wasn't recorded.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");

            }

        }
    }
}