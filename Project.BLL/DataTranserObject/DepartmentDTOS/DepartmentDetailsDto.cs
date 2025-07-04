//using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.DataTranserObject.DepartmentDTOS
{
    public class DepartmentDetailsDto

    {
        public string Name { get; set; } = null!;
        
        public string Code { get; set; } = string.Empty;

        public string? Description { get; set; }
        public int Id { get; set; }

        public int CreatedBy { get; set; }
        public DateOnly? CreatedAt { get; set; }

        public int UpdatedBy { get; set; }
        public DateOnly? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }



    }
}
