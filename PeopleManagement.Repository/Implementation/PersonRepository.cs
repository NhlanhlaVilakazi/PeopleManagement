using PeopleManagement.Data;
using PeopleManagement.Data.Person;
using PeopleManagement.Repository.Interface;

namespace PeopleManagement.Repository.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _dbContext;
        public PersonRepository()
        {
            _dbContext = new DataContext();
        }
        public List<Person> GetAllPeople()
        {
            const string query = "EXEC GetHostsRecommendedForSubmission";
            var results = _dbContext.Set<Person>().FromSqlRaw(query).ToList();
            return results;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
