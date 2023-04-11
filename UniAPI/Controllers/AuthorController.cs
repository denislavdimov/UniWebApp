using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace UniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IAuthorService _authorService;

    public AuthorController(ILogger<AuthorController> logger,
        IAuthorService authorService)
    {
        _logger = logger;
        _authorService = authorService;
    }

    [HttpGet("GetAll")]
    public async Task<IEnumerable<Author>> GetAll()
    {
        return await _authorService.GetAll();
    }

    [HttpPost("Add")]
    public async Task Add([FromBody] AddAuthorRequest authorRequest)
    {
        await _authorService.Add(authorRequest);
    }

    [HttpGet("GetById")]
    public async Task<Author> GetById(int id)
    {
        return await _authorService.GetById(id);
    }

    [HttpPut("Update")]
    public async Task Update([FromBody] UpdateAuthorRequest author)
    {
        await _authorService.Update(author);
    }

    [HttpDelete("Delete")]
    public async Task Delete(int id)
    {
        await _authorService.Delete(id);
    }
}

