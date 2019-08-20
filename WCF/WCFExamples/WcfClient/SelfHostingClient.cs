using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.hostServices;
//Add the existing project of WCFClient which was created on Wednesday, remove the Program.cs file and add a new Class file called SelfHostingClient.cs
//If the Service is not running, set the SelfHostingApp as startup and execute the program so that we could add service reference to it in our Client App. 
namespace WcfClient
{
    class SelfHostingClient
    {
        static void Main(string[] args)
        {
            try
            {
                var proxy = new CustomerServiceClient();
               
                //proxy.RegisterCustomer(new Customer { BillAmount = 560, BillDate = DateTime.Now.AddDays(-234), CustomerID = 111, CustomerName = "Phaniraj", CustomerPhone = 23434355 });
              

                var tcpProxy = new InternalCustomerServiceClient();
                tcpProxy.RegisterCustomer(new Customer { BillAmount = 650, BillDate = DateTime.Now.AddDays(-34), CustomerID = 112, CustomerName = "Tom Sawyer", CustomerPhone = 234244555 });

                var data = proxy.GetAllCustomers();
                foreach (var cst in data) Console.WriteLine($"{cst.CustomerName} with {cst.CustomerPhone} billed on {cst.BillDate.ToShortDateString()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       //Create a menu driven program that has 4 options: Add, Delete, Find and Update which will make calls the server and performs the CRUD operations. The Menu should be text file which is read from the Command line argument of the Main Program of the Client App..
    }
}
