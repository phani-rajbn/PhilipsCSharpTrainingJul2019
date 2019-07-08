using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class EmployeeCollectionDemo
    {
        const int size = 5;
        static Employee[] employees = new Employee[size];
        static void AddEmployee(Employee emp)
        {
            for (int i = 0; i < size; i++)
            {
                if (string.IsNullOrEmpty(employees[i].EmpName))
                {
                    employees[i] = emp;
                    return;//Exit the function....
                }
            }

        }

        static void DeleteEmployee(int id)
        {
            for (int i = 0; i < size; i++)
            {
                if(employees[i].EmployeeID == id)
                {
                    employees[i].EmployeeID = 0;
                    employees[i].EmpName = string.Empty;
                    employees[i].EmpAddress = string.Empty;
                    return;
                }
            }
        }

        static void UpdateEmployee(Employee emp)
        {
            //Try it URself....
        }

        static void Main(string[] args)
        {
            AddEmployee(new Employee { EmployeeID = 1, EmpAddress = "Bangalore", EmpName = "Phaniraj" });
            AddEmployee(new Employee { EmployeeID = 2, EmpAddress = "Mysore", EmpName = "AnanthaRam" });
            AddEmployee(new Employee { EmployeeID = 3, EmpAddress = "Bangalore", EmpName = "Zaheer" });

            foreach(Employee emp in employees)
                Console.WriteLine(emp.EmpName);
        }
    }
}
