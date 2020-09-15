using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Common.AppSettings;
using System.Linq;

namespace Infrastructure.Persistence.Entities
{
    public class UserEntity : IStorage<UserEntity>
    {
        private readonly string _connectionString;

        public UserEntity()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string HashedPassword { get; set; }
        public string Timezone { get; set; }
        public string Locale { get; set; }
        public bool LookingForProject { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string GitHubUsername { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTimeOffset ResetPasswordTokenExpiresAt { get; set; }
        public string MagicLoginToken { get; set; }
        public DateTimeOffset MagicLoginTokenExpiresAt { get; set; }
        public List<ProjectUserEntity> ProjectUsers { get; set; }
        public List<TechnologyEntity> UserTechnologies { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public async Task<UserEntity> CreateAsync(UserEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.CreatedAt = DateTimeOffset.UtcNow;
            item.UpdatedAt = DateTimeOffset.UtcNow;

            await context.Users.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            var user = new UserEntity { Id = id };
            context.Users.Attach(user);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<List<UserEntity>> FindAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<UserEntity> items = await context.Users
            .Include(u => u.UserTechnologies)
            .Include(u => u.ProjectUsers)
            .ToListAsync();
            return items;
        }

        public async Task<UserEntity> FindAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            UserEntity item = await context.Users
            .Include(u => u.UserTechnologies)
            .Include(u => u.ProjectUsers)
            .SingleOrDefaultAsync(predicate);
            return item;
        }

        public async Task<List<UserEntity>> FindAllAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            List<UserEntity> items = await context.Users
                .Where(predicate)
                .OrderByDescending(u=> u.UpdatedAt)
                .Take(20)
                .ToListAsync();
            return items;
        }

        // used to assign generated username 
        // with incrementing value
        public async Task<UserEntity> FindLastUnicornRecord()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            UserEntity item = await context.Users.OrderByDescending(u => u.CreatedAt).Where(u => u.Username.StartsWith("unicorn")).FirstOrDefaultAsync();
            return item;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity item)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseMySql(_connectionString);
            using var context = new DatabaseContext(optionsBuilder.Options);

            item.UpdatedAt = DateTimeOffset.UtcNow;
            context.Users.Update(item);
            await context.SaveChangesAsync();
            return item;
        }

        public Task DeleteAllAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
