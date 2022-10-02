using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.TransactionBusiness;
using PeopleManagement.ViewModels.Transaction;

namespace PeopleManagement.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult AddTransaction(int accountCode)
        {
            return View(new TransactionViewModel { AccountCode = accountCode});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddTransaction(TransactionViewModel transaction)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some error occured, please try again later.");
                return View(transaction);
            }
            var business = new TransactionBusiness();
            business.AddNewTransaction(transaction);
            return RedirectToAction("AccountDetails", "Accounts", new { accountCode  = transaction.AccountCode});
        }
    }
}
