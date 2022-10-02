using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PeopleManagement.Data;
using PeopleManagement.Data.DataModels.Persons;
using PeopleManagement.Repository.Interface;

namespace PeopleManagement.Repository.Implementation
{
    public class PersonAccountRepository : IPersonAccountRepository
    {
        private DataContext _dbContext;
        public PersonAccountRepository()
        {
            _dbContext = new DataContext();
        }
        public Task<List<PersonAccount>> GetPersonAndAccounts(int personCode)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@personCode",  personCode)
            };
            const string query = "[GetPersonAndListOfAccounts] @personCode";
            return _dbContext.Set<PersonAccount>().FromSqlRaw(query, parameter).ToListAsync();
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
