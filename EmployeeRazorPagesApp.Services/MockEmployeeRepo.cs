﻿using EmployeeRazorPagesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EmployeeRazorPagesApp.Services
{
    public class MockEmployeeRepo : IEmployeeRepo
    {
        private readonly List<Employee> _EmployeeList;

       
        public MockEmployeeRepo()
        {
            _EmployeeList = new List<Employee>()
            {
                new Employee() {ID=1, Age=12, Name="Samu", Email="Samu@gmail.com", Department=Dept.IT,Photopath="flower4.jpg"},
                new Employee() {ID=2, Age=12, Name="Samu2", Email="Samu@gmail.com", Department=Dept.HR,Photopath="flower2.jpg"},
                new Employee() {ID=3, Age=12, Name="Samu3", Email="Samu@gmail.com", Department=Dept.IT,Photopath="flower3.jpg"},
                new Employee() {ID=4, Age=13, Name="Samu4", Email="Samu1@gmail.com", Department=Dept.Payroll}

            };
        }



        public IEnumerable<Employee> GetEmployees()
        {
            return _EmployeeList;
        }

        public Employee GetEmployeebyID(int id)
        {
            return _EmployeeList.FirstOrDefault(e => e.ID == id);

        }

        public Employee Update(Employee UpdatedEmployee)
        {
            Employee employee= _EmployeeList.FirstOrDefault(e => e.ID == UpdatedEmployee.ID);
            if(employee !=null)
            {
                employee.Name = UpdatedEmployee.Name;
                employee.Email = UpdatedEmployee.Email;
                employee.Department = UpdatedEmployee.Department;
                employee.Photopath = UpdatedEmployee.Photopath;
            }

            return employee;
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.ID = _EmployeeList.Max(e => e.ID) + 1;
            _EmployeeList.Add(newEmployee);
            return newEmployee;
        }
    }
}
