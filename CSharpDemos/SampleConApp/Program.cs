using System;
//namespace is a group created to avoid naming conflicts. Projectname is the default namespace.
//No concept of global members in C#, everything is either inside a class, interface, struct.
//Main is case sensitive. It need not be public.
//WriteLine : Writes a stream of text on the COnsole output Window
namespace SampleConApp
{
    class TestExample
    {
        static void Main(string[] args)
        {
            //firstExample();//use camelcasing for private methods.....
            //inputOutputExample();
        }

        private static void inputOutputExample()
        {
            //Console is the only class available in C# for both input and output on the Console.
            Console.WriteLine("Enter the Name");
            String name = Console.ReadLine();//ReadLine reads the stream of text entered by the user and returns string representation of it. 

            Console.WriteLine("Enter the Salary");
            String sal = Console.ReadLine();//Always returning string....

            Console.WriteLine("Enter the Address");
            String address = Console.ReadLine();

            Console.WriteLine("Enter UR Date of birth");
            string dob = Console.ReadLine();

            string output = string.Format("The name is {0} and Mr.{0} is from {1} with a salary of {2}", name, address, sal);
            Console.WriteLine(output);
        }

        private static void firstExample()
        {
            Console.WriteLine("Test 123");
            Console.WriteLine("This is second line");
            Console.WriteLine("The Age is " + 43);
        }
    }
}
