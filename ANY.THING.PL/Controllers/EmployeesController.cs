using Microsoft.AspNetCore.Mvc;
using Project.BusineesLogic.DataTranserObject.EmployeeDTOS;
using Project.BusineesLogic.Services.interfaces;
using Project.DataAcessLayer.Models.EmployeeModels;
using Project.DataAcessLayer.Models.Shared.Enums;
using Project.PresentionLayer.Views_Models.EmployeesModels;

namespace Project.PresentionLayer.Controllers
{
    public class EmployeesController(IEmployeeServices employeeServices, IWebHostEnvironment environment ,ILogger<EmployeesController> logger ) : Controller
    {
        [HttpGet]
        public IActionResult Index(string? Name)
        {
            var Employess = employeeServices.GetAllEmployees(Name);
            return View(Employess);
        }
        [HttpGet]

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]

        public IActionResult Create(CreatedEmployeeViewModel createdEmployee)
        {
          if(ModelState.IsValid)
            {
                try {
                    var employeeDTO = new CreatedEmployeeDTO
                    {
                        Name = createdEmployee.Name,
                        Age = createdEmployee.Age,
                        Address = createdEmployee.Address,
                        Salary = createdEmployee.Salary,
                        IsActive = createdEmployee.IsActive,
                        Email = createdEmployee.Email,
                        PhoneNumber = createdEmployee.PhoneNumber,
                        HiringDate = createdEmployee.HiringDate,
                        Gender =  createdEmployee.Gender,
                        EmployeeType = createdEmployee.EmployeeType,
                        DepartmentID = createdEmployee.DepartmentId


                    };
                    var res = employeeServices.CreateEmployee(employeeDTO);
                    if ( res > 0) return RedirectToAction("Index");
                    ModelState.AddModelError("", "Something went wrong, please try again later.");
                }
                catch (Exception ex)
                {
                    if(environment.IsDevelopment())
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                    else
                    {
                        ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                    }
                }
            }
            return View(createdEmployee);

        }

        [HttpGet]
        public IActionResult Details (int? id)
        {
            if(!id.HasValue ) return BadRequest();
            var employee = employeeServices.GetEmployeeById(id.Value);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = employeeServices.GetEmployeeById(id.Value);
            if (employee == null) return NotFound();
            var updateEmployee = new CreatedEmployeeViewModel
            {

                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HirringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee?.EmployeeType) ,
                DepartmentId = employee.DepartmentId

            };
            return View(updateEmployee);
        }
        [HttpPost]

        public IActionResult Edit( [FromRoute] int? id,CreatedEmployeeViewModel viewModel)
        {
            if (!id.HasValue ) return BadRequest();
            if(!ModelState.IsValid) return View(viewModel);

            try
            {
                var updateEmployee = new UpdateEmployeeDto
                {
                    Id = id.Value,
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    Address = viewModel.Address,
                    Salary = viewModel.Salary,
                    IsActive = viewModel.IsActive,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    HiringDate = viewModel.HiringDate,
                    Gender = viewModel.Gender,
                    EmployeeType = viewModel.EmployeeType,
                    DepartmentId = viewModel.DepartmentId
                    

                };
                    var res = employeeServices.UpdateEmployee(updateEmployee);
                if (res > 0) return RedirectToAction("Index");
                ModelState.AddModelError("", "Something went wrong, please try again later.");
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    logger.LogError(ex, "An error occurred while updating the employee with ID {Id}", id);
                    return View("Erro View", ex.Message);
                }
            }

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var employee = employeeServices.GetEmployeeById(id);
                if (employee == null) return NotFound();
                var res = employeeServices.DeleteEmployee(id);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong, please try again later.");
                    return View(nameof(Delete), new { id = id });
                }
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError("", ex.Message);
                }
                else
                {
                    logger.LogError(ex, "An error occurred while deleting the employee with ID {Id}", id);
                    return View("ErrorView", ex.Message);
                }
            }
            return View(nameof(Delete), new { id = id });

        }
    }
}
