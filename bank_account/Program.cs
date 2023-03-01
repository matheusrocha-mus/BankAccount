using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_account
{
    internal class Program
    {
        public class Bank_Account
        {
            private string name;
            private string ssn;
            private double balance;
            private string date;
            private string aba;

            public string SSN
            {
                get { return ssn; }
                set
                {
                    if (int.TryParse(value, out int validSSN) & value.Length == 9)
                    {
                        ssn = Convert.ToString(validSSN);
                    }
                    else
                    {
                        ssn = null;
                    }
                }
            }

        }
    }
}