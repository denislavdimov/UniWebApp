using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.MongoDB
{
    public class UserInfoMongoRepository : IUserInfoRepository
    {
        private readonly IMongoCollection<UserInfo> _users;

        public UserInfoMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _users =
                database.GetCollection<UserInfo>(nameof(UserInfo));
        }

        public async Task Add(UserInfo user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task<UserInfo?> GetUserInfo(string username, string password)
        {
            return await _users.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }
    }
}
