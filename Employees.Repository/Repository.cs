using System;
using System.Collections.Generic;
using System.Text;
using Employees.Repository;
using EMPLOYEES.DATA.DataModel;
using EMPLOYEES.Repository.Common;
using System.Linq;
using EMPLOYEES.Model;
using System.Threading.Tasks;

namespace EMPLOYEES.Repository
{
    public class Repository : IRepository
    {
        private readonly EMPLOYEES_DbContext _appDbContext;
        private IRepositoryMappingService _mappingservice;

        public Repository(EMPLOYEES_DbContext appDbContext, IRepositoryMappingService mapper)
        {
            _appDbContext = appDbContext;
            _mappingservice = mapper;
        }

        public async Task<bool> AddEmployeeAsync(EmployeesDomain employee)
        {
            try
            {
                var employeeLB = new EmployeesKveletic
                {
                    BirthDate = employee.BirthDate,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                };


                await _appDbContext.EmployeesKveletic.AddAsync(employeeLB);


                await _appDbContext.SaveChangesAsync();


                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<EmployeesKveletic> GetAllEmployeesDb()
        {
            IEnumerable<EmployeesKveletic> employeesDb = _appDbContext.EmployeesKveletic.ToList();
            return employeesDb;
        }

        public IEnumerable<EmployeesDomain> GetAllEmployeesDomain()
        {
            var employeesDb = _appDbContext.EmployeesKveletic.ToList();
            var employeesDomain = employeesDb.Select(x => new EmployeesDomain(x));
            return employeesDomain;
        }

        public EmployeesDomain GetEmployeeDomainByEmployeeId(int employeeId)
        {
            var employeeDb = _appDbContext.EmployeesKveletic.FirstOrDefault(e => e.EmpNo == employeeId);

            if (employeeDb != null)
            {
                return new EmployeesDomain(employeeDb);
            }
            else
            {
                return null;
            }
        }
    }
}
