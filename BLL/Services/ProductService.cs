using DLL.Repository;
using DLL.Repository.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository repository)
        {
            this._productRepository = repository;
        }
        public async Task<IReadOnlyCollection<Product>> GetProductAsync()
        {
            return await (_productRepository as BaseRepository<Product>).GetAllASync();
        }
        public async Task<List<Product>> GetProductWithWorkerAsync()
        {
            return (await _productRepository.GetAllASync()).ToList();
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            var oper = await _productRepository.CreateAsync(product);
            return oper.IsCompleted;
        }
        public async Task<IReadOnlyCollection<Product>> GetProductsbyNamesAsync(List<string> Productname)
        {
            return await _productRepository.FindByConditionAsync(x => Productname.Contains(x.Name));
        }
        public Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> prediacte)
        => _productRepository.FindByConditionAsync(prediacte);
    }
}
