using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace WcfWinService
{
    //Create the Interface and the Component...
    [ServiceContract]
    public interface IDataComponent
    {
        [OperationContract]
        void AddNewEmployee(Employee emp);
        [OperationContract]
        void UpdateEmployee(Employee emp);
        [OperationContract]
        void DeleteEmployee(int id);
        [OperationContract]
        List<Employee> GetEmployees();
    }
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpID { get; set; }
        [DataMember]
        public string EmpName { get; set; }
        [DataMember]
        public string EmpAddress { get; set; }
        [DataMember]
        public int EmpSalary { get; set; }
    }

    //This is the WCF Component that implements the contract....
    [ServiceBehavior(IncludeExceptionDetailInFaults =true)]
    public class DatabaseService : IDataComponent
    {
        const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=PhilipsDB;Integrated Security=True";//This string contain the credentials and server info for the database connection. 
        //helper function to create the connection and get the Command to make query to the database
        private SqlCommand createCommand(string query)
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(query, con);
            return cmd;
        }
        public void AddNewEmployee(Employee emp)
        {
            string query = "Insert into emptable values(@empName, @empAddress, @empSalary)";
            SqlCommand cmd = createCommand(query);
            cmd.Parameters.AddWithValue("@empName", emp.EmpName);
            cmd.Parameters.AddWithValue("@empAddress", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@empSalary", emp.EmpSalary);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public void DeleteEmployee(int id)
        {
            //Delete from emptable where empid = @id;
            throw new NotImplementedException("Do it URSelf");
        }

        public List<Employee> GetEmployees()
        {
            //create the query..
            var query = "SELECT * FROM EMPTABLE";
            //create the command object
            var cmd = createCommand(query);
            //execute the query after opening the connection
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader  = cmd.ExecuteReader();//If the query is select, we need a reader...
                List<Employee> employees = new List<Employee>();
                while (reader.Read())
                {
                    var emp = new Employee();
                    emp.EmpID = Convert.ToInt32(reader["EmpID"]);
                    emp.EmpName = reader[1].ToString();
                    emp.EmpAddress = reader[2].ToString();
                    emp.EmpSalary = Convert.ToInt32(reader["EmpSalary"]);
                    employees.Add(emp);
                }
                return employees;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            //get the results and convert it to List<Employee>
            
        }

        public void UpdateEmployee(Employee emp)
        {
            var query = "Update Emptable set EmpName = @name, EmpAddress = @address, EmpSalary = @salary where EmpID = @id";
            var cmd = createCommand(query);
            cmd.Parameters.AddWithValue("@name", emp.EmpName);
            cmd.Parameters.AddWithValue("@address", emp.EmpAddress);
            cmd.Parameters.AddWithValue("@salary", emp.EmpSalary);
            cmd.Parameters.AddWithValue("@id", emp.EmpID);
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
//To install the service follow the steps:
/*
 * Right click on the Service Console and select installer. 
 * Go to processInstaller properties and set the Account as User/LocalAccount. 
 * Go to the Installer properties and set the Service name and other details. 
 * Build the Application. 
 * Open the Developer Command prompt(As Admin) and run the command installUtil to install the service.
 * Refresh the Services window to see UR Service...
 * Create the WCF Client and add the service reference using the BaseAddress of the Service App. 
 * 
 */