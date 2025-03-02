using System;
using System.Threading;

public class BreathingActivity : Activity
{
    private int _breathInDuration = 4;  
    private int _breathOutDuration = 6; 

    public BreathingActivity()
    {
        _activityName = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void PerformActivity()
    {
        StartActivity();

        Console.WriteLine("Breathe in...");
        ShowCountdown(_breathInDuration); 

        Console.WriteLine("Breathe out...");
        ShowCountdown(_breathOutDuration); 

        int cycles = _duration / (_breathInDuration + _breathOutDuration); 
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(_breathInDuration); 
            Console.WriteLine("Breathe out...");
            ShowCountdown(_breathOutDuration); 
        }

        
        EndActivity();
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
