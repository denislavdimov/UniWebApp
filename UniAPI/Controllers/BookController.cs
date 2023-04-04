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
    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _bookService.GetAll();
    }

    [HttpPost("Add")]
    public async Task Add([FromBody] Book book)
    {
        await _bookService.Add(book);
    }

    [HttpGet("GetById")]
    public async Task<Book> GetById(int id)
    {
        return await _bookService.GetById(id);
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

