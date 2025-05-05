using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Interfaces;

namespace BookLibrary.Application.Services;

public class BookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Book?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task AddAsync(Book book)
    {
        return _repository.AddAsync(book);
    }

    public Task UpdateAsync(Book book)
    {
        return _repository.UpdateAsync(book);
    }

    public Task DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}