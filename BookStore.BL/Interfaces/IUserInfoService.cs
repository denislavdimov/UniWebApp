using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IUserInfoService
    {
        Task<UserInfo?> GetUserInfo(string username, string password);
    }
}
