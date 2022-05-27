using DLL;
using DLL.Models;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAddressService
    {
        void AddAddress(Address  address);
        void ChangeAddress(Address neWaddress, int oldAddressId);
        void DeleteAddress(Address neWaddress, User user);
    }
}
