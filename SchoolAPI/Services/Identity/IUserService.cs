using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolAPI.Models.Identity;
using System.Threading.Tasks;

namespace SchoolAPI.Services.Identity
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(RegisterData data, ModelStateDictionary modelState);
    }
}