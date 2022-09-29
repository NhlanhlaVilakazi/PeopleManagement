namespace PeopleManagement.Data
{
    public static class ServiceExtension
    {
        public static string? dbConnectionString { get; set; }
        public static void FormsConnectionStringService(string connectionString)
        {
            dbConnectionString = connectionString;

            /*SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString)
            {
                ColumnEncryptionSetting = SqlConnectionColumnEncryptionSetting.Enabled
            };
            formsConnectionString = builder.ConnectionString;*/
        }
    }
}
