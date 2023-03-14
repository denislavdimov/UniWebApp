using BookStore.Models.Models;

namespace BookStore.Models.Responses
{
    public class GetAllBooksByAuthorRepsonse
    {
        public Author Author { get; set; }
        public IEnumerable<Book> Books { get; set; }

    }
}
