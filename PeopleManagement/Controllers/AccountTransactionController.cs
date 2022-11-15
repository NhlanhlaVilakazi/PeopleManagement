using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.AccountTransactionBusiness;
using PeopleManagement.Repository.Interface;

namespace PeopleManagement.Controllers
{
    public class AccountTransactionController : Controller
    {
        private readonly IAccountTransactionRepository _transactionRepository;
        private readonly AccountTransactionBusiness _transactionBusiness;

        public AccountTransactionController(IAccountTransactionRepository transactionRepo)
        {
            _transactionRepository = transactionRepo;
            _transactionBusiness = new AccountTransactionBusiness(_transactionRepository);
        }

        public IActionResult AccountDetails(int accountCode)
        {
            var results = _transactionBusiness.GetAccountAndTransactionInfo(accountCode);
            return View(results);
        }
    }
}
