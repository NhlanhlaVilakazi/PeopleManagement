using PeopleManagement.Data.BaseClass;

namespace PeopleManagement.Data.DataModels.Accounts
{
    public class Account : BasePrimaryKey
    {
        public int PersonCode { get; set; }
        public string? AccountNumber { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}
