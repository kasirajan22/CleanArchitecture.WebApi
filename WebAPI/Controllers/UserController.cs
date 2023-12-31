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
        public UserController(IApplicationWrapper application) : base(application) { }

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
            var response = await _application.userService.SignUpAsync(requestDto, Header);
            return Ok(response);
        }

        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("signin", Name = nameof(SignInAsync))]
        [ProducesResponseType(typeof(ResponseOk<UserDto>), 200)]
        [ProducesResponseType(typeof(ResponseFailure), 400)]
        public async Task<IActionResult> SignInAsync(SignInDto requestDto)
        {
            var response = await _application.userService.SignInAsync(requestDto, Header);
            return Return(response);
        }
    }
}
