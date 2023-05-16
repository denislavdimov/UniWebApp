using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace UniAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly IUserInfoService _userInfoService;

    public UserInfoController(IUserInfoService userInfoService)
    {
        _userInfoService = userInfoService;
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("AddUser")]
    public async Task Add([FromBody]UserInfo user)
    {
        //if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password)) BadRequest();
        await _userInfoService.Add(user);
    }

    [HttpGet("Login")]
    public async Task<UserInfo?> GetUserInfo(string username, string password)
    {
        return await _userInfoService.GetUserInfo(username, password);
    }
}

