﻿using DLL;
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
        Task<IReadOnlyCollection<Employeer>> GetAllEmployeesAsync();
        Task<IReadOnlyCollection<Employeer>> FindEmployeeByConditiomAsync(Expression<Func<Employeer, bool>> prediacte);
        Task<Employeer> GetEmployeeByIdAsync(int employeeId);
    }
}
