using Project.BusineesLogic.DataTranserObject.DepartmentDTOS;

namespace Project.BusineesLogic.Services.interfaces
{
    public interface IDepartementServices
    {
        int CreateDepartment(CreatedDepartmentDto d);
        bool DeleteDepartment(int id);
        IEnumerable<DepartementDTO> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}