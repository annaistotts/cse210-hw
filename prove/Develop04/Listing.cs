using System;
using System.Threading;

public class ListingActivity : Activity
{
    private string _prompt;
    private List<string> _itemsList;
    private Random _random;

    public ListingActivity()
    {
        _activityName = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _random = new Random();
        _itemsList = new List<string>();
    }

    public override void PerformActivity()
    {
        StartActivity();

        SelectRandomPrompt();

        ShowCountdown(5);  

        Console.WriteLine("Start listing things now.");

        int startTime = Environment.TickCount;
        while (Environment.TickCount - startTime < _duration * 1000)
        {
            string userInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                _itemsList.Add(userInput);
            }
        }

        Console.WriteLine($"You listed {_itemsList.Count} items!");
        
        EndActivity();
    }

    private void SelectRandomPrompt()
    {
        string[] prompts = new string[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _prompt = prompts[_random.Next(prompts.Length)];
        Console.WriteLine($"Prompt: {_prompt}");
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{i}...");
            Thread.Sleep(1000); 
        }
    }
}
