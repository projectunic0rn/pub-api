using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
  public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
  {
    public DatabaseContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
      optionsBuilder.UseMySql("Server=localhost;Database=pub-dev;Uid=root;Pwd=;SslMode=Preferred;");
      return new DatabaseContext(optionsBuilder.Options);
    }
  }
}