using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SamsWebBank.Controllers
{
    public class WithdrawDepositController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}