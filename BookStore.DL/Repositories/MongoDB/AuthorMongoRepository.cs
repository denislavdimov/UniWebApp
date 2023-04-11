using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.MongoDB
{
    public class AuthorMongoRepository : IAuthorRepository
    {

        private readonly IMongoCollection<Author> _authors;

        public AuthorMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _authors =
                database.GetCollection<Author>(nameof(Author));
        }

        public async Task Add(Author author)
        {
            await _authors.InsertOneAsync(author);
        }

        public Task Delete(int id)
        {
            return _authors.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authors.Find(author => true).ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await _authors.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task Update(Author author)
        {
            var filter = Builders<Author>.Filter.Eq(a => a.Id, author.Id);
            var update = Builders<Author>.Update.Set(u => u.Bio, author.Bio);
            return _authors.UpdateOneAsync(filter, update);
        }
    }
}
