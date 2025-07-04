using AutoMapper;
using Project.BusineesLogic.DataTranserObject.DepartmentDTOS;
using Project.BusineesLogic.DataTranserObject.EmployeeDTOS;
using Project.BusineesLogic.Services.interfaces;
using Project.DataAcessLayer.Data.Repositories.Interfaces;
using Project.DataAcessLayer.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.Services.Classes
{
    public class EmployeeServices (IUnitOfWork unitOfWork , IMapper _mapper) : IEmployeeServices
    {
       
        public int CreateEmployee(CreatedEmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<CreatedEmployeeDTO, Employee>(employeeDTO);

              return  unitOfWork.EmployeeRepo.Insert(employee);


        }

        public bool DeleteEmployee(int id)
        {
            var employee = unitOfWork.EmployeeRepo.GetById(id);
            if (employee is null) return false;
            else
            {
                employee.IsDeleted = true;
                return unitOfWork.EmployeeRepo.Delete(employee) > 0;
            }

        }

        public IEnumerable<EmployeeDTo> GetAllEmployees(bool WithTracking = false)
        {
            var Employees = unitOfWork.EmployeeRepo.GetAll(false);
            var EmployeeDTo = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTo>>(Employees);
            return EmployeeDTo;

        }

        public IEnumerable<EmployeeDTo> GetAllEmployees(string? Name)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(Name))
            {
                employees = unitOfWork.EmployeeRepo.GetAll();
            }
            else
            {
                employees = unitOfWork.EmployeeRepo.GetAll(e => e.Name.ToLower().Contains(Name.ToLower()));
            }

            var EmployeeDTo = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTo>>(employees);
            return EmployeeDTo;
        }

        public EmployeeDetailsDTO GetEmployeeById(int id)
        {
            var employee = unitOfWork.EmployeeRepo.GetById(id);
            return employee is not null ? _mapper.Map<Employee, EmployeeDetailsDTO>(employee) : null;

        }

        public int UpdateEmployee(UpdateEmployeeDto updateEmployee)
        {
            return unitOfWork.EmployeeRepo.Update(_mapper.Map<UpdateEmployeeDto, Employee>(updateEmployee));
        }
    }
}
