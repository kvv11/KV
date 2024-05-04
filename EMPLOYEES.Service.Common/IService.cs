using EMPLOYEES.DATA.DataModel;
using EMPLOYEES.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEES.Service.Common
{
    public interface IService
    {
        IEnumerable<EmployeesKveletic> GetAllEmployeesDb();
        IEnumerable<EmployeesDomain> GetAllEmployeesDomain();
        EmployeesDomain GetEmployeeDomainByEmployeeId(int employeeId);
        Task<bool> AddEmployeeAsync(EmployeesDomain employee);
    }
}
