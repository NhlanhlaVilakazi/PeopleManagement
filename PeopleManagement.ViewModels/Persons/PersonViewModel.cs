using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models.Person
{
    public class PersonViewModel
    {
        public int code { get; set; }

        [DisplayName("Name")]
        public string? Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string? Surname { get; set; }

        [Required]
        [DisplayName("ID Number")]
        public string? IdNumber { get; set; }
    }
}
