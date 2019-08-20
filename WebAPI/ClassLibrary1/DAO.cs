using System;
using System.Data;
using System.IO;
namespace ClassLibrary1
{
    public interface IDataComponent
    {
        void InsertRecord(string data);
        DataTable GetAllRecords();
    }

    public class DataAccessObject : IDataComponent
    {
        const string filename = @"B:\Programs\PhilipsWCF_Aug2019\WCFExamples\ClassLibrary1\Employees.csv";
        private void fillTable(DataTable table)
        {
            if (table == null) throw new Exception("Table not created");
            var lines = File.ReadLines(filename);
            foreach(var line in lines)
            {
                var words = line.Split(',');
                var row = table.NewRow();
                for (int i = 0; i < words.Length; i++)
                {
                    row[i] = words[i];
                }
                table.Rows.Add(row);
            }
            table.AcceptChanges();
        }
        public DataTable GetAllRecords()
        {
            var table = new DataTable("Records");
            table.Columns.Add("EmpID", typeof(int));
            table.Columns.Add("EmpName", typeof(string));
            table.Columns.Add("EmpAddress", typeof(string));
            table.Columns.Add("EmpSalary", typeof(double));
            table.PrimaryKey = new DataColumn[] { table.Columns[0] };
            fillTable(table);
            return table;
        }

        public void InsertRecord(string data)
        {
            using(StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine(data);
                writer.Flush();
            }
        }
    }

}
