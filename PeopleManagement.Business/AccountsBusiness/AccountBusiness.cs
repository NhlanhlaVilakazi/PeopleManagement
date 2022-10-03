using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Business.AccountsBusiness
{
    public class AccountBusiness
    {
        public void CreatePersonAccount(AccountViewModel accountInfo)
        {
            using var repo = new AccountRepository();
            repo.AddNewAccount(ObjectMapper.Mapper.Map<Account>(accountInfo));
        }

        public void UpdateAccountInformation(AccountViewModel accountInfo)
        {
            using var repo = new AccountRepository();
            repo.UpdateAccount(ObjectMapper.Mapper.Map<Account>(accountInfo));
        }

        public AccountViewModel GetAccountInformation(int accountCode)
        {
            using var repo = new AccountRepository();
            var accountInfo = repo.GetAccountInfomationByCode(accountCode);
            return ObjectMapper.Mapper.Map<AccountViewModel>(accountInfo);
        }

        public bool DoesAccountExist(string accountNumber, bool isUpdate)
        {
            using var repo = new AccountRepository();
            return repo.AccountAlreadyExist(accountNumber, isUpdate);
        }
    }
}
