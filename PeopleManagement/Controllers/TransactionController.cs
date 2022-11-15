using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.TransactionBusiness;
using PeopleManagement.Repository.Interface;
using PeopleManagement.ViewModels.Transaction;

namespace PeopleManagement.Controllers
{
    public class TransactionController : Controller
    {
        public readonly ITransactionRepository _transactionRepository;
        public readonly TransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _transactionBusiness = new TransactionBusiness(_transactionRepository);
        }   

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
            _transactionBusiness.AddNewTransaction(transaction);
            return RedirectToAction("AccountDetails", "Accounts", new { accountCode  = transaction.AccountCode});
        }
        
        public IActionResult TransactionDetails(int accountCode)
        {
            var transaction = _transactionBusiness.GetTransactionByCode(accountCode);
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
            _transactionBusiness.UpdateTransaction(transaction);
            return RedirectToAction("AccountDetails", "Accounts", new { accountCode = transaction.AccountCode });
        }
    }
}
