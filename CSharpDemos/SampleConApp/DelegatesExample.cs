using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Delegates are like function pointers of C++. They are used to create references for the methods. A reference for a  method is required when U want to pass a method as arg to a function. The method will be invoked by the function as a callback operation after some condition is met.
//Delegates are used in Event handling, Multi Threading, Asynchronous methods  and using function pointers(CallBack).
//Action and Func are 2 generic delegates with 19 overloads to provide functions for void and non void functions respectively. It makes U use this delegate for any kind of function with any kind of args and return types.  
namespace SampleConApp
{
    delegate int Add(int arg);

    delegate void SimpleDelFunc(string arg);
    delegate double Function(double v1, double v2);
    class DelegatesExample
    {
        static void InvokeMathOperation(Function methodName)
        {

         
            Console.WriteLine("Enter v1");
            var v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter v2");
            var v2 = double.Parse(Console.ReadLine());
            var res = methodName(v1, v2);
            Console.WriteLine("The Result is " + res);

        }
        static void Main(string[] args)
        {

            Func<int, int> simFunc = (v1) => v1 + 123;
            Console.WriteLine(simFunc(123)); ;

            Func<double ,double, double> func = (f, s) => f * s;
            Console.WriteLine(func(123, 234)); ;

            Action<string> voidFun = (arg) => Console.WriteLine(arg.ToUpper());
            voidFun("Apple");            
            //singlecastDelegateExample();
            //multiCastExample();
//            multicastReturnExample();
        }

        private static void multicastReturnExample()
        {
            Add add = (arg) =>
            {
                Console.WriteLine("First Func");
                return arg + 123;
            };
            add += (arg) =>
            {
                Console.WriteLine("SEcond Func");
                return arg * arg;
            };
            add += (arg) => arg - 123;

            //Getting result of each method of MCD....
            foreach(var del in add.GetInvocationList())
            {
                var instance = del as Add;//unboxing....
                var res = instance(121);
                Console.WriteLine(res);
            }
        }

        private static void multiCastExample()
        {
            SimpleDelFunc func = (arg) => Console.WriteLine(arg);
            func += (arg) =>
            {
                Console.WriteLine(arg.ToUpper());
                
            };
            func += (arg) =>
            {
                for (int i = 0; i < arg.Length; i++)
                {
                    Console.WriteLine(arg[i]);
                }
            };
            func("Some Value");

            //Delegate object that points to multiple functions is called as Multicast Delegate. This is casted with += operator. 
        }

        private static void singlecastDelegateExample()
        {
            //Function func = new Function(AddFunc);
            //InvokeMathOperation(func);

            InvokeMathOperation(AddFunc);//New syntax for .NET 2.0 onwards..

            //Anonymous methods:
            Function func = delegate (double v1, double v2)
            {
                return v1 - v2;
            }; //A method with no name is associated with thed delegate object, This is called Anonymous Method....
            InvokeMathOperation(func);

            InvokeMathOperation((f, s) => f * s);
            //Single cast delegates: Delegate objects that point to single function is called Single Cast delegate. 
        }

        static double AddFunc(double v2, double v1) => v1 + (v2 - v1) * v2 / v1 + v2;
    }
}
