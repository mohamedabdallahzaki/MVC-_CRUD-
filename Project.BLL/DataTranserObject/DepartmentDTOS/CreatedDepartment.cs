using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.DataTranserObject.DepartmentDTOS
{
    public class CreatedDepartmentDto
    {
        [Required]
        [Display(Name = "Department Name")]
        public string Name { get; set; } = null!;
        [Required]
        public string Code { get; set; } = null!;
        [MinLength(3),MaxLength(100)]
        public string? Description { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
