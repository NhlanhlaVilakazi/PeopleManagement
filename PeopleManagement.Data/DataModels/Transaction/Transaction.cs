using PeopleManagement.Data.BaseClass;

namespace PeopleManagement.Data.DataModels.Transaction
{
    public class Transaction : BasePrimaryKey
    {
        public int AccountCode{ get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
