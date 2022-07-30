using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {

        private readonly IAuthenticationService authenticationservice;

        public AuthenController(IAuthenticationService authenticationservice)
        {
            this.authenticationservice = authenticationservice;

        }

        [HttpPost]
        public IActionResult authen([FromBody] login_api login)
        {
            var RESULT = authenticationservice.Authentication_jwt(login);

            if (RESULT == null)
            {
                return Unauthorized(); 
            }
            else
            {
                return Ok(RESULT); 
            }
        }
    }
}
