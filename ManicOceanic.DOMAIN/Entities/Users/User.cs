
using Microsoft.AspNetCore.Identity;

namespace ManicOceanic.DOMAIN.Entities
{
    public abstract class User : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
