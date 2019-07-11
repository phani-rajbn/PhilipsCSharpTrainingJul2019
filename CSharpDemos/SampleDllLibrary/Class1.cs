using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDllLibrary
{
    public class SimpleClass
    {
        public void SimpleFunc() => Console.WriteLine("Simple Func from the DLL");

        public double AddFunc(double v1, double v2) => v1 + v2;
    }
}
