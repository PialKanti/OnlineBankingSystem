using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBankingSystem.Entities;

namespace OnlineBankingSystem.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedDefaultAdminUser(builder);
            SeedRoles(builder);
            SeedDefaultAdminUserRole(builder);
        }

        private void SeedDefaultAdminUser(ModelBuilder builder)
        {
            var user = new ApplicationUser
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Default",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@test.com",
                NormalizedEmail = "admin@test.com".ToUpper(),
                LockoutEnabled = false,
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "admin123");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = Enums.Roles.Admin.ToString(),
                    ConcurrencyStamp = "1",
                    NormalizedName = Enums.Roles.Admin.ToString()
                },
                new IdentityRole
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    Name = Enums.Roles.User.ToString(),
                    ConcurrencyStamp = "2",
                    NormalizedName = Enums.Roles.User.ToString()
                });
        }

        private void SeedDefaultAdminUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711"
                });
        }
    }
}
