using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Requests.BookRequests;
using Microsoft.AspNetCore.Authorization;
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

    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize]
    [HttpGet("GetAll")]
    public async Task<IEnumerable<Book>> GetAll()
    {
        //var result = await _bookService.GetAll();

        //if (result != null && result.Count() < 0) return Ok(result);

        //return NotFound();

        return await _bookService.GetAll();
    }

    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IEnumerable<Book>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("Add")]
    public async Task Add([FromBody] AddBookRequest book)
    {
        await _bookService.Add(book);
    }

    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0) return BadRequest();

        var result = await _bookService.GetById(id);

        if (result != null) return Ok(result);

        return NotFound();
    }

    [HttpPut("Update")]
    public async Task Update([FromBody] Book book)
    {
        await _bookService.Update(book);
    }

    [HttpDelete("Delete")]
    public async Task Delete(int id)
    {
        await _bookService.Delete(id);
    }
}

