using System;
using System.Reflection;
using System.Configuration;

namespace ReflectionClient
{
    class Program
    {
        static Assembly dll;
        static Type className;
        static MethodInfo method;
        static object instance;
        static object[] parameters;

        static void Main(string[] args)
        {
            InvokeFunction();
        }

        static void InvokeFunction()
        {
            loadTheDll();
            loadClassDetails();
            loadMethodDetails();
            loadParameters();
            invokeMethod();
        }

        private static void invokeMethod()
        {
            //create the object of the class
            instance = Activator.CreateInstance(className);
            //Call the method thro that object
            if(instance == null)
            {
                Console.WriteLine("Create Instance failed");
                return;
            }
           object result =  method.Invoke(instance, parameters);
           Console.WriteLine("The result: " + result);
        }

        private static void loadParameters()
        {
            var allParameters = method.GetParameters();
            if (allParameters.Length == 0)
                return;
            parameters = new object[allParameters.Length];
            int index = 0;
            foreach (var pm in allParameters)
            {
                Console.WriteLine("Enter the value for the parameter {0} of the type {1}", pm.Name, pm.ParameterType.Name);
                parameters[index] = Convert.ChangeType(Console.ReadLine(), pm.ParameterType);
                index++;
            }
            Console.WriteLine("All the parameters are set, lets Invoke the method...");
        }

        private static void loadMethodDetails()
        {
            if (className == null)
            {
                Console.WriteLine("No Class found to load from the Dll");
                return;
            }
            var methods = className.GetMethods();
            foreach (var m in methods)
            {
                Console.WriteLine("The Name" + m.Name);
                Console.WriteLine("The Return type: " + m.ReturnType.Name);
                Console.WriteLine("The no of parameters:" + m.GetParameters().Length);
                Console.WriteLine("Details of Each Parameter:");
                foreach(var pm in m.GetParameters())
                    Console.WriteLine("{0}:{1}", pm.Name, pm.ParameterType.Name);
            }
            Console.WriteLine("Select one from the list above");
            method = className.GetMethod(Console.ReadLine());
            if(method == null)
            {
                Console.WriteLine("Not a valid method to invoke");
                return;
            }
        }

        private static void loadClassDetails()
        {
            if (dll == null)
                return;
            var types = dll.GetTypes();
            foreach(var type in types)
                Console.WriteLine(type.FullName);
            Console.WriteLine("select one from the list");
            className = dll.GetType(Console.ReadLine(), true, true);
            if (className == null)
            {
                Console.WriteLine("No Class found to load from the Dll");
                return;
            }
        }

        private static void loadTheDll()
        {
            var filename = ConfigurationManager.AppSettings["filename"];
            dll = Assembly.LoadFile(filename);
            if(dll == null)
            {
                Console.WriteLine("No DLL found to load");
                return;
            }
        }
    }
}
