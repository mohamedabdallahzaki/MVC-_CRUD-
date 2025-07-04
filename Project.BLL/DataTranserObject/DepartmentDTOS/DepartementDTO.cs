using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.DataTranserObject.DepartmentDTOS
{
    public class DepartementDTO
    {
        public int DeptId { get; set; }
      
       
        public string? Name { get; set; }
       
     
        public string Code { get; set; } = string.Empty;
        

        public string Description { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
     
        
    }
}
