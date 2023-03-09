using Microsoft.EntityFrameworkCore;
using TermPaper.Shared.Entities;

namespace TermPaper.Api.Data
{
    public static class UserSeeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            User admin = new User()
            {
                UserName = "admin",
                Email = "admin@example.com",
                FirstName = "John",
                LastName = "Doe"
            };
        }
    }
}
