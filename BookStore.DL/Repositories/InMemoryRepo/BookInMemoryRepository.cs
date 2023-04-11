using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories.InMemoryRepo
{
    public class BookInMemoryRepository
    {
        public void Add(Book book)
        {
            InMemoryDb.Data.Books.Add(book);
        }

        public void Delete(int id)
        {
            var bookToDelete =
                InMemoryDb.Data.Books.FirstOrDefault(a => a.Id == id);

            if (bookToDelete != null)
            {
                InMemoryDb.Data.Books.Remove(bookToDelete);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return InMemoryDb.Data.Books;
        }

        public IEnumerable<Book> GetAllByAuthorId(int authorId)
        {
            return InMemoryDb.Data.Books.Where(book => book.Id == authorId);
        }

        public IEnumerable<Book> GetAllByAuthorIdAndReleaseDate(int authorId, int releaseDate)
        {
            return InMemoryDb.Data.Books.Where(book => book.Id == authorId && book.ReleaseDate == releaseDate);
        }

        public Book GetById(int id)
        {
            return InMemoryDb.Data.Books.FirstOrDefault(i => i.Id == id);
        }

        public void Update(Book book)
        {
            var bookToUpdate =
                InMemoryDb.Data.Books.FirstOrDefault(a => a.Id == book.Id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Name = book.Name;
            }
        }
    }
}
