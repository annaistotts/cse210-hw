using System;
using System.Threading;

public abstract class Activity
{
    // I had these strings as private and was having problems with the other classes. ChatGPT recommended using protected strings.
    // I also know I could have used getters and setters to access it if it was private but that required a lot of code. 
    // This method simplified things. 
    protected string _activityName;
    protected string _description;
    protected int _duration;

    private void ShowStartingMessage()
    {
        Console.WriteLine($"{_activityName} Activity");
        Console.WriteLine($"{_description}");
    }

    private void GetDurationFromUser()
    {
        Console.WriteLine("Please enter the duration for this activity in seconds:");
        _duration = int.Parse(Console.ReadLine());
    }

    private void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        ShowAnimation();
        Thread.Sleep(2000); 
        Console.WriteLine("Starting now...");
    }

// I also received help here from ChatGPT. 
    private void ShowAnimation()
    {
        for (int i = 0; i < 3; i++) 
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    private void ShowEndingMessage()
    {
        Console.WriteLine("Great job! You completed the activity.");
        ShowAnimation();
    }

    public void StartActivity()
    {
        ShowStartingMessage();
        GetDurationFromUser();
        PrepareToBegin();
    }

    public void EndActivity()
    {
        ShowEndingMessage();
        Thread.Sleep(2000); 
        Console.WriteLine($"You completed the {_activityName} activity!");
        Console.WriteLine($"Duration: {_duration} seconds.");
    }

    public abstract void PerformActivity();
}
