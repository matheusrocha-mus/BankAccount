using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_account
{
    internal class SavingsAccount : Account
    {
        public void Withdrawal ()
        {
            if (isWithdrawalValid & withdrawal < Balance)
            {
                if (Balance > 1000)
                {
                    Balance += Balance * 0.15;
                }
                Balance -= withdrawal - (withdrawal * 0.03);
            }
        }
    }
}
