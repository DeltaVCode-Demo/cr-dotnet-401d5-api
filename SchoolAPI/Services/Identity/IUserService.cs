using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolAPI.Models.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolAPI.Services.Identity
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);
        Task<UserDto> Authenticate(LoginData data);
        Task<UserDto> GetUser(ClaimsPrincipal user);
    }
}