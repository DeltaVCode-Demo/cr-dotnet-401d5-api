using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using SchoolAPI.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolAPI.Services.Identity
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtService jwtService;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtService jwtService, ILogger<IdentityUserService> logger)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
            Logger = logger;
        }

        public ILogger<IdentityUserService> Logger { get; }

        public async Task<UserDto> Authenticate(LoginData data)
        {
            var user = await userManager.FindByNameAsync(data.Username);

            if (await userManager.CheckPasswordAsync(user, data.Password))
            {
                return await CreateUserDto(user);
            }

            Logger.LogInformation("Invalid login for username '{Username}'", data.Username);
            return null;
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            if (user == null) return null;

            return await CreateUserDto(user);
        }

        public async Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                Email = data.Email,
                UserName = data.Username,
                // PasswordHash = data.Password // NOOOOOOO
            };
            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                if (data.Roles.Length > 0)
                {
                    await userManager.AddToRolesAsync(user, data.Roles);
                }

                return await CreateUserDto(user);
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private async Task<UserDto> CreateUserDto(ApplicationUser user)
        {
            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,

                Roles = await userManager.GetRolesAsync(user),

                Token = await jwtService.GetToken(user, TimeSpan.FromMinutes(5))
            };
        }
    }
}
