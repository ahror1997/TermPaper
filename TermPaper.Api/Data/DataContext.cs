using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TermPaper.Shared.Entities;

namespace TermPaper.Api.Data
{
    public class DataContext : IdentityDbContext<User, Role, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("users");
            builder.Entity<Role>().ToTable("user_roles");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");

            builder.Entity<Order>().ToTable("orders");
            builder.Entity<Portfolio>().ToTable("portfolios");
            builder.Entity<Project>().ToTable("projects");
            builder.Entity<QuestionAnswer>().ToTable("question_answers");

            RolesSeeder.Seed(builder);
        }
    }
}
