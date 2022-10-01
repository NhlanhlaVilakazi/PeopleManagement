using PeopleManagement.Data.DataModels.Persons;
using PeopleManagement.Data.Person;

namespace PeopleManagement.Repository.Interface
{
    public interface IPersonRepository : IDisposable
    {
        Task<List<Person>> GetPersons(string searchString);
        Person GetPersonByCode(int personCode);
        void UpdatePerson(Person person);
        int DeletePerson(int personCode);
        void AddPerson(Person person);
        Task<List<PersonAccount>> GetPersonAndAccounts(int personCode);
    }
}
