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

namespace _3342FinalProject
{
    public partial class Property : System.Web.UI.Page
    {

        String webApiUrl = "https://localhost:44328/api/properties/";
      
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();
            try
            {
                DataRow propertyRow = utility.GetPropertyByID(Convert.ToInt32(Session["PropertyID"])).Tables[0].Rows[0];
                lblAddress.Text = propertyRow[0].ToString();
                lblRent.Text = propertyRow[1].ToString();
                lblBedAmount.Text = propertyRow[2].ToString();
                lblBathAmount.Text = propertyRow[3].ToString();
                lblDescription.Text = propertyRow[4].ToString();
                imgProperty.ImageUrl = propertyRow[5].ToString();
            }
            catch (Exception ex)
            {
                utility.PrintToDebug(ex.ToString(), "Error loading property");
            }

        }

        protected void btnRent_Click(object sender, EventArgs e)
        {
            Payments pay = new Payments();

            pay.PaymentDate = DateTime.Now.ToString();
            pay.PaymentAmount = 500;
            pay.PropertyID = Convert.ToInt32(Session["PropertyID"]);
            pay.PropertyID = 2;

            // Serialize a Property object into a JSON string.
            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonProp = js.Serialize(pay);

            try
            {
                //Send the Property object to the Web API that will be used to store a new property record in the database.
                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.

                WebRequest request = WebRequest.Create(webApiUrl + "AddPayment/");
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
                    Response.Write("<script>alert('Property Successfully Rented')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Failed to rent property. The data wasn't recorded.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            displayEditProp(true);

            // Find a record in the database using the web service method that returns a Customer object
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(webApiUrl + "GetPropByID/" + Convert.ToInt32(Session["PropertyID"]));
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Properties prop = js.Deserialize<Properties>(data);

            if (prop != null)
            {
       
                PropImage.ImageUrl = prop.Image;
                tbName.Text = prop.Owner;
                tbAddress.Text = prop.Address;
                tbBeds.Text = prop.Beds.ToString();
                tbBaths.Text = prop.Bathrooms.ToString();
                tbRent.Text = prop.MonthlyRent.ToString();
                tbDescription.Text = prop.Description;
            }

            else

            {
                Response.Write("<script>alert('No record found')</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            displayEditProp(false);
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

                WebRequest request = WebRequest.Create(webApiUrl + "EditProperty/");
                request.Method = "PUT";
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
                    Response.Write("<script>alert('The property was successfully updated..')</script>");
                }
                else
                {
                    Response.Write("<script>alert('A problem occurred while updating the property. The data wasn't recorded.')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
            }
        }

        public void displayEditProp(bool tf)
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(webApiUrl + "DeleteProperty/" + Convert.ToInt32(Session["PropertyID"]));
            request.Method = "DELETE";
            WebResponse response = request.GetResponse();
            Response.Redirect("Homepage.aspx");
        }
    }
}