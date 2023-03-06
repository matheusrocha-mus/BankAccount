using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_account
{
    internal class TeenAccount : Account
    {
        public void Withdrawal ()
        {
            if (isWithdrawalValid & withdrawal < Balance)
            {
                if (withdrawal < 50)
                {
                    Balance -= withdrawal - (withdrawal* 0.02);
                }

                else
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
