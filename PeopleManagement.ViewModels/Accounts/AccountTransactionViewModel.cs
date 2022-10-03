using Microsoft.AspNetCore.Mvc;

namespace PeopleManagement.ViewModels.Accounts
{
    public class AccountTransactionViewModel
    {
        public int AccountCode { get; set; }
        public int PersonCode { get; set; }
        [Remote("CheckIfAccountExist", "Accounts", AdditionalFields = "isUpdate", HttpMethod = "POST", ErrorMessage = "Account already exists. Please enter a different Account Number.")]
        public string? AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
