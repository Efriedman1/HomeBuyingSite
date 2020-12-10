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

            for(int i = 0; i < count; i++)
            {
                Properties prop = new Properties();
                //prop.PropertyID = Convert.ToInt32(objDB.GetField("PropertyID", i));
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
      
        [HttpGet("GetPropByID")] //route: api/properties/GetPropByID
        public String getPropertyByID(int propId)
        {
            return "Web API - HTTP Get with propertyID = " + propId;
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
    }

}


//SqlParameter rentParameter = new SqlParameter("@Rent", prop.MonthlyRent);
//rentParameter.SqlDbType = SqlDbType.Money;
//rentParameter.Direction = ParameterDirection.Input;
//rentParameter.Size = 8;
//objCommand.Parameters.Add(rentParameter);