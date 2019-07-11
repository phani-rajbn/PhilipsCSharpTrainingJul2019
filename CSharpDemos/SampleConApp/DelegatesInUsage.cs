using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Stock
    {
        public int StockID { get; set; }
        public string StockName { get; set; }
        public int StockPrice { get; set; }
        public override bool Equals(object obj)
        {
            return ((Stock)obj).StockID == StockID;
        }
        public override int GetHashCode()
        {
            return StockID.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Stock:{0}\nPrice:{1:C}", StockName, StockPrice);
        }

        
    }

    class StockMarket
    {
        HashSet<Stock> _stocks = new HashSet<Stock>();
        public event Action<List<Stock>> Refresh;
        public void AddStock(Stock stock)
        {
            if (_stocks.Add(stock))
            {
                if(Refresh != null)
                Refresh(AllStocks);
            }
        }

        public void UpdateStock(Stock stock)
        {
            var update = _stocks.FirstOrDefault((s) => s.StockID == stock.StockID);
            update.StockName = stock.StockName;
            update.StockPrice = stock.StockPrice;
            Refresh(AllStocks);
        }

        public List<Stock> AllStocks => _stocks.ToList();
    }
    class DelegatesInUsage
    {
        static StockMarket app = new StockMarket();
        static void Main(string[] args)
        {

            var selectedType = Assembly.GetExecutingAssembly().GetType("SampleConApp.StockMarket");
            var objectInstance = Activator.CreateInstance(selectedType);
            var method = selectedType.GetMethod("AddStock");
            var parameters = method.GetParameters();
            if(parameters[0].ParameterType.FullName == "SampleConApp.Stock")
            {
                var type = parameters[0].ParameterType;
                var pm = Activator.CreateInstance(type);
                foreach(var property in type.GetProperties())
                {
                    Console.WriteLine("Enter the value of the type {0} for the property{1}", property.PropertyType.Name, property.Name);
                    var value = Convert.ChangeType(Console.ReadLine(), property.PropertyType);
                    property.SetValue(pm, value);
                }
                method.Invoke(objectInstance, new object[] { pm });
            }
            var another = selectedType.GetProperty("AllStocks");
            var returnValue = another.GetValue(objectInstance);
            //Console.WriteLine(returnValue.GetType().Name);
            // var list = returnValue as List<object>;
            ArrayList data = new ArrayList(returnValue as ICollection);
            foreach(var itemm in data)
                Console.WriteLine(itemm);

            //app.Refresh += App_Refresh;
            //do
            //{
            //    Console.WriteLine("Press 1 to Add and 2 To Update");
            //    string choice = Console.ReadLine();
            //    if(choice == "1")
            //    {
            //        var stock = new Stock
            //        {
            //            StockID = int.Parse(Console.ReadLine()),
            //            StockName = Console.ReadLine(),
            //            StockPrice = int.Parse(Console.ReadLine())
            //        };
            //        app.AddStock(stock);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Updating the Stock");
            //        var stock = new Stock
            //        {
            //            StockID = int.Parse(Console.ReadLine()),
            //            StockName = Console.ReadLine(),
            //            StockPrice = int.Parse(Console.ReadLine())
            //        };
            //        app.UpdateStock(stock);
            //    }
            //} while (true);
        }

        private static void App_Refresh(List<Stock> obj)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var stock in obj)
                Console.WriteLine(stock);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        }
    }
}
