//All WCF related classes and Attributes are available in the following namespaces.
using System;//Default namespace...
using System.ServiceModel;//for WCF services
using System.Runtime.Serialization;//For IPC

namespace SampleWcfLib
{
    [ServiceContract]
    public interface IMathInterface
    {
        [OperationContract]
        double AddFunc(double first, double second);
        [OperationContract]
        double SubFunc(double first, double second);
    }

    public class MyMathComponent : IMathInterface
    {
        public double AddFunc(double first, double second)
        {
            return first + second;
        }

        public double SubFunc(double first, double second)
        {
            return first - second;
        }
    }
}
