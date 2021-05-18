using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRazorPagesApp.Models;
using EmployeeRazorPagesApp.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmployeeRazorPagesApp.Pages.EmployeeDetails
{
    public class EditTryModel : PageModel
    {
        private readonly IEmployeeRepo iemployeeRepo;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public Employee EmpEditProperty { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public EditTryModel(IEmployeeRepo iemployeeRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.iemployeeRepo = iemployeeRepo;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int ID)
        {
            EmpEditProperty = iemployeeRepo.GetEmployeebyID(ID);

            if(EmpEditProperty==null)
            {
                return RedirectToPage("/NotFound");

            }

            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {
            if (Photo != null)
            {
                // If a new photo is uploaded, the existing photo must be
                // deleted. So check if there is an existing photo and delete
                if (employee.Photopath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                        "images", employee.Photopath);
                    System.IO.File.Delete(filePath);
                }
                // Save the new photo in wwwroot/images folder and update
                // PhotoPath property of the employee object
                employee.Photopath = ProcessUploadedFile();
            }

            Employee Emp=  iemployeeRepo.Update(employee);
            return RedirectToPage("Index");

        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
