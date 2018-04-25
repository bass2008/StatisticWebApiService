using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Biosphere.Common.DataAccess.Entity;

namespace Biosphere.Common.DataAccess.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : DbElementBase
    {
        protected readonly DbContext Context;

        protected readonly DbSet<T> Set;

        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = Context.Set<T>();
        }

        public virtual void Add(T item)
        {
            if (item.IsNew)
            {
                Set.Add(item);
            }
            else
            {
                throw new DbUpdateConcurrencyException("Cannot insert existing entity. Use update instead.");
            }
        }

        public virtual void Delete(T item)
        {
            Set.Remove(item);
        }

        public void Delete(int id)
        {
            var entity = Set.First(x => x.Id == id);
            Set.Remove(entity);
        }
        
        public async Task<T> Get(Expression<Func<T, bool>> where)
        {
            return await Set.FirstOrDefaultAsync(where);
        }
        
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
        
        public virtual void Edit(T entity)
        {
            var entry = Context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Modified;
                return;
            }

            var attachedEntity = Set.Local.SingleOrDefault(c => c.Id == entity.Id);

            if (attachedEntity != null)
            {
                var attachedEntry = Context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                // If current entity has attached relationship - attaching an entity will be failed
                entry.State = EntityState.Modified;
            }
        }
    }
}