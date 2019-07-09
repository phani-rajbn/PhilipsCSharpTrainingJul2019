//Single Responsibility Principle->One class should do one job. 
//Open-Closed Principle: Class is closed for modification. but open for extension(Inheritance).
//Luskov's Substitution principle.: A base  class can be substituted by any of the sub classes as long as they retain their functionality. //Metthod overriding and Runtime polymorphism...
//Interface Segration Principle: Its good to have concrete interfaces instead of general interface. 
//Dependency Inversion Principle: Functions should depend on abstractions instead of Concrete members. If U have a base class and a bunch of derived classes, and if U create a methods that returns any of the dervied class objects, then the method should be having the base class object as return instead of any of the derived class objects. 
using System;
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
        static void Main()
        {
            //By default, all reference type objects will be null if U dont instantiate them using new operator.....
            Stock stk = new Stock { StockID = 1, StockName = "Infosys", Quantity = 100, StockPrice = 456.56 };
            Console.WriteLine(stk.StockName);//Implicitly calls ToString() method of the class...

            RepositoryClass cls = new RepositoryClass(100);
            
        }
    }
}
