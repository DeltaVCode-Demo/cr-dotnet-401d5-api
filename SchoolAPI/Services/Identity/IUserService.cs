using SchoolAPI.Models.Identity;
using System.Threading.Tasks;

namespace SchoolAPI.Services.Identity
{
    public interface IUserService
    {
        Task Register(RegisterData data);
    }
}