using DLL;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task AddToOrderAsync(Product product, int orderId);
        Task RemoveProductFromOrderAsync(int orderId, int remProductId);
    }
}
