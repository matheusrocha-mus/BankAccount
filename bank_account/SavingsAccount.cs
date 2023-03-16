using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class SavingsAccount : Account
    {
        public SavingsAccount(string name, string password, string ssn, DateTime? dateBirth) : base(name, password, ssn, dateBirth)
        {
        }

        public override void Withdrawal ()
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
