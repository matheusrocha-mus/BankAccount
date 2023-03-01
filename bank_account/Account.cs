using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_account
{
    internal class Account
    {
        private string name;
        private string ssn;
        private double balance = 0;
        private DateTime dateCreation;
        private string aba;

        public string Name
        {
            get { return Name; }
            set { Name = value[0].ToString().ToUpper() + value.Substring(1).ToLower(); }
        }

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

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public DateTime DateCreation
        {
            get { return dateCreation; }
            set { dateCreation = DateTime.Now; }
        }

        public string ABA
        {
            get { return aba; }
            set
            {
                Random rnd = new Random();
                for (int i = 0; i < 9; i++)
                {
                    int abaDigit = rnd.Next(0, 10);
                    aba += abaDigit.ToString();
                }
            }
        }

        public void createAccount()
        {
            Console.WriteLine("Enter the customer's full name:");
            Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter the customer's SSN:");
            while (SSN == null)
            {
                SSN = Console.ReadLine();
                if (SSN == null)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input for 'SSN'. A valid SSN has exactly 9 digits and numbers only.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Enter the customer's SSN:");
                }
            }
            Console.Clear();
        }

        public void DisplayAccount()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("SSN: " + SSN);
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine("Creation date: " + DateCreation);
            Console.WriteLine("ABA: " + ABA);
        }

        public void Withdrawal()
        {
            bool validWithdrawal = Double.TryParse(Console.ReadLine(), out double withdrawal);
            if (validWithdrawal & withdrawal > balance)
            {
                Console.Clear();
                Console.WriteLine("Invalid value for withdrawal: insufficient funds.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }

            else if (validWithdrawal & withdrawal < balance)
            {
                balance -= withdrawal;
                Console.Clear ();
                Console.WriteLine("Successfully withdrawed $" + withdrawal);
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input for a withdrawal. A valid withdrawal is a monetary value, with only numbers.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }

        public void Deposit()
        {
            bool validDeposit = Double.TryParse(Console.ReadLine(), out double deposit);
            if (validDeposit)
            {
                balance += deposit;
                Console.Clear();
                Console.WriteLine("Successfully deposited $" + deposit);
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input for a deposit. A valid deposit is a monetary value, with only numbers.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}