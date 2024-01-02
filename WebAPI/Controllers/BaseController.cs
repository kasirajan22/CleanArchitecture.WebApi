using System.Net;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;

namespace MyApp.Namespace
{
    public class BaseController : ControllerBase
    {
        private Header _header = null!;
        [NonAction]
        public virtual IActionResult Return(Response response)
        {
            if (response.Ok) return Ok(response);

            return StatusCode((int)HttpStatusCode.BadRequest, response);
        }

        [NonAction]
        public virtual IActionResult BadRequest(string? message = null)
        {
            var response = new Response
            {
                Ok = false,
                Message = message ?? Constants.BadRequest
            };
            return BadRequest(response);
        }

        protected Header Header
        {
            get
            {
                if (_header is not null) return _header;

                _header = new Header();

                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (!string.IsNullOrWhiteSpace(token)) _header.Token = token;

                var ipAddress = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
                if (ipAddress != null) _header.IpAddress = ipAddress.ToString();

                var claimsIdentity = User.Identity as ClaimsIdentity;

                var userId = GetIdFromToken(claimsIdentity, ClaimTypes.Sid);
                if (!string.IsNullOrWhiteSpace(userId)) _header.UserId = new Guid(userId);

                var sessionId = GetIdFromToken(claimsIdentity, ClaimTypes.Hash);
                if (!string.IsNullOrWhiteSpace(sessionId)) _header.SessionId = new Guid(sessionId);

                var email = GetIdFromToken(claimsIdentity, ClaimTypes.Email);
                if (!string.IsNullOrWhiteSpace(email)) _header.UserName = email;

                var name = GetIdFromToken(claimsIdentity, ClaimTypes.Name);
                if (!string.IsNullOrWhiteSpace(name)) _header.Name = name;

                var roles = GetIdFromToken(claimsIdentity, Constants.Roles);
                _header.Roles = roles ?? "";

                _header.ActualHeader = JsonSerializer.Serialize(HttpContext.Request.Headers);
                return _header;
            }
        }

        private static string? GetIdFromToken(ClaimsIdentity? claimsIdentity, string match)
           => claimsIdentity?.FindFirst(match)?.Value;
    }
}
