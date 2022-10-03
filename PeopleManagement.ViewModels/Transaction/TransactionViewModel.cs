using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.ViewModels.Transaction
{
    public class TransactionViewModel
    {
        public int code { get; set; }
        public int AccountCode { get; set; }

        [DisplayName("Transaction Date")]
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Transaction amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
