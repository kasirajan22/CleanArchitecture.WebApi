using System.Net.Mime;
using ApplicationLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registers user into the system 
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns>Returns sign up response</returns>
        [AllowAnonymous]
        [HttpPost("signup", Name = nameof(SignUpAsync))]
        [ProducesResponseType(typeof(ResponseOk<SignUpResponseDto>), 200)]
        [ProducesResponseType(typeof(ResponseFailure), 400)]
        public async Task<IActionResult> SignUpAsync(SignUpRequestDto requestDto)
        {
            var response = await _userService.SignUpAsync(requestDto, Header);
            return Ok(response);
        }
    }
}
