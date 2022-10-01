using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Data.Person;
using PeopleManagement.Models.Person;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.ViewModels.Persons;

namespace PeopleManagement.Business.PersonsBusiness
{
    public class PersonBusiness
    {
        private readonly PersonRepository _personRepository;
        public List<PersonViewModel> GetPersons(string searchString)
        {
            using var repo = new PersonRepository();
            var persons = repo.GetPersons(searchString).GetAwaiter().GetResult();
            return ObjectMapper.Mapper.Map<List<PersonViewModel>>(persons);
        }

        public PersonViewModel GetPersonByCode(int personCode)
        {
            using var repo = new PersonRepository();
            var person = repo.GetPersonByCode(personCode);
            return ObjectMapper.Mapper.Map<PersonViewModel>(person);
        }

        public void EditPerson(PersonViewModel personModel)
        {
            using var repo = new PersonRepository();
            repo.UpdatePerson(ObjectMapper.Mapper.Map<Person>(personModel));
        }

        public int DeletePerson(int personCode)
        {
            using var repo = new PersonRepository();
            return repo.DeletePerson(personCode);
        }

        public void AddPerson(PersonViewModel personModel)
        {
            using var repo = new PersonRepository();
            repo.AddPerson(ObjectMapper.Mapper.Map<Person>(personModel));
        }

        public List<PersonAccountViewModel> GetPersonAndAccountInfo(int personCode)
        {
            using var repo = new PersonRepository();
            var results = repo.GetPersonAndAccounts(personCode).GetAwaiter().GetResult();
            return ObjectMapper.Mapper.Map<List<PersonAccountViewModel>>(results);
        }
    }
}
