using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsWebBank.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal Salary { get; set; }

        public string Transfer(decimal amount, string type)
        {
            if (amount < 0)
                return "Beloppet kan inte vara negativt";
            //if(amount > Salary)
            //    return "Det finns inte tillräckligt med pengar på kontot.";

            switch (type)
            {
                case "reciever":
                    Salary += amount;
                    break;
                case "sender":
                    if (amount > Salary)
                        return "Det finns inte tillräckligt med pengar på kontot.";
                    Salary -= amount;
                    break;
                default:
                    break;
            }
        

            return "success";
        }
    }
}
