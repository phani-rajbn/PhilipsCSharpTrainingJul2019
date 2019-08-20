using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//When a class is derived from MarshalByRefObject its objects can be accessed remotely thro RPC(Remote Procedure Calls). It creates a Proxy object inside the client App and the Client will consume our service thro the proxy.  
namespace RemoteObjectLib
{
    public class Messenger : MarshalByRefObject
    {
        public Messenger()
        {
            Console.WriteLine("Messenger Service is created");
        }

        public void PostMessage(string message, string user)
        {
            Console.WriteLine($"{user}:{message}");
        }
    }
}
