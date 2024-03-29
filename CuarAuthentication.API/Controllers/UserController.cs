﻿using System.Threading.Tasks;
using CuarAuthentication.DomainService.Dtos;
using CuarAuthentication.DomainService.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CuarAuthentication.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region  Actions

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginDto dto)
        {
            return Ok(await _userService.Authenticate(dto));
        }

        [HttpGet]
        [Route("username-exists")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> IsUserNameExists(string userName, int? userId)
        {
            return Ok(await _userService.IsUserNameExists(userName, userId));
        }

        [HttpPost]
        [Route("reset-password")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDto dto)
        {
            await _userService.ResetPasswordAsync(dto);
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody]UserDto dto)
        {
            await _userService.CreateUserAsync(dto);
            return Ok();
        }

        #endregion
    }
}