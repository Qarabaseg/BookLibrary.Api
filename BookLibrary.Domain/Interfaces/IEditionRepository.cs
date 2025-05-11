using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain.Interfaces;

public interface IEditionRepository
{
    Task<List<Edition>> GetEditionsByBookIdAsync(int bookId);
    Task<List<Edition>> GetEditionsByAuthorIdAsync(int authorId);
}