using System;

public class Prompt
{
    private string[] prompts = {
        "Who inspired me today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I most grateful for today and why?",
        "Did you try anything new today?",
        "What color do I feel like today?"
    };

     public string Text { get; private set; }

    public Prompt()
    {
        Random rand = new Random();
        int randomIndex = rand.Next(prompts.Length);
        Text = prompts[randomIndex];
    }

    public void Display()
    {
        Console.WriteLine(Text);
    }
}

 
