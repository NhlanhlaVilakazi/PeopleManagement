using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.Repository.Interface;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Business.AccountTransactionBusiness
{
    public class AccountTransactionBusiness
    {
        private readonly IAccountTransactionRepository _transactionRepository;

        public AccountTransactionBusiness(IAccountTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public List<AccountTransactionViewModel> GetAccountAndTransactionInfo(int accountCode)
        {
            var results = _transactionRepository.GetAccountAndTransactionInfo(accountCode).GetAwaiter().GetResult();
            return ObjectMapper.Mapper.Map<List<AccountTransactionViewModel>>(results);
        }
    }
}
