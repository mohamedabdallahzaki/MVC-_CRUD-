using Project.BusineesLogic.DataTranserObject.DepartmentDTOS;
using Project.BusineesLogic.Factroies;
using Project.BusineesLogic.Services.interfaces;
using Project.DataAcessLayer.Data.Repositories.Interfaces;
using Project.DataAcessLayer.Models.DepartmentModels;

namespace Project.BusineesLogic.Services.Classes
{
    public class DepartementServices(IDepartmentRepository _departmentRepository) : IDepartementServices
    {
        // get all departments
        public IEnumerable<DepartementDTO> GetAllDepartments()
        {
            var departements = _departmentRepository.GetAll();

            return departements.Select(d => d.ToDepartement());
        }

        // get department by id
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {

            var department = _departmentRepository.GetById(id);
            // mannual mapping from Department to DepartmentDetailsDto

            return department == null ? null : department.ToDepartementDto();
        }

        // Add
        public int CreateDepartment(CreatedDepartmentDto d)
        {

            return _departmentRepository.Insert(d.ToEntity());
        }

        // Update

        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            var department = _departmentRepository.Update(departmentDto.ToEntity());
            return department;

        }

        // Delete
        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return false;
            }
            var result = _departmentRepository.Delete(department);
            return result > 0 ? true : false;

        }
    }
}
