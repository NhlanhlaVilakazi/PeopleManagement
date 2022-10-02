using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Data.DataModels.Transaction;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.ViewModels.Transaction;

namespace PeopleManagement.Business.TransactionBusiness
{
    public class TransactionBusiness
    {
        public void AddNewTransaction(TransactionViewModel transaction)
        {
            using var repo = new TransactionRepository();
            repo.AddNewTransaction(ObjectMapper.Mapper.Map<Transaction>(transaction));
        }
    }
}
