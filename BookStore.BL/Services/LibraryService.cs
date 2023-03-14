using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Responses;

namespace BookStore.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public LibraryService(IAuthorRepository authorRepository, 
            IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public GetAllBooksByAuthorRepsonse GetAllBooksByAuthorAndReleaseDate(int id, int releaseDate)
        {
            //GetAllBooksByAuthorId(id);
            return new GetAllBooksByAuthorRepsonse()
            {
                Author = _authorRepository.GetById(id),
                Books = _bookRepository.GetAllByAuthorIdAndReleaseDate(id, releaseDate)
            };
        }

        public GetAllBooksByAuthorRepsonse GetAllBooksByAuthorId(int id)
        {
            return new GetAllBooksByAuthorRepsonse()
            {
                Author = _authorRepository.GetById(id),
                Books = _bookRepository.GetAllByAuthorId(id)
            };
        }


    }
}
