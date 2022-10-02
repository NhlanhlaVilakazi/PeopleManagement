using Microsoft.EntityFrameworkCore;
using PeopleManagement.Data;
using PeopleManagement.Data.Person;
using PeopleManagement.Repository.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

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
            SqlParameter[] parameter = {
                new SqlParameter("@searchString", string.IsNullOrEmpty(searchString) ? (object) DBNull.Value : (object) searchString)
            };
            const string query = "EXEC [GetPersons] @searchString";
            return _dbContext.Set<Person>().FromSqlRaw(query, parameter).ToListAsync();
        }

        public Person GetPersonByCode(int personCode)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@personCode",  personCode)
            };
            const string query = "EXEC [GetPersons] @personCode";
            return _dbContext.Set<Person>().FromSqlRaw(query, parameter).ToList().FirstOrDefault();
        }

        public void UpdatePerson(Person person)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@personCode",  person.code),
                new SqlParameter("@name",  person.Name),
                new SqlParameter("@surname",  person.Surname),
                new SqlParameter("@idNumber",  person.IdNumber)
            };
            const string query = "EXEC [UpdatePerson] @personCode, @name, @surname, @idNumber";
            _dbContext.Database.ExecuteSqlRaw(query, parameters);
        }

        public int DeletePerson(int personCode)
        {
            SqlParameter[] parameter = {
                new SqlParameter("@personCode",  personCode),
                new SqlParameter("@affectedRows",  0) { Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Int}
            };

            _dbContext.Database.ExecuteSqlRaw("[DeletePerson] @personCode, @affectedRows OUT", parameter);
            return (int)(parameter[1].Value ?? 0);
        }

        public void AddPerson(Person person)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@name",  person.Name),
                new SqlParameter("@surname",  person.Surname),
                new SqlParameter("@idNumber",  person.IdNumber)
            };
            const string query = "[AddNewPerson] @name, @surname, @idNumber";
            _dbContext.Database.ExecuteSqlRaw(query, parameters);
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
