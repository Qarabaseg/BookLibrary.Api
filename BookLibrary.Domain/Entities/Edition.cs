namespace BookLibrary.Domain.Entities
{
    public class Edition
    {
        public int Id { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Name { get; set; } = string.Empty;

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}