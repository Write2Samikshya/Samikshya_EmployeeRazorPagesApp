using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRazorPagesApp.Models;
using EmployeeRazorPagesApp.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EmployeeRazorPagesApp.Pages
{
    public class Edit_2Model : PageModel
    {
        private readonly IEmployeeRepo iemployeeRepo;
        [BindProperty]
        public Employee empeditprop { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public Edit_2Model(IEmployeeRepo _IemployeeRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.iemployeeRepo = _IemployeeRepo;
           this.WebHostEnvironment = webHostEnvironment;
            
        }
        public IActionResult OnGet(int id)
        {

            empeditprop = iemployeeRepo.GetEmployeebyID(id);

            if(empeditprop==null)
            {
                return RedirectToPage("Index");
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
                    string filePath = Path.Combine(WebHostEnvironment.WebRootPath,
                        "images", employee.Photopath);
                    System.IO.File.Delete(filePath);
                }
                // Save the new photo in wwwroot/images folder and update
                // PhotoPath property of the employee object
                employee.Photopath = ProcessUploadedFile();
            }

            Employee Emp = iemployeeRepo.Update(employee);
            return RedirectToPage("Index");

        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
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
