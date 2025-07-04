using Project.DAL.Data.Contexts;
using Project.DataAcessLayer.Data.Repositories.Interfaces;
using Project.DataAcessLayer.Models.DepartmentModels;

namespace Project.DataAcessLayer.Data.Repositories.Classes
{
    public class DepartmentRepository(AppDBContext dbContext) : GenriceRepo<Department> (dbContext) ,  IDepartmentRepository


    {

    }


    
}
