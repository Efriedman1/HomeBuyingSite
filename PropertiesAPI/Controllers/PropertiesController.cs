using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using PropertiesAPI.Models;
using Utilities;

namespace PropertiesAPI.Controllers
{
    [Route("api/properties")]
    public class PropertiesController : Controller
    {
        //Creating multiple routes in addition to the default route
        [HttpGet] //route: api/properties
        [HttpGet("ViewProperties")] //route: api/properties/viewproperties
        //Retrieve list of all properties from the database
        public List<Properties> getProperties()
        {
            List<Properties> propList = new List<Properties>();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProperties";
            DataSet propertyData = objDB.GetDataSetUsingCmdObj(objCommand);

            int count = propertyData.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                Properties prop = new Properties();
                prop.PropertyID = Convert.ToInt32(objDB.GetField("PropertyID", i));
                prop.Address = objDB.GetField("Address", i).ToString();
                prop.MonthlyRent = Convert.ToDecimal(objDB.GetField("Rent", i));
                prop.Beds = Convert.ToInt32(objDB.GetField("Beds", i));
                prop.Bathrooms = Convert.ToInt32(objDB.GetField("Baths", i));
                prop.Description = objDB.GetField("Description", i).ToString();
                prop.Image = objDB.GetField("ImageUrl", i).ToString();

                propList.Add(prop);
            }



            return propList;
        }

        [HttpGet("GetPropByID/{propId}")] //route: api/properties/GetPropByID
        public Properties getPropertyByID(int propId)
        {
            Properties prop = null;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPropertyByID";
            objCommand.Parameters.AddWithValue("@propertyID", propId);

            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            if (myDS.Tables[0].Rows.Count > 0)
            {
                prop = new Properties();
                prop.Address = objDB.GetField("Address", 0).ToString();
                prop.MonthlyRent = Convert.ToDecimal(objDB.GetField("Rent", 0));
                prop.Beds = Convert.ToInt32(objDB.GetField("Beds", 0));
                prop.Bathrooms = Convert.ToInt32(objDB.GetField("Baths", 0));
                prop.Description = objDB.GetField("Description", 0).ToString();
                prop.Image = objDB.GetField("ImageUrl", 0).ToString();
            }
            return prop;
        }

        // This method accepts a Property object and creates a new record based on the values
        // set for the object passed into the method.
        [HttpPost()]
        [HttpPost("AddProperty")]
        public Boolean AddProperty([FromBody]Properties prop)
        {
            if (prop != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddProperty";

                objCommand.Parameters.AddWithValue("@OwnerID", prop.OwnerID);
                objCommand.Parameters.AddWithValue("@OwnerName", prop.Owner);
                objCommand.Parameters.AddWithValue("@Address", prop.Address);
                objCommand.Parameters.AddWithValue("@Beds", prop.Beds);
                objCommand.Parameters.AddWithValue("@Baths", prop.Bathrooms);
                objCommand.Parameters.AddWithValue("@Rent", prop.MonthlyRent);
                objCommand.Parameters.AddWithValue("@Description", prop.Description);
                objCommand.Parameters.AddWithValue("@ImageUrl", prop.Image);

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
        [HttpPut("EditProperty")]
        public Boolean EditProperty([FromBody]Properties prop)
        {
            if (prop != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_EditProperty";

                objCommand.Parameters.AddWithValue("@PropertyID", 10);
                objCommand.Parameters.AddWithValue("@OwnerID", prop.OwnerID);
                objCommand.Parameters.AddWithValue("@OwnerName", prop.Owner);
                objCommand.Parameters.AddWithValue("@Address", prop.Address);
                objCommand.Parameters.AddWithValue("@Beds", prop.Beds);
                objCommand.Parameters.AddWithValue("@Baths", prop.Bathrooms);
                objCommand.Parameters.AddWithValue("@Rent", prop.MonthlyRent);
                objCommand.Parameters.AddWithValue("@Description", prop.Description);
                objCommand.Parameters.AddWithValue("@ImageUrl", prop.Image);

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
    }
}

