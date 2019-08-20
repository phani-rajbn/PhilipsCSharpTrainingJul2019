using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceClient.localhost;

//Limitations of Web Services: Only HTTP and SOAP are used to access the web services. Only data representable as XML could be used as data transfer. No Support for JSON in Web services. Tcp features are not available for Web services. 2 technologies for Internet and Intranet will be troublesome in the future Applications as well as maintainance. 
//Next Gen SOA will be developed using WCF(Windows Communication Foundation).

namespace WebServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MySampleService proxy = new MySampleService();
            var data = proxy.GetAllEmployees();
            foreach (var emp in data) Console.WriteLine(emp);
        }
    }
}
