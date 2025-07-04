using Project.DataAcessLayer.Models.EmployeeModels;
using Project.DataAcessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.DataTranserObject.EmployeeDTOS
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }

        public string? Address { get; set; }
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public DateOnly HirringDate { get; set; }

        public string? Gender { get; set; }

        public string?  EmployeeType { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? DepartmentId { get; set; }
    }
}
