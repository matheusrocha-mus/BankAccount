﻿using System;
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
        private double balance = 0; // Sets inicial bank account balance as $0.00.
        private DateTime dateCreation;
        private string aba;

        public string Name
        {
            get { return name; }
            set { name = value[0].ToString().ToUpper() + value.Substring(1).ToLower(); } // Turns the first letter of the name into upper case and the others into lower case.
        }

        public string SSN
        {
            get { return ssn; }
            set
            {
                if (int.TryParse(value, out int validSSN) & value.Length == 9) 
                    // Used to check if the user input is valid -> a valid SSN has exactly 9 numbers and only nummbers. 
                    // If conversion from String to Int is succesfull, it's value is stored in `validSSN`.
                {
                    ssn = Convert.ToString(validSSN);
                }
                else
                {
                    ssn = null; // If user input is not valid, SSN user input in `CreateAccount` will be asked again until it is valid.
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
            get { return dateCreation; } // `set{}` redundant since dateCreation needs to be set in `CreateAccount`.
        }

        public string ABA
        {
            get { return aba; }
            set // Creates a random 9 numbers string as an ABA for the user's account.
            {
                Random rnd = new Random();
                for (int i = 0; i < 9; i++)
                {
                    int abaDigit = rnd.Next(0, 10);
                    aba += abaDigit.ToString();
                }
            }
        }

        public void CreateAccount()
        {
            Console.WriteLine("Enter the customer's full name:");
            Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter the customer's SSN:");
            while (SSN == null) // SSN will be asked from the user again if entry is not valid.
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
            dateCreation = DateTime.Now; // `DateTime.Now displays current day, month, year, hour, minutes and seconds when it's called.
            ABA = "";
        }

        public void DisplayAccount()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("SSN: " + SSN);
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