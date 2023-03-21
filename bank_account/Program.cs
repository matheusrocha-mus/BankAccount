using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            bool isEntryValid; // Used to handle invalid user input in every `Console.ReadLine()`.
            bool keepRegistering; // Used to check and validate whether the user wants to create another account or not
            string input; // Used in many `Console.ReadLine()` throughout the code to store user input 
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
                    default:
                        keepRegistering = true;
                        Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;

                    case "no":
                    case "2":
                        keepRegistering = false;
                        if (accountList.Count == 0)
                        {
                            Console.WriteLine("Thank you for using our services! Enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Here's a list of all new registered accounts and their info:\n\n");
                            foreach (Account account in accountList)
                            {
                                account.DisplayAccount(true);
                            }
                            Console.WriteLine("\nEnter any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;

                    case "yes":
                    case "1":
                        keepRegistering = true;

                        string name = null;
                        while (name == null)
                        {
                            Console.WriteLine("Enter the account owner's full name:");
                            input = Console.ReadLine();
                            if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
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
                            if (Regex.IsMatch(input, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\s])[^\s]{8,}$"))
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
                                Console.WriteLine("Invalid input. A valid password must be at least 8 characters long and contain at least 1 upper case letter, 1 lower case letter, 1 number and one special character/symbol/ponctuation sign.");
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
                            if (int.TryParse(input, out int validSSN) && input.Length == 9)
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

                        if (newAccount.Age < 18)
                        {
                            Console.WriteLine("As an underage user, you have been automatically assigned a Teen Account.\n");
                            newAccount = new TeenAccount(name, password, ssn, dateBirth);
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
                                        newAccount = new SavingsAccount(name, password, ssn, dateBirth);
                                        break;

                                    case "current":
                                    case "2":
                                        isEntryValid = true;
                                        newAccount = new CurrentAccount(name, password, ssn, dateBirth);
                                        break;

                                    case "exit":
                                    case "3":
                                        isEntryValid = true;
                                        if (accountList.Count == 0)
                                        {
                                            Console.WriteLine("Thank you for using our services! Enter any key to exit.");
                                            Console.ReadKey();
                                            Environment.Exit(0);
                                        }
                                        else
                                        {
                                            input = "exit";
                                        }
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
                        
                        if (input != "exit")
                        {
                            accountList.Add(newAccount);

                            bool keepUsing = true; // Used to check whether the user wants to do another operation or not.

                            do // One bigger loop to be repeated in case user wants to do another operation.
                            {
                                do // Two smaller loops: one for operation choosing and another for deciding whether or not user wants to do another operation.
                                {
                                    Console.WriteLine("Please choose an option:");
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
                                            newAccount.DisplayAccount(false);
                                            Console.WriteLine("\nEnter any key to continue.");
                                            Console.ReadKey();
                                            Console.Clear();
                                            break;

                                        case "withdrawal":
                                        case "2":
                                            isEntryValid = true;
                                            if (newAccount.Balance == 0)
                                            {
                                                Console.WriteLine();
                                                Console.Clear();
                                                Console.WriteLine("Invalid value for a withdrawal: your account balance is currently " + newAccount.Balance.ToString("C2"));
                                                System.Threading.Thread.Sleep(2000);
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                newAccount.Withdrawal();
                                            }
                                            break;

                                        case "deposit":
                                        case "3":
                                            isEntryValid = true;
                                            newAccount.Deposit();
                                            break;

                                        case "exit":
                                        case "4":
                                            isEntryValid = true;
                                            input = "exit";
                                            keepUsing = false;
                                            break;

                                        default:
                                            isEntryValid = false;
                                            Console.WriteLine("Invalid input. Please enter a valid option (1, 2, 3 or 4).");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.Clear();
                                            break;
                                    }
                                } while (!isEntryValid);

                                if (input != "exit")
                                {
                                    do
                                    {
                                        Console.WriteLine("Would you like to perform another operation?");
                                        Console.WriteLine("\n1) Yes\n2) No");
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
                                }
                            } while (keepUsing);
                        }
                        break;
                }
                do
                {
                    Console.WriteLine("Would you like to login on an account?");
                    Console.WriteLine("\n1) Yes\n2) No\n3) Account list");
                    input = Console.ReadLine();
                    Console.Clear();
                    switch (input.ToLower())
                    {
                        default:
                            isEntryValid = false;
                            Console.WriteLine("Invalid input. Please enter a valid option (1, 2 or 3).");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            break;

                        case "no":
                        case "2":
                            isEntryValid = true;
                            Console.WriteLine("Thank you for using our services! Enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;

                        case "account list":
                        case "list":
                        case "3":
                            isEntryValid = false;
                            foreach (Account account in accountList)
                            {
                                account.DisplayAccount(true);
                            }
                            Console.WriteLine("\nEnter any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "yes":
                        case "1":
                            isEntryValid = true;
                            bool ssnMatched = false;
                            do
                            {
                                Console.WriteLine("Enter SSN:");
                                input = Console.ReadLine();
                                foreach (Account account in accountList)
                                {
                                    if (account.SSN == input)
                                    {
                                        Console.WriteLine("\nEnter password:");
                                        input = Console.ReadLine();
                                        if (account.Password == input)
                                        {
                                            // return account...?
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Incorrect password for this user. Please try again.");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.Clear();
                                        }
                                        ssnMatched = true;
                                        break;
                                    }
                                }
                                if (!ssnMatched)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid SSN: no matches found within registered accounts.");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.Clear();
                                }
                            } while (!ssnMatched);
                            break;
                    }
                } while (!isEntryValid);
            } while (keepRegistering);
        }
    }
}