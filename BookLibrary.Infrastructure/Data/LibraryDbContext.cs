using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Edition> Editions => Set<Edition>();
    }
}