using AutoMapper;
using Project.BusineesLogic.DataTranserObject.EmployeeDTOS;
using Project.DataAcessLayer.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTo>()
                .ForMember(dest => dest.Gender, options  => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.Department , options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDTO>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(des => des.HirringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HirringDate)))
                .ForMember(dest => dest.DepartmentId, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.HirringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(des => des.HirringDate, optins => optins.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));
        }
      
    }
}
