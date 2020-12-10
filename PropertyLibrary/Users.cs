using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyLibrary
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public decimal WalletAmount { get; set; }
        public string SecurityAnswers { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BillingAddress { get; set; }
    }
}
