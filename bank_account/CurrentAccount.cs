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
            if (base.isWithdrawalValid & base.withdrawal < Balance)
            {
                Balance -= withdrawal + (withdrawal * 0.05);
            }
        }
    }
}