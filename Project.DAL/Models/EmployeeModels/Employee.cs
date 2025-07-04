using Project.DataAcessLayer.Models.DepartmentModels;
using Project.DataAcessLayer.Models.Shared;
using Project.DataAcessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAcessLayer.Models.EmployeeModels
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public string? Address { get; set; } 
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } 

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public DateTime HirringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; } = null!;


    }
}
