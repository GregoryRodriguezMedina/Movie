using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnCore.Movie.Services;
using EnCore.Core;
using Microsoft.AspNetCore.Cors;
using EnCore.Movie.Identity;
using EnCore.Movie.Core;

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
        public IActionResult Login([FromBody]LoginRequest login)
        {
            return this.GetHttpResponse(() =>
            {
                var result = this.userService.Login(login);

                return Ok(result);
            });
        }

        [HttpGet()]
        public IActionResult Session()
        {
            return this.GetHttpResponse(() =>
            {
               /// var result = this.userService.ExistsSession();

                return Ok(true);
            });
        }
    }
}