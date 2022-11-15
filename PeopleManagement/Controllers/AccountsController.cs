using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.AccountsBusiness;
using PeopleManagement.Business.AccountTransactionBusiness;
using PeopleManagement.Business.PersonsBusiness;
using PeopleManagement.Repository.Interface;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly AccountBusiness _accountBusiness;

        public AccountsController(IAccountRepository accountRepo)
        {
            _accountRepository = accountRepo;
            _accountBusiness = new AccountBusiness(_accountRepository);
        }
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
            _accountBusiness.CreatePersonAccount(accountInfo);
            return RedirectToAction("PersonDetails", "Persons", new { personCode = accountInfo.PersonCode});
        }

        public IActionResult UpdatePersonAccount(int accountCode)
        {
            var accountInfo = _accountBusiness.GetAccountInformation(accountCode);
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
            _accountBusiness.UpdateAccountInformation(accountInfo);
            return RedirectToAction("PersonDetails", "Persons", new { personCode = accountInfo.PersonCode});
        }
        

        [HttpPost]
        public JsonResult CheckIfAccountExist(string accountNumber, bool isUpdate)
        {
            var exist = _accountBusiness.DoesAccountExist(accountNumber, isUpdate);
            return Json(exist);
        }
    }
}
