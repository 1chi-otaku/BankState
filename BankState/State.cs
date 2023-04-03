using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankState
{
    abstract class State
    {
        protected Account account;
        protected double balance;
        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;

        public Account GetAccount() { return account; }
        public void SetAccount(Account new_account) {account = new_account; }
        public double GetBalance() { return balance; }
        public void SetBalance(double new_balance) { balance = new_balance; }

        abstract public void Deposit(double amount);
        abstract public bool Withdraw(double amount);
        abstract public bool PayInterest();

    }

    class RedState : State
    {

        public RedState(State state) {
            balance = state.GetBalance();
            account = state.GetAccount();
            Initialize();
        }
        void Initialize()
        {
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
        }
        void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.SetState(new SilverState(this));
            }
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override bool PayInterest()
        {
            Console.WriteLine("No interest is paid!");
            return false;
        }

        public override bool Withdraw(double amount)
        {
            Console.WriteLine("No cash can be withdrawn");
            return false;
        }
    }

    class SilverState : State
    {
        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        public SilverState(State state):this(state.GetBalance(),state.GetAccount())
        {
        }
        void Initialize()
        {
            interest = 0.01;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }
        void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                account.SetState(new RedState(this));
            }
            else if (balance > upperLimit)
            {
                 account.SetState(new GoldenState(this));
            }
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override bool PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
            return true;
        }

        public override bool Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
            return true;
        }
    }

    class GoldenState : State
    {
        public GoldenState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }
        public GoldenState(State state):this(state.GetBalance(),state.GetAccount()) { }
        void Initialize()
        {
            interest= 0.07;
            lowerLimit = 1000.0;
            upperLimit= 100000000.0;
        }
        void StateChangeCheck()
        {
            if(balance < 0.0)
            {
                account.SetState(new RedState(this));
            }
            else if(balance < lowerLimit)
            {
                account.SetState(new SilverState(this));
            }
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }

        public override bool PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
            return true;
        }

        public override bool Withdraw(double amount)
        {
           balance -= amount;
           StateChangeCheck(); return true;
        }
    }
}
