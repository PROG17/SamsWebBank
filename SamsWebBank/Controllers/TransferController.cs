using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsWebBank.Models;
using SamsWebBank.Models.ViewModels;

namespace SamsWebBank.Controllers
{
    public class TransferController : Controller
    {
       
        BankRepository _bankRepository = BankRepository.Instance;
        Dictionary<string, string> _errorMessagesDict;

        public TransferController()
        {
            _errorMessagesDict = new Dictionary<string, string>()
            {
                { "Avsändarens kontonummer finns inte.","Sender account doesn´t exists!" },
                { "Mottagarens kontonummer finns inte.","Target account doesn´t exists!" },
                { "Beloppet kan inte vara negativt","Amount can´t be negative!"},
                { "Det finns inte tillräckligt med pengar på kontot.","Not enough money on the account!"},
                { "Du kan måste ange två unika konton","Target account can not be the sender account!"}
            };
        }
 
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Transfer(TransferVM vm)
        {
            string result;
            var accounts = new List<Account>();

            result = _bankRepository.Transfer(vm.FromAccount, vm.ToAccount, vm.Amount);

            if (result == "success")
            {
                accounts.Add(_bankRepository.Accounts.FirstOrDefault(c => c.Key == vm.FromAccount).Value);
                accounts.Add(_bankRepository.Accounts.FirstOrDefault(c => c.Key == vm.ToAccount).Value);

                return PartialView("_TransferStatus", accounts);
            }
            else
                return PartialView("_ErrorMessage", _errorMessagesDict[result]);
        }
    }
}