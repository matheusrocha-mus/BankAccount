using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class TeenAccount : Account
    {
        public TeenAccount(string name, string password, string ssn, DateTime? dateBirth) : base(name, password, ssn, dateBirth)
        {
        }

        public override void Withdrawal ()
        {
            if (isWithdrawalValid & withdrawal < Balance)
            {
                if (withdrawal < 50)
                {
                    Balance -= withdrawal - (withdrawal* 0.02);
                }

                if (withdrawal >= 50)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid withdrawal value: only widrawals below $50.00 are allowed for Teen accounts.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}
