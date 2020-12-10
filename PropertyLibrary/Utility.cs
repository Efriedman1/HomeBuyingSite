using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using PropertyLibrary;
using System.Diagnostics;

namespace PropertyLibrary
{
    public class Utility
    {
        DBConnect propertiesDB;
        public Utility()
        {
            propertiesDB = new DBConnect();
        }

        //Validation Methods

        public Boolean isNullOrEmpty(String[] strArray)
        {
            foreach (String st in strArray)
            {
                if (st == null || st.Equals(""))
                {
                    return true;
                }
            }
            return false;
        }

        public object getpropertybyid(object p)
        {
            throw new NotImplementedException();
        }

        public Boolean isEmail(String str)
        {
            try
            {
                return Regex.IsMatch(str,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        //DB Procedure Handling

        //Users

        public Boolean AddUser(String name, String password, String security, decimal funds, int type, String email, String address, String billing)
        {
            SqlCommand userCommand = new SqlCommand();
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.CommandText = "TP_AddUser";

            //SqlParameter nameParameter = new SqlParameter("@name", name);
            //nameParameter.Direction = ParameterDirection.Input;
            //nameParameter.SqlDbType = SqlDbType.VarChar;
            //nameParameter.Size = 50;
            //SqlParameter pwParameter = new SqlParameter("@password", password);
            //pwParameter.Direction = ParameterDirection.Input;
            //pwParameter.SqlDbType = SqlDbType.VarChar;
            //pwParameter.Size = 50;
            //SqlParameter securityParameter = new SqlParameter("@security", security);
            //securityParameter.Direction = ParameterDirection.Input;
            //securityParameter.SqlDbType = SqlDbType.VarChar;
            //securityParameter.Size = 255;
            //SqlParameter fundsParameter = new SqlParameter("@funds", funds);
            //fundsParameter.Direction = ParameterDirection.Input;
            //fundsParameter.SqlDbType = SqlDbType.Decimal;
            //fundsParameter.Size = 8;
            //SqlParameter typeParameter = new SqlParameter("@type", type);
            //typeParameter.Direction = ParameterDirection.Input;
            //typeParameter.SqlDbType = SqlDbType.Int;
            //typeParameter.Size = 8;
            //SqlParameter emailParameter = new SqlParameter("@email", email);
            //emailParameter.Direction = ParameterDirection.Input;
            //emailParameter.SqlDbType = SqlDbType.VarChar;
            //emailParameter.Size = 50;
            //SqlParameter addressParameter = new SqlParameter("@address", address);
            //addressParameter.Direction = ParameterDirection.Input;
            //addressParameter.SqlDbType = SqlDbType.VarChar;
            //addressParameter.Size = 255;
            //SqlParameter billingParameter = new SqlParameter("@billing", billing);
            //billingParameter.Direction = ParameterDirection.Input;
            //billingParameter.SqlDbType = SqlDbType.VarChar;
            //billingParameter.Size = 255;

            //userCommand.Parameters.Add(nameParameter);
            //userCommand.Parameters.Add(pwParameter);
            //userCommand.Parameters.Add(securityParameter);
            //userCommand.Parameters.Add(fundsParameter);
            //userCommand.Parameters.Add(typeParameter);
            //userCommand.Parameters.Add(emailParameter);
            //userCommand.Parameters.Add(addressParameter);
            //userCommand.Parameters.Add(billingParameter);

            userCommand.Parameters.AddWithValue("@name", name);
            userCommand.Parameters.AddWithValue("@password", password);
            userCommand.Parameters.AddWithValue("@security", security);
            userCommand.Parameters.AddWithValue("@funds", funds);
            userCommand.Parameters.AddWithValue("@type", type);
            userCommand.Parameters.AddWithValue("@email", email);
            userCommand.Parameters.AddWithValue("@address", address);
            userCommand.Parameters.AddWithValue("@billing", billing);

            int ret = propertiesDB.DoUpdateUsingCmdObj(userCommand);
            return ret > 0;
        }        

        public Boolean CheckUserNameTaken(String name)
        {
            SqlCommand userCommand = new SqlCommand();
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.CommandText = "TP_CheckUserName";

            SqlParameter nameParameter = new SqlParameter("@name", name);
            nameParameter.Direction = ParameterDirection.Input;
            nameParameter.SqlDbType = SqlDbType.VarChar;
            nameParameter.Size = 50;

            userCommand.Parameters.Add(nameParameter);
            DataSet userData = propertiesDB.GetDataSetUsingCmdObj(userCommand);
            if (userData.Tables[0].Rows.Count > 0)
            {
                PrintToDebug("TRUE", "UserName Taken");
                return true;
            }
            else
            {
                PrintToDebug("FALSE", "UserName Taken");
                return false;
            }            
        }

        public DataSet GetUserByID(int id)
        {
            SqlCommand userCommand = new SqlCommand();
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.CommandText = "TP_GetUserByID";

            SqlParameter idParameter = new SqlParameter("@id", id);
            idParameter.Direction = ParameterDirection.Input;
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Size = 8;

            userCommand.Parameters.Add(idParameter);
            DataSet userData = propertiesDB.GetDataSetUsingCmdObj(userCommand);
            return userData;
        }

        public int CheckLogin(String name, String password)
        {
            SqlCommand userCommand = new SqlCommand();
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.CommandText = "TP_CheckLogin";

            SqlParameter nameParameter = new SqlParameter("@name", name);
            nameParameter.Direction = ParameterDirection.Input;
            nameParameter.SqlDbType = SqlDbType.VarChar;
            nameParameter.Size = 50;

            SqlParameter pwParameter = new SqlParameter("@password", password);
            pwParameter.Direction = ParameterDirection.Input;
            pwParameter.SqlDbType = SqlDbType.VarChar;
            pwParameter.Size = 50;

            userCommand.Parameters.Add(nameParameter);
            userCommand.Parameters.Add(pwParameter);
            DataSet userData = propertiesDB.GetDataSetUsingCmdObj(userCommand);
            try
            {
                return Convert.ToInt32(userData.Tables[0].Rows[0][0]);
            }
            catch
            {
                return -1;
            }
        }

        public Boolean AddFunds(Decimal amount, int id)
        {
            SqlCommand paymentCommand = new SqlCommand();
            paymentCommand.CommandType = CommandType.StoredProcedure;
            paymentCommand.CommandText = "TP_AddFunds";

            SqlParameter idParameter = new SqlParameter("@id", id);
            idParameter.Direction = ParameterDirection.Input;
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Size = 8;

            SqlParameter amountParameter = new SqlParameter("@amount", amount);
            amountParameter.Direction = ParameterDirection.Input;
            amountParameter.SqlDbType = SqlDbType.Decimal;
            amountParameter.Size = 8;
            paymentCommand.Parameters.Add(amountParameter);
            paymentCommand.Parameters.Add(idParameter);

            int ret = propertiesDB.DoUpdateUsingCmdObj(paymentCommand);
            return ret > 0;
        }

        //Properties

        public Boolean AddNewProperty(String name, String address, String description, int bedAmount, int bathAmount)
        {
            return true;
        }

        public DataSet GetProperties()
        {
            SqlCommand propertyCommand = new SqlCommand();
            propertyCommand.CommandType = CommandType.StoredProcedure;
            propertyCommand.CommandText = "TP_GetProperties";
            DataSet propertyData = propertiesDB.GetDataSetUsingCmdObj(propertyCommand);
            return propertyData;
        }

        public DataSet GetPropertyByID(int id)
        {
            SqlCommand propertyCommand = new SqlCommand();
            propertyCommand.CommandType = CommandType.StoredProcedure;
            propertyCommand.CommandText = "TP_GetPropertyByID";
            SqlParameter idParameter = new SqlParameter("@propertyID", id);
            idParameter.Direction = ParameterDirection.Input;
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Size = 8;
            propertyCommand.Parameters.Add(idParameter);
            DataSet propertyData = propertiesDB.GetDataSetUsingCmdObj(propertyCommand);
            return propertyData;
        }

        //Payments
        public DataSet GetPaymentByID(int id)
        {
            SqlCommand paymentCommand = new SqlCommand();
            paymentCommand.CommandType = CommandType.StoredProcedure;
            paymentCommand.CommandText = "TP_GetPaymentByID";
            SqlParameter idParameter = new SqlParameter("@id", id);
            idParameter.Direction = ParameterDirection.Input;
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Size = 8;
            paymentCommand.Parameters.Add(idParameter);
            DataSet paymentData = propertiesDB.GetDataSetUsingCmdObj(paymentCommand);
            return paymentData;
        }

        public DataSet GetPaymentsByUserID(int id)
        {
            SqlCommand paymentCommand = new SqlCommand();
            paymentCommand.CommandType = CommandType.StoredProcedure;
            paymentCommand.CommandText = "TP_GetPaymentsByRenterID";
            SqlParameter idParameter = new SqlParameter("@id", id);
            idParameter.Direction = ParameterDirection.Input;
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Size = 8;
            paymentCommand.Parameters.Add(idParameter);
            DataSet paymentData = propertiesDB.GetDataSetUsingCmdObj(paymentCommand);
            return paymentData;
        }

        public Boolean SetPaymentPaid(int id)
        {
            SqlCommand paymentCommand = new SqlCommand();
            paymentCommand.CommandType = CommandType.StoredProcedure;
            paymentCommand.CommandText = "TP_MakePayment";
            SqlParameter idParameter = new SqlParameter("@id", id);
            idParameter.SqlDbType = SqlDbType.Int;
            idParameter.Size = 8;
            paymentCommand.Parameters.Add(idParameter);
            int ret = propertiesDB.DoUpdateUsingCmdObj(paymentCommand);
            return ret > 0;
        }

        //DEBUG
        public void PrintToDebug(double val, String tag)
        {
            System.Diagnostics.Debug.Print(tag + ": " + val.ToString() + "\n");
        }
        public void PrintToDebug(int val, String tag)
        {
            System.Diagnostics.Debug.Print(tag + ": " + val.ToString() + "\n");
        }
        public void PrintToDebug(String val, String tag)
        {
            System.Diagnostics.Debug.Print(tag + ": " + val + "\n");
        }

        public void PrintToDebug(Boolean val, String tag)
        {
            System.Diagnostics.Debug.Print(tag + ": " + val.ToString() + "\n");
        }
    }
}
