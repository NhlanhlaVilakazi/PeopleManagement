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
        
        public IActionResult TransactionDetails(int accountCode)
        {
            var business = new TransactionBusiness();
            var transaction = business.GetTransactionByCode(accountCode);
            return View(transaction);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult UpdateTransaction(TransactionViewModel transaction)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some error occured, please try again later.");
                return View(transaction);
            }
            var business = new TransactionBusiness();
            business.UpdateTransaction(transaction);
            return RedirectToAction("AccountDetails", "Accounts", new { accountCode = transaction.AccountCode });
        }
    }
}
