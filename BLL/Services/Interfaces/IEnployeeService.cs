using DLL;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEnployeeService
    {
        Task AddProductAsync(Product product, int employId);
        Task ChangeProductAsync(Product newProduct, int olDProductId);
        Task SendProductAsync(Product product);
    }
}
