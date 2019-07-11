using System;
using System.Reflection;
/*Allow the methods of a DLL to be invoked without referencing it. This is done thro REFLECTION. Reflection is a capability of reading the metadata of the Assembly at runtime, access its classes, get its member details and finally invoke them. This is called as LATE BINDING. 
 * It allows to load the DLL at runtime thro CODE and access its members and its classes. UR IDE will not contain any info about the classes and its members while U code. 
 */
namespace SampleConApp
{
    class ReflectionExample
    {
        static Assembly dll;//Programmatic way of identify an Assembly:DLL or EXE
        static Type selectedType;//Programmatic way to represent a Class
        static MethodInfo method;//Method details....
        static string dllFile = @"C:\Users\phani\source\repos\PhilipsCSharpTraining\CSharpDemos\SampleDllLibrary\bin\Debug\SampleDllLibrary.dll";
        static void Main(string[] args)
        {
            loadDlL();
            loadSelectedClass();
            loadSelectedMethod();
            invokeMethod();
        }


        private static void invokeMethod()
        {
            object instance = Activator.CreateInstance(selectedType);
            if(method.GetParameters().Length == 0)
            {
                method.Invoke(instance, null);
            }
            else
            {
                var parameters = method.GetParameters();
                object[] pmValues = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.WriteLine("Enter the value for the paramater {0} whose data type is {1}", parameters[i].Name, parameters[i].ParameterType.Name);
                    pmValues[i] = Convert.ChangeType(Console.ReadLine(), parameters[i].ParameterType);
                }
                Console.WriteLine("All the parameters are set, so lets invoke...");
                object result = method.Invoke(instance, pmValues);
                Console.WriteLine("The result: " + result);
            }
        }

        private static void loadSelectedMethod()
        {
            if (selectedType == null)
                return;
            var allMethods = selectedType.GetMethods();
            foreach(var method in allMethods)
            {
                Console.WriteLine("Name:{0}\nReturn Type:{1}\nParameters:{2}", method.Name, method.ReturnType.FullName, method.GetParameters().Length);
            }
            Console.WriteLine("Enter the method that U want to invoke");
            method = selectedType.GetMethod(Console.ReadLine());
        }

        private static void loadSelectedClass()
        {
            Type[] allTypes = dll.GetTypes();
            foreach (var clsName in allTypes)
                Console.WriteLine(clsName.FullName);
            Console.WriteLine("Enter the fullname of the class to select");
            string name = Console.ReadLine();
            selectedType = dll.GetType(name);
            if (selectedType == null)
            {
                Console.WriteLine("Failed to load the Class details, exiting");
                return;
            }
        }

        private static void loadDlL()
        {
            dll = Assembly.LoadFile(dllFile);
            if (dll == null)
            {
                Console.WriteLine("Dll is not loaded");
                return;
            }
        }
    }
}
