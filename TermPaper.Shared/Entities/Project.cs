namespace TermPaper.Shared.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
    }
}
