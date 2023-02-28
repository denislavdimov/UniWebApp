using BookStore.BL.Interfaces;
using BookStore.Models.Models;
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
    public IEnumerable<Author> GetAll()
    {
        return _authorService.GetAll();
    }

    [HttpPost("Add")]
    public void Add([FromBody]Author author)
    {
        _authorService.Add(author);
    }

    [HttpGet("GetById")]
    public Author GetById(int id)
    {
        return _authorService.GetById(id);
    }
}

