
namespace ManicOceanic.DOMAIN.Entities
{
    public abstract class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
