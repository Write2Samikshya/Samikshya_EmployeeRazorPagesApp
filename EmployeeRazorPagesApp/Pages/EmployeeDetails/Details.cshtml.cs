using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeRazorPagesApp.Pages.EmployeeDetails
{
    public class DetailsModel : PageModel
    {
        public IActionResult OnGet(int ID)
        {
            return Page();
        }
    }
}
