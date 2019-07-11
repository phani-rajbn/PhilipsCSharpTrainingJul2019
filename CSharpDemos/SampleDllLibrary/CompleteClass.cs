using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDllLibrary
{
    public class Employee
    {
        public int EmpID { get; set; }
    public string EmpName { get; set; }
    public string EmailAddress { get; set; }

    public override int GetHashCode()
    {
        return EmpName.GetHashCode();//Gets the ID which determines whether 2 objects are of the same kind.
    }

    public override bool Equals(object obj)
    {
        //what makes 2 objects same...
        if (obj is Employee)
        {
            var temp = obj as Employee;
            return temp.EmpName == this.EmpName;
        }
        return false;
    }
}

    public class EmployeeCollection : IEnumerable<Employee>
    {
        private List<Employee> _employees = new List<Employee>();

        public void AddNewEmployee(Employee emp) => _employees.Add(emp);

        public void DeleteEmployee(int id)
        {
            var find = _employees.Find((emp) => emp.EmpID == id);
            //Employee find = null;
            //foreach(var emp  in _employees)
            //{
            //    if(emp.EmpID == id)
            //    {
            //        find = emp;
            //        break;
            //    }
            //}
            if (find == null) throw new Exception("Employee not found to delete");
            _employees.Remove(find);
        }

        public int Count => _employees.Count;

        public IEnumerator<Employee> GetEnumerator() => _employees.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _employees.GetEnumerator();
        //Indexer is a property on the object to allow access its members or data thro a [] operator and using it like an array. 
        public Employee this[int index] => _employees[index];

        public Employee this[string name] => _employees.Find(e => e.EmpName == name);
    }
}
