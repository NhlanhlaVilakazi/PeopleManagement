using PeopleManagement.Data.DataModels.Accounts;

namespace PeopleManagement.Repository.Interface
{
    public interface IAccountTransactionRepository : IDisposable
    {
        Task<List<AccountTransaction>> GetAccountAndTransactionInfo(int accountCode);
    }
}
