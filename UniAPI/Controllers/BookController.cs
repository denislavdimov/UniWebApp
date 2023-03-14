using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IBookService _bookService;

    public BookController(ILogger<AuthorController> logger,
        IBookService bookservice)
    {
        _logger = logger;
        _bookService = bookservice;
    }

    [HttpGet("GetAll")]
    public IEnumerable<Book> GetAll()
    {
        return _bookService.GetAll();
    }

    [HttpPost("Add")]
    public void Add([FromBody] Book book)
    {
        _bookService.Add(book);
    }

    [HttpGet("GetById")]
    public Book GetById(int id)
    {
        return _bookService.GetById(id);
    }

    [HttpPut("Update")]
    public void Update([FromBody] Book book)
    {
        _bookService.Update(book);
    }

    [HttpDelete("Delete")]
    public void Delete(int id)
    {
        _bookService.Delete(id);
    }
}

