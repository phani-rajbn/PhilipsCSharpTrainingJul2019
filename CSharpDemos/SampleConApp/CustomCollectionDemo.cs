using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    partial class EmployeeCollection : IEnumerable<Employee>
    {
        public int Count => _employees.Count;

        public IEnumerator<Employee> GetEnumerator() => _employees.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _employees.GetEnumerator();
    }
    class CustomCollectionDemo
    {
        static void Main(string[] args)
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.AddNewEmployee(new Employee { EmpID = 111, EmpName = "Phaniraj", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 112, EmpName = "Phaniraj", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 113, EmpName = "Phaniraj", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 114, EmpName = "Phaniraj", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 115, EmpName = "Phaniraj", EmailAddress = "phanirajbn@gmail.com" });
            Console.WriteLine("The No of Employees:" + coll.Count);
            coll.DeleteEmployee(111);
            Console.WriteLine("The No of Employees:" + coll.Count);

            // foreach(var emp in coll)
            //   Console.WriteLine(emp.EmpName);

            var iterator = coll.GetEnumerator();
            while(iterator.MoveNext())
                Console.WriteLine(iterator.Current.EmpName);
        }
    }
}
