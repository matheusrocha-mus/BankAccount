using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_account
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            bool isEntryValid; // Used to handle invalid user input in every `Console.ReadLine`.
            string input;
            Account account = new Account();

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
                        account.CreateAccount();
                        break;

                    case "no":
                    case "2":
                        isEntryValid = true;
                        Console.WriteLine("Thank you for using our services! Enter any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;

                    default:
                        isEntryValid = false;
                        Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            } while (!isEntryValid);

            do
            {
                Console.WriteLine("Choose an account type:");
                Console.WriteLine("\n1) Savings\n2) Current\n3) Teen (underage user)\n4) Exit");
                input = Console.ReadLine();
                Console.Clear();
                switch (input.ToLower())
                {
                    case "savings":
                    case "1":
                        isEntryValid = true;
                        account.SavingsAccount
                        break;

                    case "current":
                    case "2":
                        isEntryValid = true;
                        break;

                    case "teen":
                    case "3":
                        isEntryValid = true;
                        break;

                    case "exit":
                    case "4":
                        isEntryValid = true;
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
                            account.DisplayAccount();
                            Console.WriteLine("\nEnter any key to continue.");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "withdrawal":
                        case "2":
                            isEntryValid = true;
                            account.Withdrawal();
                            break;

                        case "deposit":
                        case "3":
                            isEntryValid = true;
                            account.Deposit();
                            break;

                        case "exit":
                        case "4":
                            isEntryValid = true;
                            account.DisplayAccount();
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