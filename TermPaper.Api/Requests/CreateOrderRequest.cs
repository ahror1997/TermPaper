using TermPaper.Shared.Enums;

namespace TermPaper.Api.Requests
{
    public class CreateOrderRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
    }
}
