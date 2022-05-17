using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    internal class UserRepository : BaseRepository<User>
    {
        public UserRepository(GameStoreContext context, DbSet<User> entities) : base(context, entities)
        {
        }
        public async override Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await Entities.Include(p => p.Orders).Include(p => p.Reviews).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<User>> GetAllASync()
        {
            return await Entities.Include(p => p.Reviews).Include(p => p.Orders).ToListAsync().ConfigureAwait(false);
        }
    }
}
