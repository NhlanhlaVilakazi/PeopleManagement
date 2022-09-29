using PeopleManagement.Data.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Repository.Interface
{
    public interface IPersonRepository : IDisposable
    {
        List<Person>GetAllPeople();
    }
}
