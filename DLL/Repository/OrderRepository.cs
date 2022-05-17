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
    internal class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(GameStoreContext context, DbSet<Order> entities) : base(context, entities)
        {
        }
        public async override Task<IReadOnlyCollection<Order>> FindByConditionAsync(Expression<Func<Order, bool>> predicat)
        {
            return await Entities.Include(p => p.Address).Include(p => p.Address).Include(p => p.User).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<Order>> GetAllASync()
        {
            return await Entities.Include(p => p.User).Include(p => p.Address).Include(p => p.Address).ToListAsync().ConfigureAwait(false);
        }
    }
}
