using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.myWinServices;
//Add the service reference of the WCF Component hosted in the Windows service...
namespace WcfClient
{
    class WinServiceClient
    {
        static void Main(string[] args)
        {
            insertRecord();
            updateRecord();
            readRecords();
        }

        private static void insertRecord()
        {
            var proxy = new DataComponentClient();
            proxy.AddNewEmployee(new Employee { EmpName = "Rajnath Singh", EmpAddress = "Mathura", EmpSalary = 55000 });//No need for EmpID as Its auto generated.
        }

        private static void updateRecord()
        {
            var proxy = new DataComponentClient();
            proxy.UpdateEmployee(new Employee {EmpID = 6, EmpName = "Ram Mohan Malaviya", EmpAddress = "Mathura", EmpSalary = 55000 });//ID is required as we update the record based on ID.
        }

        private static void readRecords()
        {
            var proxy = new DataComponentClient();
            var list = proxy.GetEmployees();
            foreach (var emp in list)
                Console.WriteLine(emp.EmpName);
        }
    }
}
