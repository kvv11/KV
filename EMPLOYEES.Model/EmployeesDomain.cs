using EMPLOYEES.DATA.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using EMPLOYEES.DATA;

namespace EMPLOYEES.Model
{
    public class EmployeesDomain
    {
        public  EmployeesDomain(EmployeesKveletic employee)
         {
        EmpNo = employee.EmpNo;
        BirthDate = employee.BirthDate;
        FirstName = employee.FirstName;
         LastName = employee.LastName;
         }

        public EmployeesDomain()
        {

        }
        public int EmpNo { get; set; }
    public DateTime? BirthDate { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}



}
