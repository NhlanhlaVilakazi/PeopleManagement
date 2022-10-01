using PeopleManagement.Data.BaseClass;

namespace PeopleManagement.Data.Person
{
    public class Person : BasePrimaryKey
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }
    }
}
