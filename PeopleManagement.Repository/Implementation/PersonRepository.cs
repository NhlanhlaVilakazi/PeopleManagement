using Microsoft.EntityFrameworkCore;
using PeopleManagement.Data;
using PeopleManagement.Data.Person;
using PeopleManagement.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace PeopleManagement.Repository.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private DataContext _dbContext;
        public PersonRepository()
        {
            _dbContext = new DataContext();
        }
        public Task<List<Person>> GetPersons(string searchString)
        {
            object[] parameter = {
                new SqlParameter("@searchString", string.IsNullOrEmpty(searchString) ? (object) DBNull.Value : (object) searchString)
            };
            const string query = "EXEC [GetPersons] @searchString";
            return _dbContext.Set<Person>().FromSqlRaw(query, parameter).ToListAsync();
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
