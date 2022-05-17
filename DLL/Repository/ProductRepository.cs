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
    internal class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(GameStoreContext context, DbSet<Product> entities) : base(context, entities)
        {
        }
        public async override Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
        {
            return await Entities.Include(p => p.Category).Include(p => p.Employeer).Include(p => p.Photos).Include(p => p.Reviews).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<Product>> GetAllASync()
        {
            return await Entities.Include(p => p.Category).Include(p => p.Employeer).Include(p => p.Photos).Include(p => p.Reviews).ToListAsync().ConfigureAwait(false);
        }
    }
}
