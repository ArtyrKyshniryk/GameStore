using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService, IEnployeeService
    {
        private readonly UserRepository _userRepository;
        private readonly EmployeerRepository _employeerRepository;
        private readonly ProductRepository _productRepository;
        public UserService(UserRepository userRepository, EmployeerRepository employeerRepository, ProductRepository productRepository)
        {
            _userRepository = userRepository;
            _employeerRepository = employeerRepository;
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(Product product, int employId)
        {
            product.EmplyeerId = employId;
            await _productRepository.CreateAsync(product);
        }

        public async Task AddToOrderAsync(Product product, int orderId)
        {
            await _productRepository.AddToOrderAsync(product,orderId);
        }

        public async Task ChangeProductAsync(Product newProduct, int olDProductId)
        {
            await _productRepository.ChangeProductAsync(newProduct,olDProductId);
        }

        public async Task RemoveProductFromOrderAsync(int orderId, int remProductId)
        {
           await _productRepository.RemoveProductFromOrderAsync(orderId, remProductId);
        }

        public Task SendProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
