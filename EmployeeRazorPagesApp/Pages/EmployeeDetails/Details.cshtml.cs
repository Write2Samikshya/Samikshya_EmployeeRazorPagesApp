using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRazorPagesApp.Models;
using EmployeeRazorPagesApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeRazorPagesApp.Pages.EmployeeDetails
{
    public class DetailsModel : PageModel
    {

        private readonly IEmployeeRepo _Emprepo;

        public Employee EmpPropertydeatils { get; set; }

        public DetailsModel(IEmployeeRepo employeeRepo)
        {
            this._Emprepo = employeeRepo;
        }
        public IActionResult OnGet(int ID)
        {
            EmpPropertydeatils = _Emprepo.GetEmployeebyID(ID);

            if(EmpPropertydeatils  == null)
            {
                return  RedirectToPage ("/Notound");

            }
            return Page();
        }
    }
}
