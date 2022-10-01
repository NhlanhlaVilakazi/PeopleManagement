using PeopleManagement.Data.BaseClass;

namespace PeopleManagement.Data.Person
{
    public class Person : BasePrimaryKey
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string id_number { get; set; }
    }
}
