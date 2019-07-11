using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
//Atributes are optionsl properties that are injected into the application only when its added. The properties will be evaluated at runtime using Reflection APIs. 
//There are builtin Attributes as well as Custom Attributes. Attributes are set using [] block. They are set above the declaration of the code: Class, interface, method, Main Function, events and so forth.
//Attribute concept is extended in other languages like Java as Anotations and Angular Apps use it as Directives. 
namespace SampleConApp
{
    [Serializable]//Serializable attribute is a builtin Attribute to allow objects of this class serializable. Serialization is abolity of persisting the data to a disc and retriving it as it is from the source. This is used for Interprocess communication.

    //Custom Attributes are classes derived from System. Attribute...
    [AttributeUsage(AttributeTargets.Method)]
    class InfoAttribute : Attribute
    {
        private string detail;
        public InfoAttribute(string detail)
        {
            this.detail = detail;
        }
        public string Detail => detail; 
    }
    
    class AttributesExample
    {

        static void displayOurAttribute(object unit)
        {
            if(unit is MethodInfo)
            {
                var method = unit as MethodInfo;
                var attribute = method.GetCustomAttribute(typeof(InfoAttribute));
                if(attribute != null)
                {
                    var temp = attribute as InfoAttribute;
                    Console.WriteLine(temp.Detail);
                }
            }
        }
        [STAThread]//An attribute used on the Entry point of the Application for making it a Single threaded Apartment usage which is a requirement for COM Components(Windows UI elements).
        static void Main(string[] args)
        {
            var obj = new AttributesExample();
            MethodInfo selectedMethod = obj.GetType().GetMethod("NewtestFunc");
            if(selectedMethod != null)
            {
                displayOurAttribute(selectedMethod);
            }
        }
        [Obsolete("Try the new NewtestFunc")]
        static void Testfunc()
        {
            Console.WriteLine("Test func");
        }

        [Info("Some info about this class")]//This is ur Custom Attribute..
        public void NewtestFunc()
        {
            Testfunc();
            Console.WriteLine("Some new features");
        }
    }

    
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.IsTrue(true);
        }
    }
}
