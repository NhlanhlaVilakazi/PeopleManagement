using Microsoft.EntityFrameworkCore;
using PeopleManagement.Data;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace PeopleManagement.Repository.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private DataContext _dbContext;
        public AccountRepository()
        {
            _dbContext = new DataContext();
        }
        public void AddNewAccount(Account accountModel)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@personCode",  accountModel.PersonCode),
                new SqlParameter("@accountNumber",  accountModel.AccountNumber),
                new SqlParameter("@outstandingBalance",  accountModel.OutstandingBalance)
            };
            const string query = "[AddPersonAccount] @personCode, @accountNumber, @outstandingBalance";
            _dbContext.Database.ExecuteSqlRaw(query, parameters);
        }

        public void UpdateAccount(Account accountModel)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@accountCode",  accountModel.code),
                new SqlParameter("@accountNumber",  accountModel.AccountNumber),
                new SqlParameter("@outstandingBalance",  accountModel.OutstandingBalance)
            };
            const string query = "[UpdatePersonAccount] @accountCode, @accountNumber, @outstandingBalance";
            _dbContext.Database.ExecuteSqlRaw(query, parameters);
        }

        public Account GetAccountInfomationByCode(int accountCode)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@accountCode",  accountCode)
            };
            const string query = "EXEC [GetPersonAccount] @accountCode";
            return _dbContext.Set<Account>().FromSqlRaw(query, parameter).ToList().FirstOrDefault();
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
