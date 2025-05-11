using System.Collections.Generic;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public ICollection<Edition> Editions { get; set; } = new List<Edition>();
    }
}