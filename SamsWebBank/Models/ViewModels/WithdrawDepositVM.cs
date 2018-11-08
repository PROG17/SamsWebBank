using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SamsWebBank.Models.ViewModels
{
    public class WithdrawDepositVM
    {
        [Display(Name = "Account")]
        [Range(1, 5000000, ErrorMessage = "Account number must be greater than zero")]
        public int Account { get; set; }
        [Range(1, 5000000, ErrorMessage = "Amount must be greater than zero")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        public string transactionType { get; set; }
    }
}
