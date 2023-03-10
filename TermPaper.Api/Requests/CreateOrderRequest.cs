namespace TermPaper.Api.Requests
{
    public class CreateOrderRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Deadline { get; set; } = string.Empty;
    }
}
