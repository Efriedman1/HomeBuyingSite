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

        public Boolean AddUser(String name, String password, int type)
        {
            SqlCommand userCommand = new SqlCommand();
            userCommand.CommandType = CommandType.StoredProcedure;
            userCommand.CommandText = "TP_AddUser";

            SqlParameter nameParameter = new SqlParameter("@name", name);
            nameParameter.Direction = ParameterDirection.Input;
            nameParameter.SqlDbType = SqlDbType.VarChar;
            nameParameter.Size = 50;
            SqlParameter pwParameter = new SqlParameter("@password", password);
            pwParameter.Direction = ParameterDirection.Input;
            pwParameter.SqlDbType = SqlDbType.VarChar;
            pwParameter.Size = 50;
            SqlParameter typeParameter = new SqlParameter("@type", type);
            typeParameter.Direction = ParameterDirection.Input;
            typeParameter.SqlDbType = SqlDbType.Int;
            typeParameter.Size = 8;
            userCommand.Parameters.Add(nameParameter);
            userCommand.Parameters.Add(pwParameter);
            userCommand.Parameters.Add(typeParameter);
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

        public int CheckLogin(String name, String password)
        {
            int userId = 0;
            return userId;
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
    }
}
