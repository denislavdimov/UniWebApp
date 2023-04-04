using BookStore.Models.Responses;

namespace BookStore.BL.Interfaces
{
    public interface ILibraryService
    {
        Task<GetAllBooksByAuthorRepsonse> GetAllBooksByAuthorId(int id);
        Task<GetAllBooksByAuthorRepsonse> GetAllBooksByAuthorAndReleaseDate(int id, int releaseDate);
    }
}
