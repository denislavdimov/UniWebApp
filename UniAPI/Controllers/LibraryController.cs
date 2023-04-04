using BookStore.BL.Interfaces;
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
    public async Task<GetAllBooksByAuthorRepsonse> GetAllBooksByAuthor(int authorId)
    {
        return await _libraryService.GetAllBooksByAuthorId(authorId);
    }

    [HttpGet("GetAllBooksByAuthorAndReleaseDate")]
    public async Task<GetAllBooksByAuthorRepsonse> GetAllBooksByAuthorAndReleaseDate(int authorId, int releaseDate)
    {
        return await _libraryService.GetAllBooksByAuthorAndReleaseDate(authorId, releaseDate);
    }
}

