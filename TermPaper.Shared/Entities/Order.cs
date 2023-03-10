using System.Text.Json.Serialization;
using TermPaper.Shared.Enums;

namespace TermPaper.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public DateOnly Deadline { get; set; }

        [JsonIgnore]
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
