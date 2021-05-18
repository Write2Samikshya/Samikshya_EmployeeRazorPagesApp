﻿using System;
using System.Collections.Generic;
using EmployeeRazorPagesApp.Models;

namespace EmployeeRazorPagesApp.Services
{
    public interface  IEmployeeRepo
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeebyID(int id);
        Employee Update(Employee UpdatedEmployee);

        Employee Add(Employee newEmployee);



    }
}
