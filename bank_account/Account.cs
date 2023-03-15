using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace bank_account
{
    internal class Account
    {
        private string name;
        private string password;
        private string ssn;
        private DateTime? dateBirth;
        private int age;
        private double balance;
        private DateTime dateCreation;
        private string aba;

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

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = value; }
        }

        public string ABA
        {
            get { return aba; }
            set { aba = value; }
        }

        public Account(string name, string password, string ssn, DateTime dateBirth)
        {
            Name = name;
            Password = password;
            SSN = ssn;
            DateBirth = dateBirth;
            Age = (int)((DateTime.Now - dateBirth).TotalDays / 365.25);
            Balance = 0;
            DateCreation = DateTime.Now;
            ABA = "";
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                int abaDigit = rnd.Next(0, 10);
                aba += abaDigit.ToString();
            }
        }

        public void DisplayAccount()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Password: " + Password);
            Console.WriteLine("SSN: " + SSN);
            Console.WriteLine("Date of birth: " + DateBirth.ToString());
            Console.WriteLine("Age: " + Age + " years old");
            Console.WriteLine("Balance: $" + Balance.ToString("0.00"));
            Console.WriteLine("Creation date: " + DateCreation);
            Console.WriteLine("ABA: " + ABA);
        }

        public void Withdrawal()
        {
            bool isEntryValid;
            do
            {
                Console.WriteLine("Enter value you wish to withdrawal:");
                bool isWithdrawalValid = Double.TryParse(Console.ReadLine(), out double withdrawal);
                    // `isWithdrawalValid` is used to handle a failed user input's conversion into Double, and `withdrawal` is used to store the value of a successfull String to Double conversion.
                if (isWithdrawalValid & withdrawal > balance) // In case the user tries to withdrawal a value higher than it's account balance.
                {
                    isEntryValid = true;
                    Console.Clear();
                    Console.WriteLine("Invalid value for withdrawal: insufficient funds.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }

                else if (isWithdrawalValid & withdrawal < balance)
                {
                    isEntryValid = true;
                    balance -= withdrawal;
                    Console.Clear ();
                    Console.WriteLine("Successfully withdrawed $" + withdrawal.ToString("0.00"));
                    Console.WriteLine("\nBalance: $" + balance.ToString("0.00"));
                    System.Threading.Thread.Sleep(2500);
                    Console.Clear();
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
                if (isDepositValid)
                {
                    isEntryValid = true;
                    balance += deposit;
                    Console.Clear();
                    Console.WriteLine("Successfully deposited $" + deposit.ToString("0.00"));
                    Console.WriteLine("\nBalance: $" + balance.ToString("0.00"));
                    System.Threading.Thread.Sleep(2500);
                    Console.Clear();
                }

                else
                {
                    isEntryValid = false;
                    Console.Clear();
                    Console.WriteLine("Invalid input for a deposit. A valid deposit is a monetary value, with only numbers.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (!isEntryValid);
        }
    }
}