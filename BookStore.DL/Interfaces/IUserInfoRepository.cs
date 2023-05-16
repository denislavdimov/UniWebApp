using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<UserInfo?> GetUserInfo(string username, string password);
        public Task Add(UserInfo user);
    }
}
