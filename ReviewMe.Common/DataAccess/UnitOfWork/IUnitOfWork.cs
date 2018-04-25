using System.Threading.Tasks;

namespace Biosphere.Common.DataAccess.UnitOfWork
{
    /// <summary>
    ///     Единица работы в рамках одной бизнес-транзакции.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Сохранить изменения c логгированем изменений.
        /// </summary>
        void SaveChanges();

        /// <summary>
        ///     Сохранить изменения c логгированем изменений в асинхронном режиме.
        /// </summary>
        Task SaveChangesAsync();
    }
}