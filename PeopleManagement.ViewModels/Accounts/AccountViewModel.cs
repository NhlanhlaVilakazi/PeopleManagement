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
        public string? AccountNumber { get; set; }

        [Required]
        [DisplayName("Outstanding Account")]
        public decimal OutstandingBalance { get; set; }
    }
}
