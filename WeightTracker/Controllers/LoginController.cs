using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightTracker.Models;
using WeightTracker.Services;

namespace WeightTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromForm] AuthenticateRequest model)
        {
            var response = _loginService.Authenticate(model);
            if (response == null)
            {
                return BadRequest(new
                {
                    message = "Username or password is incorrect"
                });
            }

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var logins = _loginService.GetAll();
            return Ok(logins);
        }
    }
}