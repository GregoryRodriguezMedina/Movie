using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnCore.Movie.Services;
using EnCore.Core;
using Microsoft.AspNetCore.Cors;
using EnCore.Movie.Identity;

namespace WebNg.Controllers
{

    [Produces("application/json")]
    //[Route("api/[controller]")]
     [EnableCors("AllwAnyOrigin")]
    [Route("api/security")]
    public class AccountController : BaseApiController
    {
        private readonly UserService userService;

        public AccountController(UserService userService)
        {
            this.userService = userService;
        }
        
        // POST: api/Movies
        [HttpPost("login")]
        public IActionResult Login([FromBody]string user, string password)
        {
            return this.GetHttpResponse(() =>
            {
                var result = this.userService.Login(user, password);

                return Ok(result);
            });
        }

        [HttpGet("session")]
        public IActionResult Session()
        {
            return this.GetHttpResponse(() =>
            {
                var result = this.userService.ExistsSession();

                return Ok(result);
            });
        }
    }
}