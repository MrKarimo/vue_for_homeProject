using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace Command.Base
{
    class Repository<TEntity> where TEntity : class
    {
        DbContext _context;
        DbSet<TEntity> _table;

        public Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _table.FirstOrDefaultAsync(where);
        }

        public virtual IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _table.Where(where);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _table;
        }
    }
}
