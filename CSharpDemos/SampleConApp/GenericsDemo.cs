using SampleDllLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
//Generics are improvised version on Collections to make it type safe. Generics came in .NET 2.0.  Similar to templates of C++ which could be extended as well as used with ready to use classes for developing Collection based Applications. 
//Important collections: List<T>, HashSet<T>, Dictionary<K,V>, Queue<T>, Stack<T>, LinkedList<T>
//IEnumerable<T>, ICollection<T>, IList<T>, ISet<T>, IDictionary<K,V>, IComparable<T>, IComparer<T>
//If U implement these interfaces in ur classes, then UR classes can also be used like Collection Classes. 
//A Collection class is one whose object can be used in a foreach statement. Internally, it must implement IEnumerable<T> interface which has a method that returns IEnumerator<T> object which contain properties and methods to iterate the collection.
//Templates are classes that can be applied on any type. Generics provide a type safe version that can be implemented in .NET in more optimized manner where the type check happens at compile time in .NET.
namespace SampleConApp
{
    
    class GenericsDemo
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        //demo in Dictionary to add item..
        static void signUp(string uname, string pwd)
        {
            if (users.ContainsKey(uname))
                Console.WriteLine("User already exists");
            else
                users[uname] = pwd;//Adds an key-value pair to the dictionary....
            //users.Add(key, value) checks for the key, if found throws an Exception....
        }
        //dictionary example to read data
        static bool signIn(string uname, string pwd)
        {
            if (users.ContainsKey(uname))
            {
                if(users[uname] != pwd)
                    throw new Exception("Invalid password");
                return true;
            }
            throw new Exception("User name is incorrect");
        }
        static void Main(string[] args)
        {
            //listExample();
            //hashSetExample();
            //dictionaryExample();
            //QueueExample();
            //StackExample();
            //linkedListExample();
        }

        private static void linkedListExample()
        {
            LinkedList<string> addresses = new LinkedList<string>();
            addresses.AddLast("RR nagar");
            addresses.AddLast("Vijaynagar");
            addresses.AddLast("Sumanhalli");
            addresses.AddLast("Nandini Layout");
            var previous = addresses.Find("Sumanhalli");
            addresses.AddBefore(previous, "Magadi Road");

            foreach(var path in addresses)
                Console.WriteLine(path);

        }

        private static void StackExample()
        {
            Stack<string> pages = new Stack<string>();
            do
            {
                Console.WriteLine("Page to View?");
                pages.Push(Console.ReadLine());
                Console.WriteLine("Press B to move Back");
                string answer = Console.ReadLine().ToUpper();
                if (answer == "B")
                    pages.Pop();//removes the top item from the stack...
                foreach(var page in pages)
                    Console.WriteLine(page);
            } while (true);
        }

        private static void QueueExample()
        {
            Queue<string> recentItems = new Queue<string>();
            do
            {
                Console.WriteLine("Enter the Item to view");
                if (recentItems.Count == 5)
                    recentItems.Dequeue();//Removes the first item in the queue from the list. 
                recentItems.Enqueue(Console.ReadLine());//Adds the item to the bottom of the queue...
                //UR Recently Viewed Items:
                var recent = recentItems.Reverse();//System.Linq Extension method to reverse the items in the Queue without altering it.
                foreach(var item in recent)
                    Console.WriteLine(item);
            } while (true);
        }

        private static void dictionaryExample()
        {
            //stores the data in the form of key-value pairs where key is unique for the collection. Similar to the literal word dictionary where word is unique in a dictionary and meaning for it may be similar with others. UsersTable where username is unique but passwords might be same. 
            do
            {
                Console.WriteLine("Press N for SignUp and L for login");
                string choice = Console.ReadLine().ToUpper();
                if (choice == "N")
                {
                    Console.WriteLine("Enter the username");
                    string uname = Console.ReadLine();
                    Console.WriteLine("Enter the password");
                    string pwd = Console.ReadLine();
                    signUp(uname, pwd);
                }
                else
                {
                    Console.WriteLine("Enter the username");
                    string uname = Console.ReadLine();
                    Console.WriteLine("Enter the password");
                    string pwd = Console.ReadLine();
                    try
                    {
                        if (signIn(uname, pwd)) Console.WriteLine("Welcome to the user");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            } while (true);
        }

        private static void hashSetExample()
        {
            //simpleHashset();
            customizedHashset();
        }

        private static void customizedHashset()
        {
            //Every object is identified by a number called HashCode. object has a method called GetHashCode to get the HashCode ID of the object. WHen adding happens, the hashset checks for the hashcode of the object before it addes. 
            HashSet<Employee> _employees = new HashSet<Employee>();
            _employees.Add(new Employee { EmpID = 1, EmailAddress = "phanirajbn@gmail.com", EmpName = "Phaniraj" });
            _employees.Add(new Employee { EmpID = 1, EmailAddress = "phanirajbn@gmail.com", EmpName = "Sumanth" });
            _employees.Add(new Employee { EmpID = 1, EmailAddress = "phanirajbn@gmail.com", EmpName = "Phaniraj" });
            _employees.Add(new Employee { EmpID = 1, EmailAddress = "phanirajbn@gmail.com", EmpName = "Phaniraj" });

            foreach (var emp in _employees) Console.WriteLine(emp.GetHashCode());
//            Console.WriteLine("The no of Employees are " + _employees.Count);
        }

        private static void simpleHashset()
        {
            HashSet<string> cart = new HashSet<string>();
            cart.Add("Apples");//Add works like List but returns a bool to tell its success...
            if (!cart.Add("Apples")) Console.WriteLine("Item already exists"); ;
            cart.Add("Mangoes");
            cart.Add("PineApples");
            cart.Add("Custard Apples");
            Console.WriteLine("The total items: " + cart.Count);
        }

        private static void listExample()
        {
            List<string> basket = new List<string>();//blank list....
            basket.Add("Apples");//Adds the item to the bottom of the List...
            basket.Add("Mangoes");
            basket.Add("Oranges");
            basket.Add("Limes");
            basket.Add("Grapes");
            basket.Insert(3, "Guavas");
            basket.Add("Mangoes");
            basket.Add("Oranges");
            basket.Add("Limes");
            basket.Add("Grapes");
            Console.WriteLine("The total items in the basket is " + basket.Count);
            basket.Remove("Oranges");
            Console.WriteLine("The total items in the basket is " + basket.Count);
            
            foreach (string item in basket) Console.WriteLine(item);
            Console.WriteLine("iterating thro for loop");
            for (int i = 0; i < basket.Count; i++)
            {
                Console.WriteLine(basket[i]);//accessing the data of an object thro index[] is called  as INDEXER. 
            }
            //Limits: Lists allow duplicates, performance wise its slower. For unique collection, U should go for HashSet which stores the data based on the HashKey of the object and equality of the object. 
        }
    }
}
