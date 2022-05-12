﻿using DLL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infastructure
{
    public static class Configuration
    {
        public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString, IdentityBuilder builder)
        {
            serviceCollection.AddDbContext<GameStoreContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("GameShop")));
            builder.AddEntityFrameworkStores<GameStoreContext>();
        }
    }
}
