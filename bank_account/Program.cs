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
            bool keep_registering;
            string input;

            List<Account> accountList = new List<Account>();

            do
            {
                Console.WriteLine("Would you like to create a new account?");
                Console.WriteLine("1) Yes\n2) No");
                input = Console.ReadLine();
                Console.Clear();
                switch (input.ToLower())
                {
                    case "yes":
                    case "1":
                        keep_registering = true;
                        Account newAccount = new Account();
                        newAccount.createAccount();
                        break;
                    case "no":
                    case "2":
                        keep_registering = false;
                        if (accountList.Count > 0)
                        {
                            Console.WriteLine("Here's a list of all new created accounts:\n");

                            foreach (Account account in accountList)
                            {
                                account.displayAccount();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Thank you! Please enter any key to exit.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        break;

                    default:
                        keep_registering = true;
                        Console.WriteLine("Invalid input. Please enter a valid option (1 or 2).");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            } while (keep_registering);

            Console.WriteLine("\nThank you for using our services! Press any key to exit.");
            Console.ReadKey();
        }
    }
}