﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyLibrary
{
    public class Payments
    {
        public int PaymentID { get; set; }
        public string PaymentDate { get; set; }
        public int PaymentFullfilled { get; set; }
        public decimal PaymentAmount { get; set; }
        public int RenterID { get; set; }
        public int PropertyID { get; set; }
 
    }
}
