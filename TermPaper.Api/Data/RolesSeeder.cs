using Microsoft.EntityFrameworkCore;
using TermPaper.Shared.Entities;
using TermPaper.Shared.Enums;

namespace TermPaper.Api.Data
{
    public static class RolesSeeder
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
        }
    }
}
