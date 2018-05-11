using System.Threading.Tasks;

namespace Biosphere.Common.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        
        Task SaveChangesAsync();
    }
}