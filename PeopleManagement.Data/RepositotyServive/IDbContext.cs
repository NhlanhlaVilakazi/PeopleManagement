using Microsoft.EntityFrameworkCore;

namespace PeopleManagement.Data.RepositotyServive
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
    }
}
