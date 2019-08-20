using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.IO;//For File Operations...


/*
 * Add the references of WCF Libs: System.ServiceModel and System.Runtime.Serialization. 
 * create the interface
 * implement the interface
 * implement the Main function.
 * configure the end points. 
 */
namespace SelfHostinApp
{
    [ServiceContract]
    public interface ICustomerService
    {
        
        [OperationContract]
        List<Customer> GetAllCustomers();
        
    }

    [ServiceContract]
    public interface IInternalCustomerService
    {
        [OperationContract]
        void RegisterCustomer(Customer cst);
        [OperationContract]
        void UpdateCustomer(Customer cst);
        [OperationContract]
        void DeleteCustomer(int cstID);
    }
    //For any UDTS that U R using inside the Contracts must be defined with attribute called DataContract as its supposed to perform serialization while the Marshalling happens. The chain should be followed for all the UDTs that are used even in the Data Contract Classes.  
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public long CustomerPhone { get; set; }
        [DataMember]
        public int BillAmount { get; set; }
        [DataMember]
        public DateTime BillDate { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Customer)
            {
                Customer copy = obj as Customer;
                return copy.CustomerID == CustomerID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CustomerID.GetHashCode();
        }
    }


    public class CustomerService : ICustomerService, IInternalCustomerService
    {
        const string fileName = "Customers.csv";
        HashSet<Customer> customers = null;
        private void saveData()
        {
            using(StreamWriter writer  = new StreamWriter(fileName))
            {
                foreach(var cust in customers)
                {
                    var line = string.Format("{0},{1},{2},{3},{4}", cust.CustomerID, cust.CustomerName, cust.CustomerPhone, cust.BillDate, cust.BillAmount);
                    writer.WriteLine(line);
                }
                writer.Flush();
            }
        }

        private void loadData()
        {
            customers = new HashSet<Customer>();
            customers.Clear();//Remove all existing data...
            using(StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var words = line.Split(',');
                    for (int i = 0; i < words.Length; i++)
                    {
                        Customer cst = new Customer();
                        cst.CustomerID = int.Parse(words[0]);
                        cst.CustomerName = words[1];
                        cst.CustomerPhone = long.Parse(words[2]);
                        cst.BillDate = DateTime.Parse(words[3]);
                        cst.BillAmount = int.Parse(words[4]);
                        customers.Add(cst);
                    }
                }
            }
        }

        public CustomerService()
        {
            if (File.Exists(fileName))
                loadData();
            else
                customers = new HashSet<Customer>();
        }
        public void DeleteCustomer(int cstID)
        {
            loadData();
            var cst = customers.FirstOrDefault(c => c.CustomerID == cstID);
            if (cst == null) throw new Exception("Customer not found to delete");
            customers.Remove(cst);
            saveData();
        }

        public List<Customer> GetAllCustomers()
        {
            loadData();
            return customers.ToList();//Convert HashSet to List and then return the data...
        }

        public void RegisterCustomer(Customer cst)
        {
            if (cst == null) throw new Exception("Registration Details are not set");
            customers.Add(cst);
            saveData();//Will save to the file...
        }

        public void UpdateCustomer(Customer cst)
        {
            loadData();
            var found = customers.FirstOrDefault(c => c.CustomerID == cst.CustomerID);
            if (found == null) throw new Exception("Failed to get the Customer details to update");
            found.CustomerName = cst.CustomerName;
            found.CustomerPhone = cst.CustomerPhone;
            found.BillDate = cst.BillDate;
            found.BillAmount = cst.BillAmount;
            saveData();//Update the file...

        }
    }
    class WCFHost
    {
        static void Main(string[] args)
        {
            //WCF service is represented by a class called ServiceHost
            ServiceHost hostApp = new ServiceHost(typeof(CustomerService));
            try
            {
                hostApp.Open();
                Console.WriteLine("Server is ready to handle requests");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                hostApp.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
