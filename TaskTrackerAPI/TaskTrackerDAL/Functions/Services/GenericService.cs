using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskTrackerDAL.Databases;
using TaskTrackerDAL.Util.Functions.IServices;

namespace TaskTrackerDAL.Util.Functions.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly TaskTrackerDBContext _Context;
        private readonly DbSet<T> _db;

        public GenericService(TaskTrackerDBContext context)
        {
            _Context = context;
            _db = _Context.Set<T>();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _db.FindAsync(id);
            
            if(entity == null)
                return;

            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
           _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            
            if(includes != null)
            {
                foreach(var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;

            if(expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
          await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
