using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected GameStoreContext _context;
        private DbSet<TEntity> _entities;
        protected DbSet<TEntity> Entities => _entities = _context.Set<TEntity>();
        protected BaseRepository(GameStoreContext context, DbSet<TEntity> entities)
        {
            _context = context;
            _entities = entities;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat) => await Entities.Where(predicat).ToListAsync().ConfigureAwait(false);

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllASync() => await Entities.ToListAsync().ConfigureAwait(false);

        public async Task<OperationDetails> CreateAsync(TEntity entity)
        {
            try
            {
                await Entities.AddAsync(entity).ConfigureAwait(false);
                return new OperationDetails() { Message = "Created", IsCompleted = true };
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Fatal exception on creat");
                return new OperationDetails() { Message = "Failed", IsCompleted = false };
            }
        }
    }
}
