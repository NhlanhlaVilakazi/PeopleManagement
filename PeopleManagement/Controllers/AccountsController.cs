using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.AccountsBusiness;
using PeopleManagement.Business.AccountTransactionBusiness;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult CreateAccount(int personCode)
        {
            return View(new AccountViewModel { PersonCode = personCode});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateAccount(AccountViewModel accountInfo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some error occured, please try again later.");
                return View(accountInfo);
            }
            var bussiness = new AccountBusiness();
            bussiness.CreatePersonAccount(accountInfo);
            return RedirectToAction("PersonDetails", "Persons", new { personCode = accountInfo.PersonCode});
        }

        public IActionResult UpdatePersonAccount(int accountCode)
        {
            var business = new AccountBusiness();
            var accountInfo = business.GetAccountInformation(accountCode);
            return View(accountInfo);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult UpdatePersonAccount(AccountViewModel accountInfo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some error occured, please try again later.");
                return View(accountInfo);
            }
            var bussiness = new AccountBusiness();
            bussiness.UpdateAccountInformation(accountInfo);
            return RedirectToAction("PersonDetails", "Persons", new { personCode = accountInfo.PersonCode});
        }

        public IActionResult AccountDetails(int accountCode)
        {
            var business = new AccountTransactionBusiness();
            var results = business.GetAccountAndTransactionInfo(accountCode);
            return View(results);
        }
    }
}
