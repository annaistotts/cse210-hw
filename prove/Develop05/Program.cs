using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nGOAL TRACKER");
            goalManager.DisplayTotalScore(); 

            Console.WriteLine("\n1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewGoal(goalManager);
                    break;
                case "2":
                    goalManager.DisplayGoals();
                    break;
                case "3":
                    goalManager.SaveGoals("goals.txt");
                    break;
                case "4":
                    goalManager.LoadGoals("goals.txt");
                    break;
                case "5":
                    RecordProgress(goalManager);
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye! Good luck on your goals!");
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }
        }
    }

    static void AddNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Enter points for completion: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new SimpleGoal(name, description, simplePoints));
                break;

            case "2":
                Console.Write("Enter points per completion: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new EternalGoal(name, description, eternalPoints));
                break;

            case "3":
                Console.Write("Enter points per completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points upon full completion: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter total times needed to complete: ");
                int targetCount = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new ChecklistGoal(name, description, checklistPoints, bonusPoints, targetCount));
                break;

            default:
                Console.WriteLine("Try again.");
                break;
        }
    }

    static void RecordProgress(GoalManager goalManager)
    {
        goalManager.DisplayGoals();
        Console.Write("Enter goal number to record progress: ");

        if (int.TryParse(Console.ReadLine(), out int goalIndex))
        {
            goalManager.RecordGoalProgress(goalIndex - 1);
        }
        else
        {
            Console.WriteLine("Try again.");
        }
    }
}

