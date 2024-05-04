using EMPLOYEES.DATA.DataModel;
using EMPLOYEES.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEES.Repository.Common
{
    public interface IRepository
    {
        IEnumerable<EmployeesKveletic> GetAllEmployeesDb();
        IEnumerable<EmployeesDomain> GetAllEmployeesDomain();
        EmployeesDomain GetEmployeeDomainByEmployeeId(int employeeId);
        Task<bool> AddEmployeeAsync(EmployeesDomain employee);
    }
}
