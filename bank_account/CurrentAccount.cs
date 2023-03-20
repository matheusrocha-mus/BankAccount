using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class CurrentAccount : Account
    {
        public CurrentAccount(string name, string password, string ssn, DateTime? dateBirth) : base(name, password, ssn, dateBirth)
        {
        }

        public override void Withdrawal()
        {
            base.Withdrawal(); 
            if (isWithdrawalValid && withdrawal <= Balance)
            {
                if (Balance < withdrawal * 1.05)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid value for withdrawal: insufficient funds. Current account's have a 5% fee on every withdrawal operation.");
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Balance -= withdrawal * 1.05;
                    Console.WriteLine("Successfully withdrawed " + withdrawal.ToString("C2"));
                    Console.WriteLine("Current account's 5% withdrawal fee: " + (withdrawal * 0.05).ToString("C2"));
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}