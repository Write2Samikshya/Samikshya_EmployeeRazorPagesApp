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
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepo iemployeerepo;

        public EditModel(IEmployeeRepo iemployeerepo)
        {
            this.iemployeerepo = iemployeerepo;
        }

        public Employee EmployeeEditProperty { get; set; }
        public IActionResult OnGet(int id)
        {

            EmployeeEditProperty = iemployeerepo.GetEmployeebyID(id);

            if (EmployeeEditProperty== null)
            {

                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
