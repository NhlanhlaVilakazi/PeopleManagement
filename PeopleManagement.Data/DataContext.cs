using Microsoft.EntityFrameworkCore;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Data.DataModels.Persons;
using PeopleManagement.Data.RepositotyServive;
using System.Data.SqlClient;

namespace PeopleManagement.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<Person.Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("PeopleManagementConnection") ?? throw new Exception("Please setup environment variable: PeopleManagementConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonAccount>().HasNoKey().ToView(null);
            modelBuilder.Entity<AccountTransaction>().HasNoKey().ToView(null);
        }

    }
}
