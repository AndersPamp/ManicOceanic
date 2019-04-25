using System.Threading.Tasks;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
