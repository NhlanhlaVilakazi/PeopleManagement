using PeopleManagement.Data.DataModels.Persons;

namespace PeopleManagement.Repository.Interface
{
    public interface IPersonAccountRepository : IDisposable
    {
        Task<List<PersonAccount>> GetPersonAndAccounts(int personCode);
    }
}
