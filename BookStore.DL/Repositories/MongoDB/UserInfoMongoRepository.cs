using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.MongoDB
{
    public class UserInfoMongoRepository : IUserInfoRepository
    {
        private readonly IMongoCollection<UserInfo> _usersInfo;

        public UserInfoMongoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client =
                new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _usersInfo =
                database.GetCollection<UserInfo>(nameof(UserInfo));
        }

        public async Task<UserInfo?> GetUserInfo(string username, string password)
        {
            return await _usersInfo.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }
    }
}
