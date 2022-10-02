namespace PeopleManagement.Data.DataModels.Persons
{
    public class PersonAccount
    {
        public int PersonCode { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdNumber { get; set; }

        public int? AccountCode { get; set; }
        public string? AccountNumber { get; set; }
        public decimal? OustandingBalance { get; set; }
    }
}
