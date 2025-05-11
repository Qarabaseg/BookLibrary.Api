using BookLibrary.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EditionController : ControllerBase
{
    private readonly IEditionRepository _repository;

    public EditionController(IEditionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("book/{bookId}")]
    public async Task<IActionResult> GetEditionsByBookId(int bookId)
    {
        var editions = await _repository.GetEditionsByBookIdAsync(bookId);
        return Ok(editions);
    }

    [HttpGet("author/{authorId}")]
    public async Task<IActionResult> GetEditionsByAuthorId(int authorId)
    {
        var editions = await _repository.GetEditionsByAuthorIdAsync(authorId);
        return Ok(editions);
    }
}