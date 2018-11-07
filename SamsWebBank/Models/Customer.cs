using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsWebBank.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<int, Account> Accounts { get; set; }
    }
}
