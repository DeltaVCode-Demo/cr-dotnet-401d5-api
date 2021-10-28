using System.Threading.Tasks;

namespace SchoolAPI.Models.Identity
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }

        public string Token { get; set; }
    }
}
