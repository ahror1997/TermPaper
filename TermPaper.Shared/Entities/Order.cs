using TermPaper.Shared.Enums;

namespace TermPaper.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
