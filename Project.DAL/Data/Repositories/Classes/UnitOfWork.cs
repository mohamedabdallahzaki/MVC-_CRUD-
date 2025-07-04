using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAcessLayer.Data.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepo _employeeRepo;

        public UnitOfWork(IDepartmentRepository departmentRepository , IEmployeeRepo employeeRepo, AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _departmentRepository = departmentRepository;
            _employeeRepo = employeeRepo;

        }
        public IEmployeeRepo EmployeeRepo => _employeeRepo;
        public IDepartmentRepository DepartmentRepo => _departmentRepository;

        public int SaveChanges()
        {
           return _dbContext.SaveChanges();
        }
    }
}
