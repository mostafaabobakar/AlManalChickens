using AlManalChickens.Controllers.Shared;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Services.Api.Contract.Auth;
using AlManalChickens.Services.DTO;
using AlManalChickens.Services.DTO.AuthApiDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.Api
{
    [ApiExplorerSettings(GroupName = "AuthAPI")]
    public class AuthController : BaseAPIController
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromForm] RegisterDto input)
        {
            var result = await _accountService.Register(input);
            return StatusCode(result.StatusCode, result);
        }


        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPatch(ApiRoutes.Identity.ConfirmCode)]
        public async Task<IActionResult> ConfirmCode([FromBody] ConfirmCodeDto input)
        {
            var result = await _accountService.ConfirmCode(input);
            return StatusCode(result.StatusCode, result);
        }


        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet(ApiRoutes.Identity.ResendCode)]
        public async Task<IActionResult> ResendCode([FromBody] ResendCodeDto input)
        {
            var result = await _accountService.ResendCode(input);
            return StatusCode(result.StatusCode, result);
        }


        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<UserInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto input)
        {
            var result = await _accountService.Login(input);
            return StatusCode(result.StatusCode, result);
        }


        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Identity.ChangePassward)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto input)
        {
            var result = await _accountService.ChangePassword(input);
            return StatusCode(result.StatusCode, result);
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost(ApiRoutes.Identity.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto input)
        {
            var result = await _accountService.ResetPassword(input);
            return StatusCode(result.StatusCode, result);
        }


        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete(ApiRoutes.Identity.Logout)]
        public async Task<IActionResult> Logout([FromBody] LogoutDto input)
        {
            var result = await _accountService.Logout(input);
            return StatusCode(result.StatusCode, result);
        }


        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete(ApiRoutes.Identity.RemoveAccount)]
        public async Task<IActionResult> RemoveAccount()
        {
            var result = await _accountService.RemoveAccount();
            return StatusCode(result.StatusCode, result);
        }
    }
}