using Microsoft.AspNetCore.Mvc;
using Project.BusineesLogic.DataTranserObject;
using Project.BusineesLogic.DataTranserObject.DepartmentDTOS;
using Project.BusineesLogic.Services.interfaces;

//using Project.DAL.Models;
using Project.PresentionLayer.Views_Models.DepartmentViewsModel;

namespace Project.PresentionLayer.Controllers
{
    public class DepartmentController(IDepartementServices _departement, ILogger<DepartmentController> 
       logger , IWebHostEnvironment environment ) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departement.GetAllDepartments(); 
            return View(departments);
        }
        //

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create (CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departement.CreateDepartment(departmentDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError("", "Failed to create department. Please try again.");
                

                }
                catch(Exception ex)
                {
                   if (environment.IsDevelopment())
                    {
         
                        ModelState.AddModelError ("",$"An error occurred: {ex.Message}");

                    }
                    else
                    {
                        logger.LogError(ex.Message);
                
                    }


                }
              
            }
            return View(departmentDto);
        }

        // details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departement.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departement.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            var d = new DepartmentUpdate
            {
                CreateAt = department.CreatedAt ?? DateOnly.FromDateTime(DateTime.Now),
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,

            };
            return View(d);
        }
        [HttpPost]

        public IActionResult Edit([FromRoute]int id,DepartmentUpdate department  )
        {
           
            if (!ModelState.IsValid) return View(department);

            try
            {
                var UpdateDepartment = new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = department.Code,
                    Name = department.Name,
                    Description = department.Description,
                    CreatedAt = department.CreateAt
                };

                int res =_departement.UpdateDepartment(UpdateDepartment);
                  if (res > 0) return RedirectToAction(nameof(Index));
                  else
                {
                    ModelState.AddModelError(string.Empty, "Not Update");
                    return View(department);
                }
            }
            catch(Exception ex)
            {
                if (environment.IsDevelopment())
                {

                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");

                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("Error View", ex);

                }

            }
            return View(department);

        }

        // delete

        //[HttpGet]

        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return BadRequest();
        //    }
        //    var department = _departement.GetDepartmentById(id.Value);
        //    if (department == null) return NotFound();
        //    return View(department);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _departement.DeleteDepartment(id);
                if (result) return RedirectToAction(nameof(Index));
                else ModelState.AddModelError("", "Failed to delete department. Please try again.");
            }
            catch (Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    ModelState.AddModelError("", $"An error occurred: {ex.Message}");

                }
                else
                {
                    logger.LogError(ex.Message);
                    return View("Error View", ex);
                }
            }
            return RedirectToAction(nameof(Index));
        }
        }
}
