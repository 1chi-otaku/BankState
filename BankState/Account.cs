using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankState
{
    internal class Account
    {
        State state;
        string onwer;

        public Account(string owner)
        {
            this.onwer = owner;
        }
        public double GetBalance()
        {
            return state.GetBalance();
        }
        public State GetState()
        {
            return state;
        }
        public void SetState(State state)
        {
            this.state = state;
        }

        public void Deposit(double amount)
        {
            state.Deposit(amount);
            Console.WriteLine("Deposited - " + amount);
            Console.WriteLine("Balance - " + GetBalance());
            Console.WriteLine("Status - " + GetState().ToString());
        }
        public void Withdraw(double amount)
        {
            state.Withdraw(amount);
            Console.WriteLine("Withdraw - " + amount);
            Console.WriteLine("Balance - " + GetBalance());
            Console.WriteLine("Status - " + GetState().ToString());
        }
        public void PayInterest()
        {
            if (state.PayInterest())
            {
                Console.WriteLine("Interest Paid!");
                Console.WriteLine("Balance - " + state.GetBalance());
                Console.WriteLine("Status - " + GetState().ToString());
            }
        }

    }
}
