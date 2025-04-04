/*using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 4.8),
            new Cycling("04 Nov 2022", 45, 15.0),
            new Swimming("05 Nov 2022", 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

*/
//The commented out code is code for the original program. Below is code for the "exceeding requirements" activity. 
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nACTIVITY TRACKER MENU");
            Console.WriteLine("1. Add Running");
            Console.WriteLine("2. Add Cycling");
            Console.WriteLine("3. Add Swimming");
            Console.WriteLine("4. Show All Summaries");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    activities.Add(CreateRunning());
                    break;
                case "2":
                    activities.Add(CreateCycling());
                    break;
                case "3":
                    activities.Add(CreateSwimming());
                    break;
                case "4":
                    ShowSummaries(activities);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }
        }

        Console.WriteLine("Have a good day!");
    }

    static Running CreateRunning()
    {
        Console.Write("Enter Date (example, 03 Nov 2022): ");
        string date = Console.ReadLine();

        Console.Write("Enter Duration (in minutes): ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter Distance (in km): ");
        double distance = double.Parse(Console.ReadLine());

        return new Running(date, minutes, distance);
    }

    static Cycling CreateCycling()
    {
        Console.Write("Enter Date (example, 03 Nov 2022): ");
        string date = Console.ReadLine();

        Console.Write("Enter Duration (in minutes): ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter Speed (in km/h): ");
        double speed = double.Parse(Console.ReadLine());

        return new Cycling(date, minutes, speed);
    }

    static Swimming CreateSwimming()
    {
        Console.Write("Enter Date (example, 03 Nov 2022): ");
        string date = Console.ReadLine();

        Console.Write("Enter Duration (in minutes): ");
        int minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter Number of Laps: ");
        int laps = int.Parse(Console.ReadLine());

        return new Swimming(date, minutes, laps);
    }

    static void ShowSummaries(List<Activity> activities)
    {
        Console.WriteLine("\nACTIVITY SUMMARIES");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
