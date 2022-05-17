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
    internal class ReviewRepository : BaseRepository<Review>
    {
        public ReviewRepository(GameStoreContext context, DbSet<Review> entities) : base(context, entities)
        {
        }
        public async override Task<IReadOnlyCollection<Review>> FindByConditionAsync(Expression<Func<Review, bool>> predicat)
        {
            return await Entities.Include(p => p.Product).Include(p => p.ReviewUser).Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async override Task<IReadOnlyCollection<Review>> GetAllASync()
        {
            return await Entities.Include(p => p.ReviewUser).Include(p => p.Product).ToListAsync().ConfigureAwait(false);
        }
    }
}
