using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesAPI.Models
{
    public class Properties
    {
        public int PropertyID { get; set; }
        public int OwnerID { get; set; }
        public int RenterID { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Owner { get; set; }
        public int Beds { get; set; }
        public int Bathrooms { get; set; }
        public decimal MonthlyRent { get; set; }
        public string Description { get; set; }
    }
}
