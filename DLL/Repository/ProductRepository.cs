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
    public class ProductRepository : BaseRepository<Product>
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

        public  async  Task AddToOrderAsync(Product product, int orderId)
        {
            product.OrderId = orderId;
            base._context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base._context.SaveChanges();
        }
        public async Task ChangeProductAsync(Product newProduct, int oldProductId)
        {
            var product = base._context.Products.Find(oldProductId);
            product.Order = newProduct.Order;
            product.Reviews = newProduct.Reviews;
            product.Employeer = newProduct.Employeer;
            product.OrderId = newProduct.OrderId;
            product.Price = newProduct.Price;
            product.Category = newProduct.Category;
            product.CategoryId = newProduct.CategoryId;
            product.Description = newProduct.Description;
            base._context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base._context.SaveChanges();
        }
        public async Task RemoveProductFromOrderAsync(int orderId, int remProductId)
        {
            base._context.Orders.Find(orderId).Products.Remove(base._context.Orders.Find(orderId).Products.Where(x => x.Id == remProductId).First());
        }
    }
}
