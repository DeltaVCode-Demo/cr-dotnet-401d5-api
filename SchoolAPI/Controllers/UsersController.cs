using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models.Identity;
using SchoolAPI.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<UserDto>> Register(RegisterData data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (user == null)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return user;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data);

            if (user == null)
                return Unauthorized();

            return user;
        }

        // Can't access this if you are not signed in!
        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<UserDto>> Self()
        {
            return await userService.GetUser(this.User);
        }
    }
}
