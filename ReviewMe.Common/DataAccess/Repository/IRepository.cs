using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biosphere.Common.DataAccess.Entity;

namespace Biosphere.Common.DataAccess.Repository
{
    public interface IRepository<T> : IDisposable where T : DbElementBase
    {
        Task<T> Get(Expression<Func<T, bool>> where);

        void Edit(T item);
        
        void Add(T item);
        
        void Delete(T item);

        void Delete(int id);
    }
}