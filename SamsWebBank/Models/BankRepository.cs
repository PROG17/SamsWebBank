﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamsWebBank.Models
{
    public class BankRepository
    {

        private Dictionary<int, Account> _accounts;
        private List<Customer> _customers;

        public BankRepository()
        {
            _accounts = CreateAllAcounts();
            _customers = CreateAllCustomers();
        }

        public Dictionary<int, Account> Accounts
        {
            get
            {
                return _accounts;
            }  
        }

        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
        }

        public string Withdraw(int accountNumber, decimal amount)
        {
            if (!_accounts.ContainsKey(accountNumber))
                return "Kontonumret finns inte.";

            if (amount < 0)
                return "Beloppet kan inte vara negativt";

            if (amount > _accounts[accountNumber].Salary)
                return "Det finns inte tillräckligt med pengar på kontot.";

            _accounts[accountNumber].Salary -= amount;

            return "";
        }


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

        private List<Customer> CreateAllCustomers()
        {
          
            return new List<Customer>
            {

                new Customer
                {
                    ID=1,
                    FirstName="Samuel",
                    LastName="Bering",
                   Accounts=new Dictionary<int, Account>()
                   {
                       {1, _accounts[1] },
                       {2, _accounts[2] },
                   }

                },
                 new Customer
                {
                    ID=2,
                    FirstName="Anders",
                    LastName="Henriksson",
                    Accounts=new Dictionary<int, Account>()
                   {
                       {3, _accounts[3] },
                       {4, _accounts[4] },
                   }

                },
                  new Customer
                {
                    ID=3,
                    FirstName="Fredrik",
                    LastName="Karlsson",
                    Accounts=new Dictionary<int, Account>()
                   {
                       {5, _accounts[5] },
                   }

                },
                   new Customer
                {
                    ID=4,
                    FirstName="Susanne",
                    LastName="Näslund",
                    Accounts=new Dictionary<int, Account>()
                   {
                       {6, _accounts[6] },
                   }

                }

            };
        }

    }
}
