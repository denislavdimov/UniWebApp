using BookStore.Models.Responses;

namespace BookStore.BL.Interfaces
{
    public interface ILibraryService
    {
        GetAllBooksByAuthorRepsonse GetAllBooksByAuthorId(int id);
        GetAllBooksByAuthorRepsonse GetAllBooksByAuthorAndReleaseDate(int id, int releaseDate);
    }
}
