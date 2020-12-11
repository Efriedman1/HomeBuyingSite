using Microsoft.AspNetCore.Mvc;
using WalletAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace WalletAPI.Controllers
{
    [Route("api/wallet")]
    public class ValuesController : ControllerBase
    {

        //Creating multiple routes in addition to the default route
        [HttpGet] //route: api/properties
        [HttpGet("ViewPayments")] //route: api/properties/viewproperties
        //Retrieve list of all properties from the database
        public List<Payments> getPayments(int renterId)
        {
            List<Payments> paymentList = new List<Payments>();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPaymentsByRenterID";
            objCommand.Parameters.AddWithValue("@id", renterId);

            DataSet paymentData = objDB.GetDataSetUsingCmdObj(objCommand);

            int count = paymentData.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                Payments pay = new Payments();
                pay.PaymentID = Convert.ToInt32(objDB.GetField("PaymentID", i));
                pay.PaymentDate = objDB.GetField("PaymentDate", i).ToString();
               // pay.PaymentFullfilled = Convert.ToInt32(objDB.GetField("PaymentFullfilled", i));
                pay.PaymentAmount = Convert.ToDecimal(objDB.GetField("PaymentAmount", i));
               // pay.RenterID = Convert.ToInt32(objDB.GetField("RenterID", i));
              //  pay.PropertyID = Convert.ToInt32(objDB.GetField("PropertyID", i));

                paymentList.Add(pay);
            }
            return paymentList;
        }

        // This method accepts a payment object and creates a new record based on the values
        // set for the object passed into the method.
        [HttpPost()]
        [HttpPost("AddPayment")]
        public Boolean AddPayment([FromBody]Payments pay)
        {
            if (pay != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddPayment";

                objCommand.Parameters.AddWithValue("@PaymentDate", pay.PaymentDate);
               // objCommand.Parameters.AddWithValue("@PaymentID", pay.PaymentID);
                objCommand.Parameters.AddWithValue("@PropertyID", pay.PropertyID);
                objCommand.Parameters.AddWithValue("@RenterID", 7);
                objCommand.Parameters.AddWithValue("@PaymentAmount", pay.PaymentAmount);
                
                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        [HttpPut()]
        [HttpPut("PartialPayment")]
        public Boolean PartialPayment([FromBody]Payments pay)
        {
            if (pay != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_EditPayment";

                objCommand.Parameters.AddWithValue("@PaymentID", pay.PaymentID);
                objCommand.Parameters.AddWithValue("@PaymentAmount", pay.PaymentAmount);
                objCommand.Parameters.AddWithValue("@PaymentDate", DateTime.Now.ToString());
                //objCommand.Parameters.AddWithValue("@PaymentFullfilled", pay.PaymentFullfilled);
                //objCommand.Parameters.AddWithValue("@RenterID", pay.RenterID);
                //objCommand.Parameters.AddWithValue("@PropertyID", pay.PropertyID);

                int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete]
        [HttpDelete("DeletePayment/{paymentId}")]
        public Boolean deletePropById(int paymentId)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RemovePayment";
            objCommand.Parameters.AddWithValue("@id", paymentId);

            int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

            if (retVal > 0)
                return true;
            else
                return false;
        }
    }
}
