using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;   
        }

        public async Task Add(UserInfo user)
        {
            await _userInfoRepository.Add(user);
        }

        public async Task<UserInfo?> GetUserInfo(string username, string password)
        {
            return await _userInfoRepository.GetUserInfo(username, password);
        }
    }
}
