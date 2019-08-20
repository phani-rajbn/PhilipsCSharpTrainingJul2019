using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLib;
using EmployeeService.Models;
using System.Data;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IDataComponent dataComponent = null;

        public EmployeeController(IDataComponent dp)
        {
            dataComponent = dp;
        }

        [HttpGet]
        public List<Employee> Employees()
        {
            DataTable table = dataComponent.GetAllRecords();
            List<Employee> data = new List<Employee>();
            foreach(DataRow row in table.Rows)
            {
                var emp = new Employee();
                emp.EmpID = Convert.ToInt32(row[0]);
                emp.EmpName = row[1].ToString();
                emp.EmpAddress = row[2].ToString();
                emp.EmpSalary = Convert.ToDouble(row[3]);
                data.Add(emp);
            }
            return data;
        }

        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            var table = dataComponent.GetAllRecords();
            foreach(DataRow row in table.Rows)
            {
                if(row[0].ToString() == id.ToString())
                {
                    var emp = new Employee();
                    emp.EmpID = Convert.ToInt32(row[0]);
                    emp.EmpName = row[1].ToString();
                    emp.EmpAddress = row[2].ToString();
                    emp.EmpSalary = Convert.ToDouble(row[3]);
                    return emp;
                }
            }
            throw new Exception("Employee not found");
        }

        [HttpPost]//Use this for adding new Records....
        public bool AddNewEmployee([FromBody]Employee emp)
        {
            string line = emp.ToString();
            dataComponent.InsertRecord(line);
            return true;
        }

        [HttpPut]
        public bool UpdateEmployee([FromBody]Employee emp)
        {
            string line = emp.ToString();
            dataComponent.UpdateRecord(line);
            return true;
        }
    }
}