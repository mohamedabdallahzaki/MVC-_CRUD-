using Project.BusineesLogic.DataTranserObject.DepartmentDTOS;
using Project.DataAcessLayer.Models.DepartmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.Factroies
{
    static class DepartmentFacetory
    {
        public static DepartementDTO ToDepartement ( this Department d)
        {
            return new DepartementDTO
            {
                DeptId = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description ?? string.Empty,
                DateOfCreation = d.CreatedAt != null ? DateOnly.FromDateTime((DateTime)d.CreatedAt) : DateOnly.MinValue
            };
        }

        public static DepartmentDetailsDto ToDepartementDto(this Department department)
        {
            return new DepartmentDetailsDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedAt = department.CreatedAt != null ? DateOnly.FromDateTime((DateTime)department.CreatedAt) : null,
                UpdatedBy = department.UpdatedBy,
                UpdatedAt =  department.UpdatedAt != null ? DateOnly.FromDateTime((DateTime)department.UpdatedAt) : null,
                IsDeleted = department.IsDeleted
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto createdDepartmentDto)
        {
            return new Department
            {
                Name = createdDepartmentDto.Name,
                Code = createdDepartmentDto.Code,
                Description = createdDepartmentDto.Description ?? string.Empty,
                CreatedAt = createdDepartmentDto.CreatedAt.ToDateTime(new TimeOnly())

            };
        }

        public static Department ToEntity (this UpdateDepartmentDto departmentDto)
        {
            return new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description ?? string.Empty,
                CreatedAt = departmentDto.CreatedAt.ToDateTime(new TimeOnly())
            };
        }

    }
}
