using PeopleManagement.Data.DataModels.Transaction;

namespace PeopleManagement.Repository.Interface
{
    public interface ITransactionRepository : IDisposable
    {
        void AddNewTransaction(Transaction transactionModel);
        void UpdateTransaction(Transaction transactionModel);
        Transaction GetTransactionByCode(int transactionCode);
    }
}
