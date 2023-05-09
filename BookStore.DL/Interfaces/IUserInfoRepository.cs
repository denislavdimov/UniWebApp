using BookStore.Models.Models;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        Task<UserInfo?> GetUserInfo(string username, string password);
    }
}
