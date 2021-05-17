using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRazorPagesApp.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string  Photopath { get; set; }

        public Dept? Department { get; set; }
    }
}
