using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.myServices;
namespace WcfClient
{
    //Add the service Reference of the ServiceLib by clicking Discover and continue the steps.
    class Program
    {
        static void Main(string[] args)
        {
            //For the interface IExample, a proxy class called ExampleClient will be created..
            MathInterfaceClient proxy = new MathInterfaceClient();
            var result = proxy.AddFunc(123, 234);

            
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
