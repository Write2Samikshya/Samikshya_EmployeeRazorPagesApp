using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRazorPagesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRazorPagesApp.Models;

namespace EmployeeRazorPagesApp.Pages.EmployeeDetails
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepo _employeeRepo;

        public IEnumerable<Employee> EmpProperty { get; set; }
        public IndexModel(IEmployeeRepo employeeRepo)
        {
          this._employeeRepo = employeeRepo;
        }
        public void OnGet()
        {
            EmpProperty = _employeeRepo.GetEmployees();
        }
    }
}
