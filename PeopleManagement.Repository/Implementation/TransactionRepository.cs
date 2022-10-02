using Microsoft.EntityFrameworkCore;
using PeopleManagement.Data;
using PeopleManagement.Data.DataModels.Transaction;
using PeopleManagement.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace PeopleManagement.Repository.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private DataContext _dbContext;
        public TransactionRepository()
        {
            _dbContext = new DataContext();
        }
        public void AddNewTransaction(Transaction transaction)
        {
            SqlParameter[] parameters = {
                 new SqlParameter("@accountCode",  transaction.AccountCode),
                new SqlParameter("@transactionDate",  transaction.TransactionDate),
                new SqlParameter("@captureDate",  transaction.CaptureDate),
                new SqlParameter("@amount",  transaction.Amount),
                new SqlParameter("@description",  transaction.Description)
            };
            const string query = "[AddTransaction] @accountCode, @transactionDate, @captureDate, @amount, @description";
            _dbContext.Database.ExecuteSqlRaw(query, parameters);
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
