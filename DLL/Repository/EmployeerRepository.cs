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
    internal class EmployeerRepository : BaseRepository<Employeer>
    {
        public EmployeerRepository(GameStoreContext context, DbSet<Employeer> entities) : base(context, entities)
        {
        }
        public async override Task<IReadOnlyCollection<Employeer>> FindByConditionAsync(Expression<Func<Employeer, bool>> predicat)
        {
            return await Entities.Include(p => p.Products).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<Employeer>> GetAllASync()
        {
            return await Entities.Include(p => p.Products).ToListAsync().ConfigureAwait(false);
        }
    }
}
