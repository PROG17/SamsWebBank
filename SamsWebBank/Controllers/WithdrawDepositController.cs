using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SamsWebBank.Models;
using SamsWebBank.Models.ViewModels;

namespace SamsWebBank.Controllers
{
    public class WithdrawDepositController : Controller
    {
        BankRepository _bankRepository = BankRepository.Instance;
        Dictionary<string, string> _errorMessagesDict;

        public WithdrawDepositController()
        {
            _errorMessagesDict = new Dictionary<string, string>()
            {
                { "Kontonumret finns inte.","Account doesn´t exists!" },
                { "Beloppet kan inte vara negativt","Amount can´t be negative!"},
                { "Det finns inte tillräckligt med pengar på kontot.","Not enough money on the account!"}
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult WithdrawDeposit(WithdrawDepositVM vm)
        {
            string result;

            if (vm.transactionType == "withdrawal")
                result = _bankRepository.Withdraw(vm.Account, vm.Amount);
            else
                result = _bankRepository.Deposit(vm.Account, vm.Amount);

            if (result == "success")
                return PartialView("_AccountStatus", _bankRepository.Accounts[vm.Account]);
            else
                return PartialView("_ErrorMessage", _errorMessagesDict[result]);
        }
    }
}