using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TermPaper.Shared.Entities;
using TermPaper.Shared.Enums;

namespace TermPaper.Api.Data
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            List<Role> roles = new List<Role>();

            foreach (var roleName in Enum.GetValues(typeof(UserRoles)))
            {
                roles.Add(new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = Convert.ToString(roleName),
                    NormalizedName = Convert.ToString(roleName)?.ToUpper(),
                });
            }

            builder.Entity<Role>().HasData(roles);

            User admin = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                FirstName = "John",
                LastName = "Doe"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "@dm1n");

            builder.Entity<User>().HasData(admin);
            builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roles.First().Id,
                UserId = admin.Id,
            });
        }
    }
}
