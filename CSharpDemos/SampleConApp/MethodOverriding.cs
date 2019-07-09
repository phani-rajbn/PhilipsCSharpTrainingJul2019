using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Its a feature where the derived class will modify the functionality without breaking the signature of the base method. The base class should mark those methods that could be modified as virtual and the derived class will override(reimplement) thro methods using override keyword, virtual is more like a permission to override and override is like a notification that it intends to modify
namespace SampleConApp
{
    class TestClass
    {
        public virtual void TestFunc() => Console.WriteLine("Test Func from base");

        public void NormalFunc() => Console.WriteLine("Normal Func");
    }

    class NewTestClass : TestClass
    {
        public override void TestFunc() => Console.WriteLine("Test Func from derived");
    }
    class MethodOverriding
    {
        static void Main(string[] args)
        {
            TestClass cls = new TestClass();
            cls.TestFunc();

            cls = new NewTestClass();
            cls.TestFunc();//Runtime Polymorphism achieved thro method overriding...
        }
    }
}
