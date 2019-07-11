using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDllLibrary;//The namespace where the class is declared..

namespace SampleConApp
{
    class DllClient
    {
        static void Main(string[] args)
        {
            SimpleClass cls = new SimpleClass();
            cls.SimpleFunc();
            Console.WriteLine("Press any key to exit....");
            Console.ReadKey();
        }
    }
}
/*
 * Assemblies are of 2 types: Shared Assemblies and Private assemblies. 
 * Private assemblies are created by default. They create local copy of the DLL in the Exe Folder where it is being consumed. If the local copy is removed, UR EXE wont run. This implies every EXE which consumes the DLL will have a copy of the DLL in its executing directory.
 * Shared Assemblies or Shared DLLs are placed in centralized location of the machine called as GAC(Global Assembly Cache).
 * Shared Assemblies are provided with a encrypted key called SNK(Strong Name key). The Key file is assciated with the DLL in the project properties.
 * After the signing the assembly, U could build the project and use Developer Command Prompt For Visual Studio to run a tool called GACUTIL.EXE which installs the DLL into the global assembly cache, with this, it becomes a shared Assembly and all the Versioning and other features will be set on this DLL. 
 */
