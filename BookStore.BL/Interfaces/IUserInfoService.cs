using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IUserInfoService
    {
        public Task<UserInfo?> GetUserInfo(string username, string password);
        public Task Add(UserInfo user);
    }
}
