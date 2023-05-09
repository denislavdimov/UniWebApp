using AutoMapper;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Requests.BookRequests;
using Moq;
using UniAPI.AutoMapper;

namespace BookStore.Test

{
    public class BookServiceTest
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IMapper> _mapper;
        private BookService _service;

        private readonly IList<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Name = "UnitTestBook",
                ReleaseDate = 2023
            },
            new Book()
            {
                Id = 2,
                Name = "TestBookSecond",
                ReleaseDate = 2023
            }
        };

        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _mapper = new Mock<IMapper>();
            _service = new BookService(_bookRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task Book_GetAll_Count()
        {
            var expectedCount = 2;

            _bookRepository.Setup(x => x.GetAll()).Returns(async () => Books.AsEnumerable());

            var result = await _service.GetAll();

            var books = result.ToList();

            Assert.Equal(expectedCount, books.Count);
        }

        [Fact]
        public async Task Book_GetById_Test()
        {
            var expectedBook = Books.First(i => i.Id == 1);

            _bookRepository.Setup(x => x.GetById(1)).Returns(async () => Books.First(id => id.Id == 1));

            var result = await _service.GetById(1);

            var actual = result.Name;

            Assert.Equal(expectedBook.Name, actual);
        }

        [Fact]
        public async Task Book_GetById_Test_NotFound()
        {
            _bookRepository.Setup(x => x.GetById(3)).Returns(async () => Books.FirstOrDefault(id => id.Id == 3));

            var result = await _service.GetById(3);

            Assert.True(result == null);
        }

        [Fact]
        public async Task Book_Add_Test()
        {
            var newBook = new Book()
            {
                Id = 4,
                Name = "AddedBook",
                ReleaseDate = 2023
            };

            var newBookAddRequest = new AddBookRequest()
            {
                Name = "AddedBook",
                ReleaseDate = 2023
            };

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            //var bookToAdd = _mapper.Map<Book>(book);
            //var bookToAdd = _mapper.Object.Map<Book>(newBookAddRequest);

            _bookRepository.Setup(x => x.Add(It.IsAny<Book>())).Returns(async () => Books.Add(newBook));

            //_mapper.Setup(m => m.Map<Book>(newBookAddRequest))
            //    .Returns(async (AddBookRequest request) => mapper.Map<Book>(request));

            await _service.Add(newBookAddRequest);
            
            // assert
        }
    }
}