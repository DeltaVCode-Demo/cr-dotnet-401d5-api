using Microsoft.AspNetCore.Identity;
using SchoolAPI.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Services.Identity
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> Register(RegisterData data)
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
                return user;
            }

            return null;
        }
    }
}
