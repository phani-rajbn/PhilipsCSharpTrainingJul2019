using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class BaseClass
    {
        public void BaseFunc() => Console.WriteLine("Base Func implemented");
    }
    //: is used to extend a Class into another. Inheritance is used for reusability. In this case, a Class with X number of methods could be extended to another class which will add Y no of methods, where the new class will have (X+Y) methods in it. U dont have to delegate or implement the old methods. 
    class DerivedClass :  BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func Implemented");
    }
    class InheritanceDemo
    {
        static void Main(string[] args)
        {
            //DerivedClass cls = new DerivedClass();
            //cls.BaseFunc();//base class func
            //cls.DerivedFunc();//derived class func...

            BaseClass baseCls = new BaseClass();
            baseCls.BaseFunc();

            //baseCls = new DerivedClass();//Luskov's substitution principle, makes sense in Overriding...
            //Upcasting....
            //Even if the object is instantiated to the derived class, U cannot access the members of the derived. To do so, U should typecast it to the derived and then access its methods...

            //((DerivedClass)baseCls).DerivedFunc();
            if (baseCls is DerivedClass)//More safe.....
            {
                DerivedClass variable = baseCls as DerivedClass;//is and as operators work only on reference types. as it is a safe way of Unboxing or type conversions for reference types..
                variable.DerivedFunc();
            }
        }
    }
    /*Points to remember:
     * C# supports Single Inheritance. It means that the derived class can have only one base class at any level. However U could extend to multiple layers, so that it supports Multi-Layered Inheritance. 
     * There is no access specifier while inheriting into another class. All the members of the base class will retain the accessibility in the derived classes:
     * private methods are inaccessible to the derived classes.
     * protected, internal and public methods retain their accessibility in the derived classes
     * internal means accessibility within the Project(Assembly).
     * For the constructors, the base class constructor will be called before the derived class constructor. 
     */
}
