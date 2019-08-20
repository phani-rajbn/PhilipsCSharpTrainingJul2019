using RemoteObjectLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
//Limitations: Remoting architecture is very old. Both Client and server should be .NET Technology based Applications. Other protocols are not supported and its not extendable. 
//Other technology based Applications cannot consume the .NET Remoting baed Server Apps...
namespace RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //IP  Address of UR server machine
            string address = "tcp://localhost:1234/MessengerServices";
            ChannelServices.RegisterChannel(new TcpClientChannel(), true);
            Messenger proxy = Activator.GetObject(typeof(Messenger), address) as Messenger;
            if(proxy == null)
            {
                Console.WriteLine("No Proxy found at this address");
                return;
            }
            Console.WriteLine("Enter the Username");
            string uname = Console.ReadLine();
            do
            {
                Console.WriteLine("Enter the message to Post");
                string msg = Console.ReadLine();
                proxy.PostMessage(msg, uname);
            } while (true);
        }
    }
}
