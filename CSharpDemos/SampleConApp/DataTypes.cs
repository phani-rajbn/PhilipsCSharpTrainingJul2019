using System;

//All data types in C# are based on the .NET's CTS. 
//CTS contains the wrapper classes and Structures for all the datatypes refered as keywords in C#. 
//int is a keyword which represents Int32 Struct of CTS. 
/*
 * Value types:
 * Integral Types: byte(Byte), short(Int16), int(Int32) , long(Int64)
 * Floating Types: float(Single), double(Double), decimal(Decimal)
 * Other Types: char(Char), bool(Boolean)
 * User Defined types: enum, structs. 
 * Conversions can be done using a static class called Convert. 
 * If the conversion fails, it throws FormatException.
 * Every Value type has a function called Parse that converts string to its type. 
 * Larger range datatypes can implicitly store shorter range type values. 
 * Shorter range data types need to be typecasted or use Convert Functions to store larger range values.
 * The conversions are implicit as long as the compiler feels that there is no loss of data while the conversion is happening..
 * However U could perform typecasting for forcefull conversions where there is a possibility of loss in the data: decimal value to store in an int would loose values after the decimal point. 
 * 
 * System.Object is the base type for all datatypes in .NET(C#). The keyword is object. object behaves like void* of C++. object is a reference type. 
 * Every other datatype value can be implicitly converted to object(BOXING).
 * The object must be explicitly converted back to the other type(UNBOXING).
 * UpCasting is implicit and Downcasting is explicit. 
 */
namespace SampleConApp
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            //dataConversionExample();
            //castingExample();
            unBoxingExample();
        }

        private static void unBoxingExample()
        {
            object value = 123;
            long constValue = (int)value;//UNBOXING must store back to the same type from which it was boxed....
            constValue += 123;
            value = constValue;
            Console.WriteLine(value.GetType().Name);
            value = "Sample 123";
            Console.WriteLine(value.GetType().Name);
            value = 123.234;
            Console.WriteLine(value.GetType().Name);
        }

        private static void castingExample()
        {
            long value = 123;
            //int smallValue = (int)value;
            int smallValue = Convert.ToInt32(value);
        }

        private static void dataConversionExample()
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();//String is a reference type....

            Console.WriteLine("Enter the date of Birth as dd/MM/yyyy");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            TimeSpan span = DateTime.Now - dob;//Duration is a struct called TimeSpan.
            Console.WriteLine("The Age is " + span.Days / 365.25);

            Console.WriteLine("Enter the Salary");
            int salary = int.Parse(Console.ReadLine());
            //Todo: display the output of the values on the screen ...
        }
    }
}
