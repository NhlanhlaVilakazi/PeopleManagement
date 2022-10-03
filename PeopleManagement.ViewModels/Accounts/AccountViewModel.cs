using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.ViewModels.Accounts
{
    public class AccountViewModel
    {
        public int code { get; set; }
        public int PersonCode { get; set; }

        [Required]
        [DisplayName("Account Number")]
        [Remote("CheckIfAccountExist", "Accounts", HttpMethod = "POST", ErrorMessage = "Account already exists. Please enter a different Account Number.")]
        public string? AccountNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Outstanding Account")]
        public decimal OutstandingBalance { get; set; }
    }
}
