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
        bool PersonAlreadyExist(string idNumber);
    }
}
