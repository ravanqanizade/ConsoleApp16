using System;
using System.Collections.Generic;

abstract class Employee
{
    public Guid GUID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public DateOnly StartTime { get; set; }
    public DateOnly EndTime { get; set; }

    public override string ToString()
    {
        return $"GUID: {GUID}\nName: {Name}\nSurname: {Surname}\nAge: {Age}\nPosition: {Position}\nSalary: {Salary}\nStartTime: {StartTime}\nEndTime: {EndTime}";
    }
}

interface IWorker
{
    bool IsWorking { get; set; }
    void Operations();
    void AddOperations();
}

interface IManager : IWorker
{
    void Organize();
    void CalculateSalaries();
}

interface ICio : IManager
{
    void Control();
    void MakeMeeting();
    void DecreasePercentage(string percent);
}

class Worker : Employee, IWorker
{
    public bool IsWorking { get; set; }

    public void Operations()
    {
        Console.WriteLine("Worker is working.");
    }

    public void AddOperations()
    {
        Console.WriteLine("Worker adds operations.");
    }
}

class Manager : Employee, IManager
{
    public bool IsWorking { get; set; }

    public void Operations()
    {
        Console.WriteLine("Manager is working.");
    }

    public void AddOperations()
    {
        Console.WriteLine("Manager adds operations.");
    }

    public void Organize()
    {
        Console.WriteLine("Manager organizes.");
    }

    public void CalculateSalaries()
    {
        Console.WriteLine("Manager calculates salary.");
    }
}

class CEO : Employee, ICio
{
    public bool IsWorking { get; set; }

    public void Operations()
    {
        Console.WriteLine("CEO is working.");
    }

    public void AddOperations()
    {
        Console.WriteLine("CEO adds operations.");
    }

    public void Organize()
    {
        Console.WriteLine("CEO organizes.");
    }

    public void CalculateSalaries()
    {
        Console.WriteLine("CEO calculates salary.");
    }

    public void Control()
    {
        Console.WriteLine("CEO controls.");
    }

    public void MakeMeeting()
    {
        Console.WriteLine("CEO makes a meeting.");
    }

    public void DecreasePercentage(string percent)
    {
        Console.WriteLine($"CEO decreases percentage by %{percent}.");
    }
}

class Client
{
    public Guid GUID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string LiveAddress { get; set; }
    public string WorkAddress { get; set; }
    public string Salary { get; set; }
}

class Credit
{
    public Guid GUID { get; set; }
    public Client Client { get; set; }
    public int Amount { get; set; }
    public double Percent { get; set; }
    public int Months { get; set; }
    public int Payment { get; set; }
}

class Operation
{
    public Guid GUID { get; set; }
    public DateTime DateTime { get; set; }

    public void CreditPayment(Credit credit)
    {
        Console.WriteLine($"Performing credit payment for client {credit.Client.Name} {credit.Client.Surname}");
        Console.WriteLine($"Amount: {credit.Amount} | Monthly Payment: {credit.Payment}");
    }
}

class Bank
{
    public string Name { get; set; }
    public double Budget { get; set; }
    public double Profit { get; private set; }

    private List<Credit> bankCredits = new List<Credit>();

    public Bank(string name, double budget)
    {
        Name = name;
        Budget = budget;
        Profit = 0;
    }

    public void CalculateProfit()
    {
        Profit = Budget * 0.1;
    }

    public void ShowAllCredits()
    {
        Console.WriteLine("All Credits:");
        foreach (var credit in bankCredits)
        {
            Console.WriteLine($"Client: {credit.Client.Name} {credit.Client.Surname}, Amount: {credit.Amount}, Percent: {credit.Percent}, Months: {credit.Months}, Payment: {credit.Payment}");
        }
    }

    public void AddCredit(Credit credit)
    {
        bankCredits.Add(credit);
    }

    public void PayCredit(Client client, int money)
    {
        foreach (var credit in bankCredits)
        {
            if (credit.Client == client)
            {
                Budget -= money;
                credit.Amount -= money;
                CalculateProfit();
                Console.WriteLine($"Payment of {money} made for client {client.Name} {client.Surname}");
                return;
            }
        }
        Console.WriteLine($"Credit not found for client {client.Name} {client.Surname}");
    }

    public void ShowClientCredit(string fullName)
    {
        Console.WriteLine($"Credits for client {fullName}:");
        foreach (var credit in bankCredits)
        {
            if (credit.Client.Name + " " + credit.Client.Surname == fullName)
            {
                Console.WriteLine($"Credit Amount: {credit.Amount}, Percent: {credit.Percent}, Months: {credit.Months}, Payment: {credit.Payment}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank("MyBank", 1000000);

        CEO ceo = new CEO
        {
            GUID = Guid.NewGuid(),
            Name = "Revan",
            Surname = "Qanizade",
            Age = 45,
            Position = "CEO",
            Salary = 10000m,
            StartTime = new DateOnly(2020, 1, 1),
            EndTime = new DateOnly(2025, 12, 31)
        };

        Manager manager = new Manager
        {
            GUID = Guid.NewGuid(),
            Name = "Ibrahim",
            Surname = "Qanizade",
            Age = 35,
            Position = "Manager",
            Salary = 7000m,
            StartTime = new DateOnly(2021, 6, 1),
            EndTime = new DateOnly(2024, 12, 31)
        };

        Worker worker = new Worker
        {
            GUID = Guid.NewGuid(),
            Name = "Zohrab",
            Surname = "Mehsumov",
            Age = 28,
            Position = "Worker",
            Salary = 4000m,
            StartTime = new DateOnly(2023, 2, 15),
            EndTime = new DateOnly(2024, 12, 31)
        };

        Client client1 = new Client
        {
            GUID = Guid.NewGuid(),
            Name = "Bayram",
            Surname = "Qurbanov",
            Age = 30,
            LiveAddress = "Sumqyit Corat",
            WorkAddress = "Baki N.Nerimanov",
            Salary = "5000"
        };

        Client client2 = new Client
        {
            GUID = Guid.NewGuid(),
            Name = "Nicat",
            Surname = "Agazade",
            Age = 42,
            LiveAddress = "Baki Q.Qarayev",
            WorkAddress = "Baku N.Nerimanov",
            Salary = "7000"
        };

        Credit credit1 = new Credit
        {
            GUID = Guid.NewGuid(),
            Client = client1,
            Amount = 10000,
            Percent = 0.05,
            Months = 12,
            Payment = 900
        };

        Credit credit2 = new Credit
        {
            GUID = Guid.NewGuid(),
            Client = client2,
            Amount = 20000,
            Percent = 0.04,
            Months = 24,
            Payment = 1000
        };

        bank.AddCredit(credit1);
        bank.AddCredit(credit2);

        bank.CalculateProfit();
        bank.ShowAllCredits();

        Operation operation = new Operation();
        operation.CreditPayment(credit1);

        Console.WriteLine("\nCEO Information:");
        Console.WriteLine(ceo.ToString());
    }
}
