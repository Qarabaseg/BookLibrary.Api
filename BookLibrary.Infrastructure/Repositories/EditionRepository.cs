using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces;
using BookLibrary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.Repositories;

public class EditionRepository : IEditionRepository
{
    private readonly LibraryDbContext _context;

    public EditionRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Edition>> GetEditionsByBookIdAsync(int bookId)
    {
        return await _context.Editions
            .Where(e => e.BookId == bookId)
            .ToListAsync();
    }

    public async Task<List<Edition>> GetEditionsByAuthorIdAsync(int authorId)
    {
        return await _context.Editions
            .Include(e => e.Book)
            .Where(e => e.Book.AuthorId == authorId)
            .ToListAsync();
    }
}