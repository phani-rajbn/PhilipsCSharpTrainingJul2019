using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    //If U want a function to be made available among all UR Derived classes, but dont know how to implement currently, then U can only declare the function without a body by making the function as abstract and the class as abstract. 

    abstract class Account
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; private set; }
        public void Credit(int amount) => Balance += amount;
        public void Debit(int amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient Funds");
            Balance -= amount;
        }

        public abstract void CalculateInterest();//Pure virtual functions of C++...        
    }

    //if a class derives from an abstract class, it must implement all the abstract methods of its base class. 
    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            //ptr/100
            var amount = Balance * 1 / 12 * 7.5 / 100;
            Credit((int)amount);
        }
    }
    //override can also be applied on abstract methods. override keyword can be used only on those methods of the base class that are marked as virtual, override, abstract. 
    class RDAccount : Account
    {
        public override void CalculateInterest()
        {
            throw new NotImplementedException("Dont know the formula");
        }
    }
    //Factory method.......
    static class AccountFactory
    {
        public static Account CreateAccount(string type)
        {
            if (type == "SB")
                return new SBAccount();
            else
                return new RDAccount();
        }
    }
    class AbstractClasses
    {
        static void Main(string[] args)
        {
            Account acc = AccountFactory.CreateAccount("RD");
            acc.Name = "Phaniraj";
            acc.AccountNo = 23343;
            acc.Credit(5000);
            acc.CalculateInterest();
            Console.WriteLine($"The current balance:{acc.Balance}");//C# 7.0
        }
    }
}
