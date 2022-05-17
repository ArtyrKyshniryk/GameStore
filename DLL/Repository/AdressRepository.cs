using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class AdressRepository : BaseRepository<Address>
    {
        public AdressRepository(GameStoreContext context, DbSet<Address> entities) : base(context, entities)
        {
        }
    }
}
