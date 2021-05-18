using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRazorPagesApp.Services;
using EmployeeRazorPagesApp.Models;

namespace EmployeeRazorPagesApp.Pages.EmployeeDetails
{
    public class Edit2Model : PageModel
    {
        private readonly IEmployeeRepo employeeRepo;

        [BindProperty]
        public Employee EmpPropertyEdit2 { get; set; }

        public Edit2Model(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        public IActionResult OnGet(int id)
        {
            EmpPropertyEdit2 = employeeRepo.GetEmployeebyID(id);

            if(EmpPropertyEdit2 == null)
            {
                return  RedirectToPage("/NotFound");
            }

            return Page();

        }

        public IActionResult OnPost(Employee employee)
        {
            EmpPropertyEdit2 = employeeRepo.Update(employee);
            return RedirectToPage("Index");

        }


    }
}
