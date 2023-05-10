#Bank Account
This is a console-based bank account management system written in C# that allows users to create different types of accounts (savings, current, teen) and perform various operations on their accounts, such as depositing, withdrawing, checking balance, changing/creating other accounts and more.

##Features
• Create accounts
• Deposit and withdraw funds from accounts
• Transfer funds between accounts (TO BE IMPLEMENTED!!!)
• Display account information, including balance
  ↳ Option to display account information with or without sensitive data (such as account number, SSN and password)
• User authentication with login and password
• Different account types with varying interest rates, withdrawal fees and account restrictions

##Technical Details
The project is structured into four main classes: Account, SavingsAccount, CurrentAccount, and TeenAccount. The Account class serves as the base class for all account types and contains common attributes and methods, such as Deposit and Withdraw. The other three classes inherit from Account and have their own unique attributes and methods.

The program uses object-oriented programming principles, such as inheritance and polymorphism, to manage different types of accounts. User input is validated with regular expressions to ensure that it meets certain requirements, such as having a minimum password length and containing at least one uppercase letter and one special character.

##Usage
To use the program, simply download or clone the repository and open it in a C# IDE or text editor. Compile and run the program to start using the bank account management system.

Upon starting the program, the user will be prompted to log in with an existing account or create a new account. Once logged in, the user can perform various operations on their account, such as depositing or withdrawing funds, checking their balance, and transferring funds to another account.

##Contributing
Contributions to this project are welcome! If you notice any bugs or would like to suggest an improvement, please create an issue or submit a pull request.
