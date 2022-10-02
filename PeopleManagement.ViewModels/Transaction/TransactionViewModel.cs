using System.ComponentModel;

namespace PeopleManagement.ViewModels.Transaction
{
    public class TransactionViewModel
    {
        public int code { get; set; }
        public int AccountCode { get; set; }

        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
