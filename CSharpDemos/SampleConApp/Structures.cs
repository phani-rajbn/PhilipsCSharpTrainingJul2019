using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    struct Employee
    {
        private int id;
        private string name;
        private string address;

        
        public int EmployeeID
        {
            get { return id; }
            set { id = value; }
        }
        public string EmpName
        {
            get { return name; }
            set { name = value; }
        }

        public string EmpAddress
        {
            get//getAddress()
            {
                return address;
            }
            set//setAddress(string address)
            {
                address = value;
            }
        }

    }
        
    class Structures
    {
        static void Main(string[] args)
        {
            //Structs are value types. Used to create User defined types with limited reusability options like no method overriding, no OOP features in it..
            Employee emp = new Employee();
            emp.EmployeeID = 213;
            emp.EmpName = "Phaniraj";
            emp.EmpAddress = "Bangalore";
            Employee copy = emp;//new copy....
            copy.EmpName = "TestName";
            Console.WriteLine("The Name is {0} from {1}", emp.EmpName, emp.EmpAddress);
            Console.WriteLine("The Name is {0} from {1}", copy.EmpName, copy.EmpAddress);
        }
    }
}
