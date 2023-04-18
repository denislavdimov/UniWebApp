using AutoMapper;
using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Requests.BookRequests;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;   
        }

        public async Task Add(AddBookRequest book)
        {
            var bookToAdd = _mapper.Map<Book>(book);
            await _bookRepository.Add(bookToAdd);
        }

        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
    }
}
