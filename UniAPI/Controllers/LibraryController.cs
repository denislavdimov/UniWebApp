using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Models;
using BookStore.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace UniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LibraryController : ControllerBase
{
    private readonly ILibraryService _libraryService;

    public LibraryController(ILibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    [HttpGet("GetAllBooksByAuthor")]
    public GetAllBooksByAuthorRepsonse GetAllBooksByAuthor(int authorId)
    {
        return _libraryService.GetAllBooksByAuthorId(authorId);
    }

    [HttpGet("GetAllBooksByAuthorAndReleaseDate")]
    public GetAllBooksByAuthorRepsonse GetAllBooksByAuthorAndReleaseDate(int authorId, int releaseDate)
    {
        return _libraryService.GetAllBooksByAuthorAndReleaseDate(authorId, releaseDate);
    }
}

