using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Models.Person;
using PeopleManagement.Repository.Implementation;

namespace PeopleManagement.Business.PersonsBusiness
{
    public class PersonBusiness
    {
        public List<PersonViewModel> GetPersons(string searchString)
        {
            using var repo = new PersonRepository();
            var persons = repo.GetPersons(searchString).GetAwaiter().GetResult();
            return ObjectMapper.Mapper.Map<List<PersonViewModel>>(persons);
        }
    }
}
