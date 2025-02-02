using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private Prompt prompt = new Prompt();

    public void AddEntry()
    {
        Console.Clear();
        Prompt randomPrompt = new Prompt();
        randomPrompt.Display();
        Console.WriteLine("\nEntry: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(randomPrompt, response);
        entries.Add(newEntry);
        Console.WriteLine("Entry Added\n");
    }

    public void DisplayJournal()
    {
        Console.Clear();
        if (entries.Count == 0)
        {
            Console.WriteLine("No Entries");
        }
        else
        {
            foreach (var entry in entries)
            {
                entry.Display();  
            }
        }
    }

    public void SaveJournalToFile()
    {
        Console.Clear();
        Console.Write("Enter Filename: ");
        string fileName = Console.ReadLine();

        try
        {
        using (StreamWriter writer = new StreamWriter(fileName + ".txt", append: true))
        {
            
            var lastEntry = entries[entries.Count - 1];  
            writer.WriteLine($"{lastEntry.Date.ToShortDateString()}|{lastEntry.Prompt.Text}|{lastEntry.EntryText}");
        }
        Console.WriteLine($"Journal entry saved to {fileName}.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Saving: {ex.Message}");
        }
    }

    public void LoadJournalFromFile()
    {
        Console.Clear();
        Console.Write("Enter Filename: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(fileName + ".txt"))
            {
                entries.Clear();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        DateTime date = DateTime.Parse(parts[0]);
                        string promptText = parts[1];
                        string entryText = parts[2];
                        Prompt loadedPrompt = new Prompt();
                        var loadedEntry = new Entry(loadedPrompt, entryText) { Date = date };
                        entries.Add(loadedEntry);
                    }
                }
            }
            Console.WriteLine("Journal Loaded");
            DisplayJournal();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Loading: {ex.Message}");
        }
    }
}

