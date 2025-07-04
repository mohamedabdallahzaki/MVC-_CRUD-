using Project.BusineesLogic.DataTranserObject;
using Project.BusineesLogic.DataTranserObject.EmployeeDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusineesLogic.Services.interfaces
{
    public interface IEmployeeServices
    {
        IEnumerable<EmployeeDTo> GetAllEmployees(bool WithTracking = false);
        IEnumerable<EmployeeDTo> GetAllEmployees(string? Name);
        EmployeeDetailsDTO  GetEmployeeById(int id);

        int CreateEmployee(CreatedEmployeeDTO employeeDTO);

        int UpdateEmployee(UpdateEmployeeDto updateEmployee);

        bool DeleteEmployee(int id);
    }
}
