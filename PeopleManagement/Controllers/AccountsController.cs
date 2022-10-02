using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.AccountsBusiness;
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
    }
}
