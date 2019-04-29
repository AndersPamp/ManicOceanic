using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Repositories.Interfaces;

namespace ManicOceanic.DATA.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MOContext moContext;

        public UnitOfWork(MOContext moContext)
        {
            this.moContext = moContext;
        }

        public async Task SaveChangesAsync()
        {
            await moContext.SaveChangesAsync();
        }
    }
}
