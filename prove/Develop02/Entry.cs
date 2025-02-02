using System;

public class Entry
{
    public DateTime Date { get; set; }
    public Prompt Prompt { get; set; }
    public string EntryText { get; set; }

    public Entry(Prompt prompt, string entryText)
    {
        Date = DateTime.Now;  
        Prompt = prompt;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine($"Prompt: {Prompt.Text}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine(); 
    }
}

