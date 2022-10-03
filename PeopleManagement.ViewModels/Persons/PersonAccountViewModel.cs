using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace PeopleManagement.ViewModels.Persons
{
    public class PersonAccountViewModel
    {
        public int PersonCode { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        [DisplayName("ID Number")]
        [Remote("CheckIfPersonAlreadyExist", "Persons", AdditionalFields = "isUpdate", HttpMethod = "POST", ErrorMessage = "Person already exists. Please enter a different ID Number.")]
        public string? IdNumber { get; set; }

        public string? AccountCode { get; set; }
        
        [DisplayName("AccountNumber")]
        public string? AccountNumber { get; set; }
        
        [DisplayName("Oustanding Balance")]
        public decimal? OustandingBalance { get; set; }
    }
}
