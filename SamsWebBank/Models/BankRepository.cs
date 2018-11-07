using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsWebBank.Models
{
    public class BankRepository
    {
        private Dictionary<int, Account> CreateAllAcounts()
        {
            return new Dictionary<int, Account>()
            {
                { 1, new Account{AccountNumber=1,Salary=10000 } },
                { 2, new Account{AccountNumber=2,Salary=20000 } },
                { 3, new Account{AccountNumber=3,Salary=5000 } },
                { 4, new Account{AccountNumber=4,Salary=30000 } },
                { 5, new Account{AccountNumber=5,Salary=100000 } },
                { 6, new Account{AccountNumber=6,Salary=12000 } },
            };
        }

        public List<Customer> GetAllCustomers()
        {
            var accounts = CreateAllAcounts();

            return new List<Customer>
            {

                new Customer
                {
                    ID=1,
                    FirstName="Samuel",
                    LastName="Bering",
                   Accounts=new Dictionary<int, Account>()
                   {
                       {1, accounts[1] },
                       {2, accounts[2] },
                   }

                },
                 new Customer
                {
                    ID=2,
                    FirstName="Anders",
                    LastName="Henriksson",
                    Accounts=new Dictionary<int, Account>()
                   {
                       {3, accounts[3] },
                       {4, accounts[4] },
                   }

                },
                  new Customer
                {
                    ID=3,
                    FirstName="Fredrik",
                    LastName="Karlsson",
                    Accounts=new Dictionary<int, Account>()
                   {
                       {5, accounts[5] },
                   }

                },
                   new Customer
                {
                    ID=4,
                    FirstName="Susanne",
                    LastName="Näslund",
                    Accounts=new Dictionary<int, Account>()
                   {
                       {6, accounts[6] },
                   }

                }

            };
        }

    }
}
