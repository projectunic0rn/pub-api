using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore;
using Common.AppSettings;

namespace Infrastructure.Persistence
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(AppSettings.ConnectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}