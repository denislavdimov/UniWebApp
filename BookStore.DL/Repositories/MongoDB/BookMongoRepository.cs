using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.MongoDB
{
    public class BookMongoRepository : IBookRepository
    {

        private readonly IMongoCollection<Book> _books;

        public BookMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _books =
                database.GetCollection<Book>(nameof(Book));
        }

        public async Task Add(Book book)
        {
           await _books.InsertOneAsync(book);
        }

        public async Task Delete(int id)
        {
            await _books.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _books.Find(book => true).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorId(int authorId)
        {
            return await _books.Find(x => x.Id == authorId).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAuthorIdAndReleaseDate(int id, int releaseDate)
        {
            return await _books.Find(book => book.Id == id && book.ReleaseDate == releaseDate).ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _books.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Book book)
        {
            var filter = Builders<Book>.Filter.Eq(a => a.Id, book.Id);
            var update = Builders<Book>.Update.Set(u => u.Name, book.Name);
            await _books.UpdateOneAsync(filter, update);
        }
    }
}
