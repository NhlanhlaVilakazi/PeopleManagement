namespace PeopleManagement.Data.DataModels.Accounts
{
    public class AccountTransaction
    {
        public int AccountCode { get; set; }
        public int PersonCode { get; set; }
        public string? AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
