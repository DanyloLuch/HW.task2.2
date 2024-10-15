using System;

abstract class Worker
{
    public string Name { get; }
    public string Position { get; }
    public int WorkDay { get; }

    public Worker(string name, string position, int workDay)
    {
        Name = name;
        Position = position;
        WorkDay = workDay;
    }

    public void Call()
    {
        Console.WriteLine($"{Name} is making a call.");
    }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} is writing code.");
    }

    public void Relax()
    {
        Console.WriteLine($"{Name} is relaxing.");
    }

    public abstract void FillWorkDay();
}

class Developer : Worker
{
    public Developer(string name, int workDay) : base(name, "Розробник", workDay) { }
    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }

}

class Manager : Worker
{
    private Random random;
    public Manager(string name, int workDay) : base(name, "Менеджер", workDay) { }

    public override void FillWorkDay()
    {
        int CallTimes = random.Next(1, 11);
        for (int i = 0; i < CallTimes; i++)
        {
            Call();
        }

        int RelaxTimes = random.Next(1, 6);
        for (int i = 0; i < RelaxTimes; i++)
        {
            Relax();
        }
    }
}
class Team
{
    public string Name;

    private List<Worker> workers = new List<Worker>();

    public Team(string name)
    {
        Name = name;
        workers = new List<Worker>();
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
        Console.WriteLine($"{worker.Name} був доданий до команди {Name}.");
    }

    public void TeamInfo()
    {
        Console.WriteLine($"Team {Name}:");
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name);
        }
    }

    public void DetailedTeamInfo()
    {
        Console.WriteLine($"Team {Name}:");
        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay} work days.");
        }
    }

}



class Program
{
    static void Main()
    {
        List<Team> teams = new List<Team>();

        bool addTeam = true;

        while (addTeam)
        {
            Console.Write("Введіть назву команди: ");
            string teamName = Console.ReadLine();
            Team team = new Team(teamName);
            teams.Add(team);

            bool addWorker = true;

            while (addWorker)
            {
                Console.Write("Бажаєте додати співробітника? Напишіть так або ні: ");
                string answer = Console.ReadLine();

                if (answer == "так")
                {
                    Console.Write("Введіть ім'я вашого робітника: ");
                    string name = Console.ReadLine();

                    Console.Write("Яку посаду він займає? Напишіть менеджер чи розробник: ");
                    string position = Console.ReadLine();

                    Console.Write("Скільки годин приділяє роботі? Напишіть кількість годин: ");
                    int workDay = int.Parse(Console.ReadLine());
                    if (position.ToLower() == "розробник")
                    {
                        Developer developer = new Developer(name, workDay);
                        team.AddWorker(developer);
                    }
                    else if (position.ToLower() == "менеджер")
                    {
                        Manager manager = new Manager(name, workDay);
                        team.AddWorker(manager);
                    }
                    else
                    {
                        Console.WriteLine("Введена некоректна інформація");
                    }
                }
                else if (answer == "ні")
                {
                    addWorker = false;
                }

                Console.Write("Бажаєте додати ще співробітника в цій команді? Якщо так, то введіть +, якщо ні, то - : ");
                string answer3 = Console.ReadLine();
                if (answer3 != "+")
                {
                    addWorker = false;
                }
            }

            Console.Write("Бажаєте додати ще команду? Якщо так, то введіть +, якщо ні, то - : ");
            string answer4 = Console.ReadLine();
            if (answer4 != "+")
            {
                addTeam = false;
            }
        }

        Console.Write("Бажаєте отримати детальну інформацію? Напишіть так або ні: ");
        string answer2 = Console.ReadLine();
        if (answer2 == "так")
        {
            foreach (var team in teams)
            {
                team.DetailedTeamInfo();
            }
        }
    }
}

