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

        private static Account newAccount;
        private static Account loggedInAccount;

        public static void Main(string[] args)
        {
            bool isEntryValid; // Used in `do while` statements throughout the code to handle invalid user input
            bool isLoggedIn; // Used to determine the code pathway based on whether the user has logged in on an already existing account or not
            int exitCounter = 0; // Used to exit the program if the user chooses not to login and not to create an account consecutively (no matter the order)
            string input; // Used in many `Console.ReadLine()` throughout the code to store user input 
            List<Account> accountList = new List<Account>(); // Stores the instances of created bank accounts

            while (true)
            {
                isLoggedIn = false;
                if (accountList.Count > 0)
                {
                    do
                    {
                        Console.WriteLine("Would you like to login to an account?");
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
                                isLoggedIn = false;
                                exitCounter++;
                                if (exitCounter == 2)
                                {
                                    Console.WriteLine("Thank you for using our services! Enter any key to exit.");
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                }
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
                                bool continueLogin = false;
                                exitCounter = 0;
                                isLoggedIn = false;
                                do
                                {
                                    Console.WriteLine("Enter SSN (or 'exit' to leave login):");
                                    input = Console.ReadLine();
                                    Console.Clear();
                                    if (input.ToLower() == "exit")
                                    {
                                        continueLogin = false;
                                    }
                                    else
                                    {
                                        if (!accountList.Any(account => account.SSN == input))
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid SSN: no matches found within registered accounts.");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            foreach (Account account in accountList)
                                            {
                                                if (account.SSN == input)
                                                {
                                                    do
                                                    {
                                                        Console.WriteLine("Enter password (or 'back' to try to login with another SSN):");
                                                        input = Console.ReadLine();
                                                        Console.Clear();
                                                        if (input.ToLower() == "back")
                                                        {
                                                            continueLogin = false; ;
                                                        }
                                                        else
                                                        {
                                                            if (account.Password == input)
                                                            {
                                                                continueLogin = false;
                                                                loggedInAccount = account;
                                                                isLoggedIn = true;
                                                                Console.Clear();
                                                                Console.WriteLine("Login successful!\n");
                                                                account.DisplayAccount(false);
                                                                Console.WriteLine("\nEnter any key to continue.");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                            }
                                                            else
                                                            {
                                                                continueLogin = true;
                                                                Console.Clear();
                                                                Console.WriteLine("Incorrect password for this user. Please try again.");
                                                                System.Threading.Thread.Sleep(2000);
                                                                Console.Clear();
                                                            }
                                                        }
                                                    } while (continueLogin);
                                                }
                                            }
                                        }
                                    }
                                } while (!isLoggedIn && input.ToLower() != "exit");
                                break;
                        }
                    } while (!isEntryValid || input.ToLower() == "exit");
                }
                else
                {
                    isLoggedIn = false;
                }

                if (!isLoggedIn)
                {
                    do
                    {
                        Console.WriteLine("Would you like to create a new account?");
                        Console.WriteLine("\n1) Yes\n2) No");
                        input = Console.ReadLine();
                        Console.Clear();
                        switch (input.ToLower())
                        {
                            default:
                                isEntryValid = false;
                                Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                break;

                            case "no":
                            case "2":
                                isEntryValid = true;
                                isLoggedIn = false;
                                exitCounter++;
                                if (accountList.Count == 0 || exitCounter == 2)
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
                                isEntryValid = true;
                                exitCounter = 0;

                                string name = null;
                                while (name == null)
                                {
                                    Console.WriteLine("Enter the account owner's full name:");
                                    input = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[a-zA-ZÀ-ÿ\s]+$"))
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
                                    Console.WriteLine("Create a password: (with 8 characters, upper case, lower case, numbers and special characters)");
                                    input = Console.ReadLine();
                                    if (Regex.IsMatch(input, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\s])[^\s]{8,}$"))
                                    {
                                        password = input;
                                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                                        Console.Write(new string('*', input.Length));
                                        Console.WriteLine("\nConfirm password:");
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
                                    Console.Write("Enter the account owner's date of birth (MM/DD/YYYY):");
                                    input = Console.ReadLine();
                                    if (DateTime.TryParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validBirthDate))
                                    {
                                        if (validBirthDate > DateTime.Now || validBirthDate < DateTime.Now.AddYears(-120))
                                        {
                                            dateBirth = null;
                                            Console.Clear();
                                            Console.WriteLine("Invalid input. Please enter a date between " + DateTime.Now.AddYears(-120).ToString("MM/dd/yyyy") + " and " + DateTime.Now.ToString("MM/dd/yyyy") + ".");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            dateBirth = validBirthDate;
                                        }
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
                                while (ssn == null)
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

                                string accountType = null;

                                newAccount = new Account(name, password, ssn, dateBirth, accountType);

                                if (newAccount.Age < 18)
                                {
                                    do
                                    {
                                        Console.WriteLine("As an underage user, you will automatically be assigned a Teen Account. Proceed?");
                                        Console.WriteLine("\n1) Yes\n2) Exit");
                                        input = Console.ReadLine();
                                        Console.Clear();

                                        switch (input.ToLower())
                                        {
                                            case "1":
                                            case "yes":
                                                isEntryValid = true;
                                                accountType = "Teen";
                                                isLoggedIn = true;
                                                newAccount = new TeenAccount(name, password, ssn, dateBirth, accountType);
                                                accountList.Add(newAccount);
                                                loggedInAccount = newAccount;
                                                break;

                                            case "exit":
                                            case "2":
                                                isEntryValid = true;
                                                isLoggedIn = false;
                                                break;

                                            default:
                                                isEntryValid = false;
                                                Console.WriteLine("Invalid input. Please enter a valid option (1, 2 or 3).");
                                                System.Threading.Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                        }
                                    } while (!isEntryValid) ;
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
                                                accountType = "Savings";
                                                isLoggedIn = true;
                                                newAccount = new SavingsAccount(name, password, ssn, dateBirth, accountType);
                                                accountList.Add(newAccount);
                                                loggedInAccount = newAccount;
                                                break;

                                            case "current":
                                            case "2":
                                                isEntryValid = true;
                                                accountType = "Current";
                                                isLoggedIn = true;
                                                newAccount = new CurrentAccount(name, password, ssn, dateBirth, accountType);
                                                accountList.Add(newAccount);
                                                loggedInAccount = newAccount;
                                                break;

                                            case "exit":
                                            case "3":
                                                isEntryValid = true;
                                                isLoggedIn = false;
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
                                break;
                        }
                    } while (!isEntryValid);
                }

                if (isLoggedIn)
                {
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
                                    loggedInAccount.DisplayAccount(false);
                                    Console.WriteLine("\nEnter any key to continue.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                case "withdrawal":
                                case "2":
                                    isEntryValid = true;
                                    if (loggedInAccount.Balance == 0)
                                    {
                                        Console.WriteLine();
                                        Console.Clear();
                                        Console.WriteLine("Invalid value for a withdrawal: your account balance is currently " + loggedInAccount.Balance.ToString("C2"));
                                        System.Threading.Thread.Sleep(2000);
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        loggedInAccount.Withdrawal();
                                    }
                                    break;

                                case "deposit":
                                case "3":
                                    isEntryValid = true;
                                    loggedInAccount.Deposit();
                                    break;

                                case "exit":
                                case "4":
                                    isEntryValid = true;
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

                        if (keepUsing)
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
            }
        }
    }
}