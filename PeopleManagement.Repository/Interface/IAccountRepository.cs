using PeopleManagement.Data.DataModels.Accounts;

namespace PeopleManagement.Repository.Interface
{
    public interface IAccountRepository : IDisposable
    {
        void AddNewAccount(Account accountModel);
        void UpdateAccount(Account accountModel);
        Account GetAccountInfomationByCode(int accountCode);
    }
}
