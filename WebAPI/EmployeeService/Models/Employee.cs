using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", EmpID, EmpName, EmpAddress, EmpSalary);
        }
    }
}
