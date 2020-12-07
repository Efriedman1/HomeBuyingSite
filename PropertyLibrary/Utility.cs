using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;
using System.Data.SqlClient;
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
