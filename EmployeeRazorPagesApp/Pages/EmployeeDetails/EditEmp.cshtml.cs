using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmployeeRazorPagesApp.Models;
using EmployeeRazorPagesApp.Services;

namespace RazorEmployeeDetailsMyProj.Pages.Employees
{
    public class EditEmpModel : PageModel
    {
        private readonly IEmployeeRepo employeeRepositoryint;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EditEmpModel(IEmployeeRepo employeeRepositoryint, IWebHostEnvironment webHostEnvironment)
        {
            this.employeeRepositoryint = employeeRepositoryint;
            this.webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Employee Employee { get;  set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }


        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = employeeRepositoryint.GetEmployeebyID(id.Value);
            }
            else
            {
                Employee = new Employee();


            }

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (Employee.Photopath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "images", Employee.Photopath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object
                    Employee.Photopath = ProcessUploadedFile();
                }

                if (Employee.ID > 0)
                { 
                Employee = employeeRepositoryint.Update(Employee);
                }

                else
                {
                    Employee = employeeRepositoryint.Add(Employee);


                }
                return RedirectToPage("Index");

            }
            return Page();

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

        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            Employee = employeeRepositoryint.GetEmployeebyID(id);
        }

    }
}
