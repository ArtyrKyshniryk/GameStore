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
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(GameStoreContext context, DbSet<Category> entities) : base(context, entities)
        {
        }
        public async override Task<IReadOnlyCollection<Category>> FindByConditionAsync(Expression<Func<Category,bool>> predicat)
        {
            return await Entities.Include(p => p.SubCategory).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<Category>> GetAllASync()
        {
            return await Entities.Include(p => p.SubCategory).ToListAsync().ConfigureAwait(false);
        }
    }
}
