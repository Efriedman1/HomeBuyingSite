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
    public partial class MyRentals : System.Web.UI.Page
    {
        String webApiUrl = "https://localhost:44383/api/wallet/";
        Utility utility;
        protected void Page_Load(object sender, EventArgs e)
        {
            utility = new Utility();

            try
            {
                if ((int)Session["userType"] != 0)
                {
                    //user is a not a renter, automatic redirect
                    Response.Redirect("Login.aspx");
                }
            }
            catch
            {
                //user has not signed in, automatic redirect to login screen
                Response.Redirect("Login.aspx");
            }

            DataSet userData = utility.GetUserByID((int)Session["UserID"]);
            decimal funds = Convert.ToDecimal(userData.Tables[0].Rows[0][4]);
            lblFunds.Text = "Funds: $" + funds.ToString("#.##");

            DataSet paymentData = utility.GetPaymentsByUserID((int)Session["UserID"]);
            DataTable paymentTable = paymentData.Tables[0];
            utility.PrintToDebug(paymentTable.Rows.Count, "Count");

            for (int i = 0; i < paymentTable.Rows.Count; i++)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl newDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                utility.PrintToDebug(paymentTable.Rows[i][0].ToString(), "Payment ID " + i);

                PaymentControl ctrl = (PaymentControl)LoadControl("PaymentControl.ascx");
                ctrl.PaymentID = Convert.ToInt32(paymentTable.Rows[i][0]);
                utility.PrintToDebug(ctrl.PaymentID, "Payment ID");
                ctrl.DataBind();
                Form.Controls.Add(ctrl);
                Button viewButton = new Button();
                viewButton.ID = "btnView" + i.ToString();

                viewButton.Text = "Pay in Full";
                viewButton.CssClass = "btn btnView";
                viewButton.Click += new EventHandler((s, a) => viewButton_Click(s, a, ctrl.PaymentID));
                Form.Controls.Add(viewButton);
            
                TextBox tbPartial = new TextBox();
                tbPartial.ID = "tbPartial" + i.ToString();
                Form.Controls.Add(tbPartial);

                Button partialPayment = new Button();
                partialPayment.ID = "btnPartial" + i.ToString();
                partialPayment.Text = "Make Partial Payment";
                partialPayment.CssClass = "btn-warning btn";
                partialPayment.Click += new EventHandler((s, a) => partialPayment_Click(s, a, ctrl.PaymentID, tbPartial.Text, ctrl.Rent));
                Form.Controls.Add(partialPayment);
            }
        }

        void viewButton_Click(object sender, EventArgs e, int id)
        {
            //utility.PrintToDebug(id, "Payment Click ID");
            //utility.SetPaymentPaid(id);
            deletePayment(id);
        }

        void partialPayment_Click(object sender, EventArgs e, int id, string amount, string rent)
        {
            string rent2 = rent.Remove(0,1);
            decimal amountDecimal = Convert.ToDecimal(amount);
            decimal calc = Convert.ToDecimal(rent2);
            if (amountDecimal > 0)
            {
                calc = calc - amountDecimal;
                Payments pay = new Payments();
                pay.PaymentID = id;
                pay.PaymentAmount = calc;

                if (calc <= 0)
                {
                    deletePayment(id);
                }
                else
                {
                    // Serialize a Property object into a JSON string.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonProp = js.Serialize(pay);

                    try
                    {
                        WebRequest request = WebRequest.Create(webApiUrl + "PartialPayment/");
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
                            Response.Redirect("MyRentals.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('A problem occurred while updating the payment balance. The data wasn't recorded.')</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
                    }
                }               
            }
            else
            {
                Response.Write("<script>alert('Please enter a value greater than 0 in the textbox')</script>");
            }
        }

        public void deletePayment(int id)
        {
            WebRequest request = WebRequest.Create(webApiUrl + "DeletePayment/" + id);
            request.Method = "DELETE";
            WebResponse response = request.GetResponse();
            Response.Redirect("MyRentals.aspx");
        }

        void partialButton_Click(object sender, EventArgs e, int id)
        {
            //Make partial payment
            Session["PaymentID"] = id;
            Response.Redirect("Payment.aspx");
        }
    }
}
