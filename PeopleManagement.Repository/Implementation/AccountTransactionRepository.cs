using PeopleManagement.Data;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PeopleManagement.Repository.Implementation
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private DataContext _dbContext;
        public AccountTransactionRepository()
        {
            _dbContext = new DataContext();
        }
        public Task<List<AccountTransaction>> GetAccountAndTransactionInfo(int accountCode)
        {
                SqlParameter[] parameter = 
                {
                    new SqlParameter("@accountCode",  accountCode)
                };
                const string query = "[GetAccountAndListOfTransactions] @accountCode";
                return _dbContext.Set<AccountTransaction>().FromSqlRaw(query, parameter).ToListAsync();
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
