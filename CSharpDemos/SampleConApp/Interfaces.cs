using System;
using System.Data;
using System.IO;
using System.Collections.Generic;

//interfaces are like abstract classes but will have only abstract methods in them. They can have methods, properties but not fields. interface members are always public and no access specifier is allowed. The class that implements the interface must provide the public defns for all those methods of the interface, else the class should be marked as abstract. 
namespace SampleConApp
{
    interface IFileComponent
    {
        void AddStock(int id, string name, double amount);
        void UpdateStock(int id, string name, double amount);
        void DeleteStock(int id);
        DataTable GetAllStocks();
    }

    class FileManager : IFileComponent
    {
        const string filename = "Data.csv";
        public void AddStock(int id, string name, double amount)
        {
            StreamWriter wr = new StreamWriter(filename, true);//true for appending....
            string format = string.Format($"{id},{name},{amount}");
            wr.WriteLine(format);
            wr.Close();
        }

        public void DeleteStock(int id)
        {
            List<string> allLines = new List<string>(File.ReadAllLines(filename));
            //Get all the lines from the CSV into a List<string>
            foreach(string line in allLines)//iterate thro the lines
            {
                var words = line.Split(',');//split each line by , which gives array of string
                if(words[0] == id.ToString())
                {
                    allLines.Remove(line);
                    break;//exit the loop...
                }
            }
            File.WriteAllLines(filename, allLines.ToArray());
        }

        public DataTable GetAllStocks()
        {
            //Memory table that looks like a table of a database. 
            DataTable table = new DataTable("Stocks");
            table.Columns.Add("StockID", typeof(int));
            table.Columns.Add("StockName", typeof(string));
            table.Columns.Add("StockPrice", typeof(int));
            table.AcceptChanges();

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var words = line.Split(',');
                DataRow row = table.NewRow();
                for (int i = 0; i < words.Length; i++)
                {
                    row[i] = words[i];
                }
                table.Rows.Add(row);
            }
            table.AcceptChanges();
            reader.Close();
            return table;
        }

        public void UpdateStock(int id, string name, double amount)
        {
            throw new NotImplementedException();
        }
    }
    class Interfaces
    {
        static void Main(string[] args)
        {
            IFileComponent com = new FileManager();
            //com.AddStock(112, "Wipro", 1400);
            //com.DeleteStock(112);
            var records = com.GetAllStocks();
            foreach(DataRow row in records.Rows)
                Console.WriteLine(row[1]);
        }
    }
}
