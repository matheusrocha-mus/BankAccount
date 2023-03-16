using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            bool isEntryValid; // Used to handle invalid user input in every `Console.ReadLine`.
            string input;
            List<Account> accountList = new List<Account>();
            Account newAccount = null;

            do
            {
                Console.WriteLine("Would you like to create a new account?");
                Console.WriteLine("\n1) Yes\n2) No");
                input = Console.ReadLine();
                Console.Clear();
                switch (input.ToLower())
                {
                    case "yes":
                    case "1":
                        isEntryValid = true;

                        string name = null;
                        while (name == null)
                        {
                            Console.WriteLine("Enter the account owner's full name:");
                            input = Console.ReadLine();
                            if (!string.IsNullOrEmpty(input) & Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                            {
                                string[] names = input.Split(' ');
                                for (int i = 0; i < names.Length; i++)
                                {
                                    names[i] = names[i][0].ToString().ToUpper() + names[i].Substring(1).ToLower();
                                }
                                name = string.Join(" ", names);
                            }
                            else
                            {
                                name = null;
                                Console.Clear();
                                Console.WriteLine("Invalid input. A valid name has no numbers or special characters.");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        Console.Clear();

                        string password = null;
                        while (password == null)
                        {
                            Console.WriteLine("Create a password:");
                            input = Console.ReadLine();
                            if (input.Length >= 8 & input.Any(char.IsUpper) & input.Any(char.IsLower)/* & input.Any(char.IsSymbol)*/)
                            {
                                password = input;
                                Console.Clear();
                                Console.WriteLine("Confirm password:");
                                input = Console.ReadLine();
                                if (input != password)
                                {
                                    password = null;
                                    Console.Clear();
                                    Console.WriteLine("Passwords don't match. Plase try again.");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                password = null;
                                Console.Clear();
                                Console.WriteLine("Invalid input. A valid password must contain at least 1 upper case letter, 1 lower case letter, 1 symbol and be at least 8 characters long.");
                                System.Threading.Thread.Sleep(4500);
                                Console.Clear();
                            }
                        }
                        Console.Clear();

                        DateTime? dateBirth = null;
                        while (dateBirth == null)
                        {
                            Console.Write("Enter your date of birth (MM/DD/YYYY):");
                            input = Console.ReadLine();
                            if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validBirthDate))
                            {
                                dateBirth = validBirthDate;
                            }
                            else
                            {
                                dateBirth = null;
                                Console.Clear();
                                Console.WriteLine("Invalid input. A valid date must be in the format MM/DD/YYYY.");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        Console.Clear();

                        string ssn = null;
                        while (ssn == null )
                        {
                            Console.WriteLine("Enter the account owner's SSN:");
                            input = Console.ReadLine();
                            if (int.TryParse(input, out int validSSN) & input.Length == 9)
                            {
                                ssn = input;
                            }
                            else
                            {
                                ssn = null;
                                Console.Clear();
                                Console.WriteLine("Invalid input. A valid SSN has exactly 9 digits and numbers only.");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        Console.Clear();

                        newAccount = new Account(name, password, ssn, dateBirth);
                        accountList.Add(newAccount);
                        break;

                    case "no":
                    case "2":
                        isEntryValid = true;
                        if (accountList.Count == 0)
                        {
                            Console.WriteLine("Thank you for using our services! Enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Here's a list of all new registered accounts and current balances:\n\n");
                            foreach (Account account in accountList)
                            {
                                account.DisplayAccount();
                            }
                            Console.WriteLine("\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    default:
                        isEntryValid = false;
                        Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            } while (!isEntryValid);

            if (newAccount.Age < 18)
            {
                Console.WriteLine("As an underage user, you have been automatically assigned a Teen Account");
            }
            else
            {
                do
                {
                    Console.WriteLine("Choose an account type:");
                    Console.WriteLine("\n1) Savings\n2) Current\n3) Exit");
                    input = Console.ReadLine();
                    Console.Clear();
                    switch (input.ToLower())
                    {
                        case "savings":
                        case "1":
                            isEntryValid = true;
                            break;

                        case "current":
                        case "2":
                            isEntryValid = true;
                            break;

                        case "exit":
                        case "3":
                            isEntryValid = true;
                            Console.WriteLine("\nThank you for using our services! Enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;

                        default:
                            isEntryValid = false;
                            Console.WriteLine("Invalid input. Please enter a valid option (1, 2 or 3).");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    }
                } while (!isEntryValid);
            }

            bool keepUsing; // Used to check whether the user wants to do another operation after his first one or not.

            do // One bigger loop to be repeated in case user wants to do another operation.
               // Two smaller loops: one for operation choosing and another for deciding wheteher or not user wants to do another operation.
            {
                do
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("\n1) Account data and balance\n2) Withdrawal\n3) Deposit\n4) Exit");
                    input = Console.ReadLine();
                    Console.Clear();
                    switch (input.ToLower())
                    {
                        case "account data and balance":
                        case "account data":
                        case "balance":
                        case "1":
                            isEntryValid = true;
                            newAccount.DisplayAccount();
                            Console.WriteLine("\nEnter any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "withdrawal":
                        case "2":
                            isEntryValid = true;
                            newAccount.Withdrawal();
                            break;

                        case "deposit":
                        case "3":
                            isEntryValid = true;
                            newAccount.Deposit();
                            break;

                        case "exit":
                        case "4":
                            isEntryValid = true;
                            newAccount.DisplayAccount();
                            Console.WriteLine("\nThank you for using our services! Enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;

                        default:
                            isEntryValid = false;
                            Console.WriteLine("Invalid input. Please enter a valid option (1, 2, 3 or 4).");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    }
                } while (!isEntryValid);

                do
                {
                    Console.WriteLine("Would you like to perform another operation?");
                    Console.WriteLine("1) Yes\n2) No");
                    input = Console.ReadLine();
                    Console.Clear();
                    switch (input.ToLower())
                    {
                        case "yes":
                        case "1":
                            isEntryValid = true;
                            keepUsing = true;
                            break;

                        case "no":
                        case "2":
                            isEntryValid = true;
                            keepUsing = false;
                            Console.WriteLine("Thank you! Please enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;

                        default:
                            isEntryValid = false;
                            keepUsing = true;
                            Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    }
                } while (!isEntryValid);
            } while (keepUsing);

            Console.WriteLine("\nThank you for using our services! Press any key to exit.");
            Console.ReadKey();
        }
    }
}