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
    [Authorize]
    public class EmployeeController : BaseController
    {
        public EmployeeController(IApplicationWrapper application) : base(application) { }

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns>Returns all employee response</returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ResponseOk<List<EmployeeDto>>), 200)]
        [ProducesResponseType(typeof(ResponseFailure), 400)]
        public IActionResult GetAll()
        {
            var response = _application.employeeService.GetAll(Header);
            return Ok(response);
        }        
    }
}
