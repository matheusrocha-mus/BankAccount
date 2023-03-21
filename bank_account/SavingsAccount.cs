using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class SavingsAccount : Account
    {
        public SavingsAccount(string name, string password, string ssn, DateTime? dateBirth, string accountType) : base(name, password, ssn, dateBirth, accountType)
        {
        }

        public override void Withdrawal ()
        {
            base.Withdrawal();
            if (isWithdrawalValid && withdrawal <= Balance)
            {
                if (Balance > 1000)
                {
                    Console.WriteLine("Savings account's 15% interest rate on withdrawals operations for balances over $1,000.00: " + (Balance * 0.15).ToString("C2"));
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2") + " => " + (Balance * 1.15).ToString("C2"));
                    Balance *= 1.15;
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (Balance < withdrawal * 1.03)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid value for withdrawal: insufficient funds. Savings account's have a 3% fee on every withdrawal operation");
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Balance -= withdrawal * 1.03;
                    Console.WriteLine("Successfully withdrawed " + withdrawal.ToString("C2"));
                    Console.WriteLine("Savings account's 3% withdrawal fee: " + (withdrawal * 0.03).ToString("C2"));
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
