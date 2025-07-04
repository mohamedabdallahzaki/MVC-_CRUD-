using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAcessLayer.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepo EmployeeRepo { get; }
        IDepartmentRepository DepartmentRepo { get; }

        int SaveChanges();

    }
}
