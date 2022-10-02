using PeopleManagement.Data.DataModels.Accounts;

namespace PeopleManagement.Repository.Interface
{
    public interface IAccountRepository : IDisposable
    {
        void AddNewAccount(Account accountModel);
    }
}
