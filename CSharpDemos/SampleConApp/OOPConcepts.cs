//Single Responsibility Principle->One class should do one job. 
//Open-Closed Principle: Class is closed for modification. but open for extension(Inheritance).
//Luskov's Substitution principle.: A base  class can be substituted by any of the sub classes as long as they retain their functionality. //Metthod overriding and Runtime polymorphism...
//Interface Segration Principle: Its good to have concrete interfaces instead of general interface. 
//Dependency Inversion Principle: Functions should depend on abstractions instead of Concrete members. If U have a base class and a bunch of derived classes, and if U create a methods that returns any of the dervied class objects, then the method should be having the base class object as return instead of any of the derived class objects. 
using System;
using System.IO;

namespace SampleConApp
{
    class Stock//Entity Class.....
    {
        public int StockID { get; set; }
        public string StockName { get; set; }
        public double StockPrice { get; set; }
        public int Quantity { get; set; }
    }

    class RepositoryClass
    {
        private int stockSize = 0;
        public RepositoryClass() : this(0)
        {

        }
        public RepositoryClass(int size)//Parameterized Constructor
        {
            stockSize = size;
            stocks = new Stock[size];
        }

        private Stock[] stocks = null;//Array is reference type, so initialize to null..

        //Functions are created to manipulate the data which is usually private. In this case, we need functions to add, remove, update and read the data....Many times functions are public, however U can have private methods  for better modularity purposes.  
        public void AddNewStock(Stock stock)
        {
            for (int i = 0; i < stockSize; i++)
            {
                if(stocks[i] == null)
                {
                    stocks[i] = new Stock();
                    stocks[i].StockID = stock.StockID;
                    stocks[i].StockName = stock.StockName;
                    stocks[i].StockPrice = stock.StockPrice;
                    stocks[i].Quantity = stock.Quantity;
                    return;//exit the function...                    
                }
            }
            throw new Exception("No more stocks can be added");
        }
        public void UpdateStock(Stock details)
        {
            throw new Exception("Do it URSelf....");
        }
        public void DeleteStock(int id)
        {
            for (int i = 0; i < stockSize; i++)
            {
                if((stocks[i] != null) && (stocks[i].StockID == id))
                {
                    stocks[i] = null;
                    return;
                }
            }
            throw new Exception(string.Format("No Stock by id {0} found to Delete", id));

        }

        public Stock [] GetAllStocks()
        {
            return stocks;
        }
    }

    class MainProgram
    {
        static RepositoryClass market = null;
        static void clear()
        {
            Console.WriteLine("Press any key to clear");
            Console.ReadKey();
            Console.Clear();
        }
        //For a function, if  U want any dependencies 
        static string getMenu(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string contents = reader.ReadToEnd();
            return contents;

        }

        static void Initialize()
        {
           var size =  Input.GetNumber("Enter the no of Stocks to hold");
           market = new RepositoryClass(size);
            clear();
        }
        static void Main(string [] args)
        {
            Initialize();
            string menu = getMenu(args[0]);
            bool processing = true;
            do
            {
                string choice = Input.GetString(menu);
                processing = processMenu(choice);
                if(processing) clear();
            } while (processing);//It should execute atleast once....
        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    addingStock();
                    return true;
                case "2":
                    deleteStock();
                    return true;
                case "3":
                    return true;
                case "4":
                    displayStocks();
                    return true;
                default:
                    return false;
            }
        }

        private static void displayStocks()
        {
            var array = market.GetAllStocks();
            string find = Input.GetString("Enter the name or the part of the name to find the stock");
            for (int i = 0; i < array.Length; i++)
            {
                if((array[i]!= null) && (array[i].StockName.Contains(find)))
                {
                    Console.WriteLine("The Stock:{0}\nThe Price:{1:C}\nThe Quantity:{2}", array[i].StockName, array[i].StockPrice, array[i].Quantity);
                }
            }

        }

        private static void deleteStock()
        {
            int stockID = Input.GetNumber("Enter the ID of the stock to delete");
            try
            {
                market.DeleteStock(stockID);
                Console.WriteLine("Stock is removed successfully from the market");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void addingStock()
        {
            //create a Stock object
            Stock stk = new Stock();
            //Fill the data taking inputs.
            stk.StockID = Input.GetNumber("Enter the Stock ID");
            stk.StockName = Input.GetString("Enter the Stock Name");
            stk.StockPrice = Input.GetDouble("Enter the price of the stock");

            stk.Quantity = Input.GetNumber("Enter the Quantity of the Stock");
            //Add the object to the repository
            try
            {
                market.AddNewStock(stk);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
                //Log the exceptions to a file....
            }
            //Handle exceptions if any
            //message the User...
            Console.WriteLine("Stock inserted successfully");
        }
    }

    //in C# for a class that has only static methods, U could make the class as static and this will ensure that the object is not created for this class as there is no need for an object...
    static class Input
    {
        public static string GetString(string statement)
        {
            Console.WriteLine(statement);
            return Console.ReadLine();
        }

        public static int GetNumber(string statement)
        {
            Console.WriteLine(statement);
            string answer = Console.ReadLine();
            return int.Parse(answer);

        }

        public static DateTime GetDate(string statement) => DateTime.Parse(GetString(statement));

        public static double GetDouble(string statement) => double.Parse(GetString(statement));
    }
}
