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
                prop.PropertyID = Convert.ToInt32(objDB.GetField("PropertyID", i));
                prop.Address = objDB.GetField("Address", i).ToString();
                prop.MonthlyRent = Convert.ToDouble(objDB.GetField("Rent", i));
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

        [HttpPost] //route: api/properties (default route)
        [HttpPost("SaveProperty")] //route: api/properties/SaveProperty
        public string Post(string propName, string address, string owner)
        {
            return "Web API - HTTP Post execute. Received: Property Name = " + propName + " Address = " + address + " Owner = " + owner;
        }
    }


}