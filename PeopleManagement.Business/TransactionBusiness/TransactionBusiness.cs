using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Data.DataModels.Transaction;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.Repository.Interface;
using PeopleManagement.ViewModels.Transaction;

namespace PeopleManagement.Business.TransactionBusiness
{
    public class TransactionBusiness
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionBusiness(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddNewTransaction(TransactionViewModel transaction)
        {
            _transactionRepository.AddNewTransaction(ObjectMapper.Mapper.Map<Transaction>(transaction));
        }

        public void UpdateTransaction(TransactionViewModel transaction)
        {
            _transactionRepository.UpdateTransaction(ObjectMapper.Mapper.Map<Transaction>(transaction));
        }

        public TransactionViewModel GetTransactionByCode(int transactionCode)
        {
            var results = _transactionRepository.GetTransactionByCode(transactionCode);
            return ObjectMapper.Mapper.Map<TransactionViewModel>(results);
        }
    }
}
