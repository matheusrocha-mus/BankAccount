using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BankAccount
{
    internal class Account
    {
        private string name;
        private string password;
        private string ssn;
        private DateTime? dateBirth;
        private int age;
        private string accountType;
        private string accountID;
        private string abaNumber;
        private DateTime dateCreation;
        private double balance;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        public DateTime? DateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        public string AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public string ABANumber
        {
            get { return abaNumber; }
            set { abaNumber = value; }
        }

        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Account(string name, string password, string ssn, DateTime? dateBirth, string accountType)
        {
            Name = name;
            Password = password;
            SSN = ssn;
            DateBirth = dateBirth;
            Age = (int)((DateTime.Now - (dateBirth ?? DateTime.MinValue)).TotalDays / 365.25);
            AccountType = accountType;
            AccountID = "";
            Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                int accountDigit = rnd.Next(0, 13);
                accountID += accountDigit.ToString();
            }
            ABANumber = "";
            for (int i = 0; i < 9; i++)
            {
                int abaDigit = rnd.Next(0, 10);
                abaNumber += abaDigit.ToString();
            }
            DateCreation = DateTime.Now;
            Balance = 0;
        }

        public void DisplayAccount(bool showAllAccounts)
        {
            Console.WriteLine("Name: " + Name);
            if (showAllAccounts)
            {
                Console.WriteLine("Password: " + Password[0] + new string('*', Password.Length - 2) + Password[Password.Length - 1]);
                Console.WriteLine("SSN: " + SSN[0] + new string('*', SSN.Length - 2) + SSN[SSN.Length - 1]);
                Console.WriteLine("Date of birth: " + DateBirth?.ToString("MM/dd/yyyy"));
                Console.WriteLine("Age: " + Age + " years old");
                Console.WriteLine("Account type: " + AccountType);
                Console.WriteLine("Account ID: " + AccountID[0] + new string('*', AccountID.Length - 2) + AccountID[AccountID.Length - 1]);
                Console.WriteLine("ABA number: " + ABANumber[0] + new string('*', ABANumber.Length - 2) + ABANumber[ABANumber.Length - 1]);
                Console.WriteLine("Creation date: " + DateCreation);
                Console.WriteLine("Balance: " + new string('*', balance.ToString("C2").Length - 3) + balance.ToString("C2").Substring(balance.ToString("C2").Length - 3) + "\n");
            }
            else
            {
                Console.WriteLine("Password: " + Password);
                Console.WriteLine("SSN: " + SSN);
                Console.WriteLine("Date of birth: " + DateBirth?.ToString("MM/dd/yyyy"));
                Console.WriteLine("Age: " + Age + " years old");
                Console.WriteLine("Account type: " + AccountType);
                Console.WriteLine("Account ID: " + AccountID);
                Console.WriteLine("ABA number: " + ABANumber);
                Console.WriteLine("Creation date: " + DateCreation);
                Console.WriteLine("Balance: " + Balance.ToString("C2") + "\n");
            }
        }

        protected bool isWithdrawalValid;
        protected double withdrawal;

        public virtual void Withdrawal()
        {
            bool isEntryValid;
            do
            {
                Console.WriteLine("Enter value you wish to withdrawal:");
                isWithdrawalValid = Double.TryParse(Console.ReadLine(), out withdrawal);
                    // `isWithdrawalValid` is used to handle a failed user input's conversion into Double, and `withdrawal` is used to store the value of a successfull String to Double conversion.
                if (isWithdrawalValid && withdrawal > Balance) // In case the user tries to withdrawal a value higher than it's account balance.
                {
                    isEntryValid = true;
                    Console.Clear();
                    Console.WriteLine("Invalid value for withdrawal: insufficient funds.");
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (isWithdrawalValid && withdrawal <= Balance && withdrawal > 0)
                {
                    isEntryValid = true;
                    Console.Clear ();
                }

                else
                {
                    isEntryValid = false;
                    Console.Clear();
                    Console.WriteLine("Invalid input for a withdrawal. A valid withdrawal is a monetary value, with only numbers.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (!isEntryValid);
        }

        public void Deposit()
        {
            bool isEntryValid;
            do
            {
                Console.WriteLine("Enter value you wish to deposit:");
                bool isDepositValid = Double.TryParse(Console.ReadLine(), out double deposit); 
                    // `isDepositValid` is used to handle a failed user input's conversion into Double, and `deposit` is used to store the value of a successfull String to Double conversion.
                if (isDepositValid && deposit > 0)
                {
                    isEntryValid = true;
                    Balance += deposit;
                    Console.Clear();
                    Console.WriteLine("Successfully deposited " + deposit.ToString("C2"));
                    Console.WriteLine("\nBalance: " + Balance.ToString("C2"));
                    Console.WriteLine("\nEnter any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    isEntryValid = false;
                    Console.Clear();
                    Console.WriteLine("Invalid input for a deposit. A valid deposit is a monetary value, with only numbers, higher than $0.00.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (!isEntryValid);
        }
    }
}