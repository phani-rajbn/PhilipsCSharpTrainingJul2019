using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemoteObjectLib;


//.NET Remoting using 2 protocols for IPC. One is Tcp and other is HTTP. Every .NET Remoting app will have a channel of Communication(Protocol), an URL Address where the Service is accessible by the clients. These addresses and the channels are registered in the Windows OS and will be exposed to the clients. 
//U should add the reference of System.Runtime.Remoting and the class library that we created(RemoteObjectLib)...

namespace RemoteServerApp
{
    class RemoteServer
    {
        static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(1234);
            ChannelServices.RegisterChannel(channel, true);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Messenger), "MessengerServices", WellKnownObjectMode.Singleton);
            Console.WriteLine("Server is now ready to handle requests");
            Console.WriteLine("Press any key to Terminate");
            Console.ReadKey();
        }
    }
}
