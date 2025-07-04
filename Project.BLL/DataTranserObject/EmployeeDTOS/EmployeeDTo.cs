﻿using Project.DataAcessLayer.Models.EmployeeModels;
using Project.DataAcessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.DataTranserObject.EmployeeDTOS
{
    public class EmployeeDTo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? Age { get; set; }
        [DataType(DataType.Currency)]

        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; } 

        public string? Gender { get; set; }

        [Display(Name = "Employee Type")]
        public string? EmployeeType { get; set; }

        public string? Department { get; set; }

    }
}
