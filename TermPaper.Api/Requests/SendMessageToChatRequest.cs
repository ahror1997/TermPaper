namespace TermPaper.Api.Requests
{
    public class SendMessageToChatRequest
    {
        public int OrderId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
