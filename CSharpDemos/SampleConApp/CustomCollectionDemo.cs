using SampleDllLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
   
    class CustomCollectionDemo
    {
        static void Main(string[] args)
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.AddNewEmployee(new Employee { EmpID = 111, EmpName = "Phaniraj", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 112, EmpName = "SUresh", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 113, EmpName = "Gopal", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 114, EmpName = "Venu", EmailAddress = "phanirajbn@gmail.com" });
            coll.AddNewEmployee(new Employee { EmpID = 115, EmpName = "Sriirsh", EmailAddress = "phanirajbn@gmail.com" });
            Console.WriteLine("The No of Employees:" + coll.Count);
            //coll.DeleteEmployee(111);
            Console.WriteLine("The No of Employees:" + coll.Count);

            //Using foreach loop to iterate which internally uses IEnumerator....
            // foreach(var emp in coll)
            //   Console.WriteLine(emp.EmpName);

            //using IEnumerator object to read the data using Iterator....
            //var iterator = coll.GetEnumerator();
            //while(iterator.MoveNext())
            //    Console.WriteLine(iterator.Current.EmpName);

            //Using indexer to read the data thro For loop.....
            for (int i = 0; i < coll.Count; i++)
            {
                Console.WriteLine(coll[i].EmpName); 
            }
            
            Console.WriteLine("The EmailID of Mr.{0} is {1}", coll["Phaniraj"].EmpName, coll["Phaniraj"].EmailAddress);
        }
    }
}
