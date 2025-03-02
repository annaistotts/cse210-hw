using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private string[] _reflectionQuestions;
    private Random _random;

    public ReflectionActivity()
    {
        _activityName = "Reflection";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _random = new Random();
        _reflectionQuestions = new string[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void PerformActivity()
    {
        StartActivity();

        SelectRandomPrompt();

        ShowCountdown(5);  

        AskReflectionQuestions();

        EndActivity();
    }

    private void SelectRandomPrompt()
    {
        string prompt = _reflectionQuestions[_random.Next(_reflectionQuestions.Length)];
        Console.WriteLine($"Prompt: {prompt}");
    }

    private void AskReflectionQuestions()
    {
        int elapsedTime = 0;
        while (elapsedTime < _duration)
        {
            string question = _reflectionQuestions[_random.Next(_reflectionQuestions.Length)];
            Console.WriteLine(question);
            
            ShowCountdown(4); 

            elapsedTime += 4;  
            if (elapsedTime >= _duration)
            {
                break;  
            }
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...");
            Thread.Sleep(1000); 
        }
        Console.WriteLine();  
    }
}

