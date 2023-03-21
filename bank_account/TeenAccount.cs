using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class TeenAccount : Account
    {
        public TeenAccount(string name, string password, string ssn, DateTime? dateBirth, string accountType) : base(name, password, ssn, dateBirth, accountType)
        {
        }

        public override void Withdrawal ()
        {
            base.Withdrawal();
            if (isWithdrawalValid && withdrawal <= Balance)
            {
                if (withdrawal >= 50)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid withdrawal value: only widrawals below $50.00 are allowed for Teen accounts.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }

                else if (Balance < withdrawal * 1.02)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid value for withdrawal: insufficient funds. Teen account's have a 2% fee on every withdrawal operation.");
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                
                else
                {
                    Balance -= withdrawal * 1.02;
                    Console.WriteLine("Successfully withdrawed " + withdrawal.ToString("C2"));
                    Console.WriteLine("Teen account's 2% withdrawal fee: " + (withdrawal * 0.02).ToString("C2"));
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
