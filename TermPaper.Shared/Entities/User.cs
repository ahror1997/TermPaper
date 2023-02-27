using Microsoft.AspNetCore.Identity;

namespace TermPaper.Shared.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Order>? Orders { get; set; }
        public Portfolio? Portfolio { get; set; }
        public int? PortfolioId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
