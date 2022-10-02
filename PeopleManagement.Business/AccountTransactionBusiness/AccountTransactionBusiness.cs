using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Business.AccountTransactionBusiness
{
    public class AccountTransactionBusiness
    {
        public List<AccountTransactionViewModel> GetAccountAndTransactionInfo(int accountCode)
        {
            using var repo = new AccountTransactionRepository();
            var results = repo.GetAccountAndTransactionInfo(accountCode).GetAwaiter().GetResult();
            return ObjectMapper.Mapper.Map<List<AccountTransactionViewModel>>(results);
        }
    }
}
