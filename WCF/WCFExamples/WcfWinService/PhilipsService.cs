using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfWinService
{
    //All Windows Sevices are classes derived from System.Serviceprocess.ServiceBase. 
    //It will have events like OnStart and OnStop to define what kind of activity UR service would provide to its clients and what needs to be done while the service is closed(Terminated). 
    public partial class PhilipsService : ServiceBase
    {
        ServiceHost host = null;
        public PhilipsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:1234/MyWindowsServices/");
            host = new ServiceHost(typeof(DatabaseService), baseAddress);

            WSHttpBinding binding = new WSHttpBinding();
            Type contract = typeof(IDataComponent);
            host.AddServiceEndpoint(contract, binding, "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            
            host.Description.Behaviors.Add(smb);
            host.Open();

            //This is the syntax of creating a binding configuration using C# code and not using Config file...
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
