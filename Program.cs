using System;
using System.Collections.Generic;

class BankAccount
{
    private string accountNumber;
    private string accountHolder;
    private decimal balance;

    public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
    {
        this.accountNumber = accountNumber;
        this.accountHolder = accountHolder;
        this.balance = initialBalance;
    }

    public string AccountNumber
    {
        get { return accountNumber; }
    }

    public string AccountHolder
    {
        get { return accountHolder; }
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient funds!");
            return false;
        }

        balance -= amount;
        return true;
    }
}

class Bank
{
    private List<BankAccount> accounts;

    public Bank()
    {
        accounts = new List<BankAccount>();
    }

    public void AddAccount(BankAccount account)
    {
        accounts.Add(account);
    }

    public BankAccount FindAccount(string accountNumber)
    {
        return accounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        // Create some initial bank accounts
        BankAccount account1 = new BankAccount("123456789", "John Doe", 1000);
        BankAccount account2 = new BankAccount("987654321", "Jane Smith", 5000);

        bank.AddAccount(account1);
        bank.AddAccount(account2);

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("\nBank Account Manager");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter account number: ");
                    string newAccountNumber = Console.ReadLine();
                    Console.Write("Enter account holder name: ");
                    string newAccountHolder = Console.ReadLine();
                    Console.Write("Enter initial balance: ");
                    decimal initialBalance = decimal.Parse(Console.ReadLine());

                    BankAccount newAccount = new BankAccount(newAccountNumber, newAccountHolder, initialBalance);
                    bank.AddAccount(newAccount);

                    Console.WriteLine("Account created successfully!");
                    break;

                case 2:
                    Console.Write("Enter account number: ");
                    string depositAccountNumber = Console.ReadLine();
                    BankAccount depositAccount = bank.FindAccount(depositAccountNumber);

                    if (depositAccount != null)
                    {
                        Console.Write("Enter deposit amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        depositAccount.Deposit(depositAmount);
                        Console.WriteLine("Deposit successful. New balance: $" + depositAccount.Balance);
                    }
                    else
                    {
                        Console.WriteLine("Account not found!");
                    }
                    break;

                case 3:
                    Console.Write("Enter account number: ");
                    string withdrawAccountNumber = Console.ReadLine();
                    BankAccount withdrawAccount = bank.FindAccount(withdrawAccountNumber);

                    if (withdrawAccount != null)
                    {
                        Console.Write("Enter withdrawal amount: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                        if (withdrawAccount.Withdraw(withdrawAmount))
                        {
                            Console.WriteLine("Withdrawal successful. New balance: $" + withdrawAccount.Balance);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found!");
                    }
                    break;

                case 4:
                    Console.Write("Enter account number: ");
                    string balanceAccountNumber = Console.ReadLine();
                    BankAccount balanceAccount = bank.FindAccount(balanceAccountNumber);

                    if (balanceAccount != null)
                    {
                        Console.WriteLine("Account Number: " + balanceAccount.AccountNumber);
                        Console.WriteLine("Account Holder: " + balanceAccount.AccountHolder);
                        Console.WriteLine("Balance: $" + balanceAccount.Balance);
                    }
                    else
                    {
                        Console.WriteLine("Account not found!");
                    }
                    break;

                case 5:
                    exitProgram = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
