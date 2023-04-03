using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankState
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account("Tom");
            account.SetState(new SilverState(0.0, account));
            account.Deposit(500);
            Console.WriteLine();
            account.Deposit(300);
            Console.WriteLine();
            account.PayInterest();
            Console.WriteLine();
            account.Deposit(550);
            Console.WriteLine();
            account.PayInterest();
            Console.WriteLine();
            account.Withdraw(2000);
            Console.WriteLine();
            account.Withdraw(1100);
            Console.WriteLine();
            account.PayInterest();
            

        }
    }
}
