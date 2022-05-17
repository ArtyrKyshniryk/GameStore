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
    internal class PhotoRepository : BaseRepository<Photo>
    {
        public PhotoRepository(GameStoreContext context, DbSet<Photo> entities) : base(context, entities)
        {
        }
    }
}
