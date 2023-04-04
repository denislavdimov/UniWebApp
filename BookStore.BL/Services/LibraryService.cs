using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Responses;
using Microsoft.Extensions.Logging;

namespace BookStore.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        //private readonly ILogger _logger;

        public LibraryService(IAuthorRepository authorRepository, 
            IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            //_logger = logger;   
        }

        public async Task<GetAllBooksByAuthorRepsonse> GetAllBooksByAuthorAndReleaseDate(int id, int releaseDate)
        {
            //GetAllBooksByAuthorId(id);
            return new GetAllBooksByAuthorRepsonse()
            {
                Author = await _authorRepository.GetById(id),
                Books = await _bookRepository.GetAllByAuthorIdAndReleaseDate(id, releaseDate)
            };
        }

        public async Task<GetAllBooksByAuthorRepsonse> GetAllBooksByAuthorId(int id)
        {
            //_logger.LogInformation("Logera bachka");
            return new GetAllBooksByAuthorRepsonse()
            {
                Author = await _authorRepository.GetById(id),
                Books = await _bookRepository.GetAllByAuthorId(id)
            };
        }


    }
}
