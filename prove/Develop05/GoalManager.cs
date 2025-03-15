using System;
using System.IO;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been added yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
    }

    public void RecordGoalProgress(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Try again.");
            return;
        }

        _goals[goalIndex].RecordProgress();
        _totalScore = CalculateTotalScore();
        Console.WriteLine($"New Total Score: {_totalScore} points!");

        SaveGoals("goals.txt");

        DisplayGoals();
    }

    private int CalculateTotalScore()
    {
        int total = 0;
        foreach (Goal goal in _goals)
        {
            total += goal.GetEarnedPoints();
        }
        return total;
    }

    public void DisplayTotalScore()
    {
        Console.WriteLine($"\nTotal Score: {_totalScore} points");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPointsWorth()}|{simpleGoal.IsComplete()}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPointsWorth()}|{checklistGoal.GetTimesCompleted()}|{checklistGoal.GetTargetCount()}|{checklistGoal.GetBonusPoints()}");
                }
                else
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPointsWorth()}");
                }
            }
        }
        Console.WriteLine("Goals saved successfully to " + filename);
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved goals.");
            return;
        }

        _goals.Clear();
        
        using (StreamReader reader = new StreamReader(filename))
        //I used ChatGPT for this part because I kept having errors with saving into my goals.txt. I don't know if I fully understand, but 
        //I think it is checking to make sure there are not more items listed than what was called for, and if there is, it doesn't crash the program.
        //It just keeps going with the ones that are correct. 
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');

                if (parts.Length < 4)
                {
                    Console.WriteLine($"Error");
                    continue;
                }

                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int pointsWorth = int.Parse(parts[3]);

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = parts.Length > 4 && bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, description, pointsWorth, isComplete));
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(name, description, pointsWorth));
                        break;

                    case "ChecklistGoal":
                        if (parts.Length < 7)
                        {
                            Console.WriteLine($"Error");
                            continue;
                        }

                        int timesCompleted = int.Parse(parts[4]);
                        int targetCount = int.Parse(parts[5]);
                        int bonusPoints = int.Parse(parts[6]);

                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, pointsWorth, bonusPoints, targetCount, timesCompleted);
                        _goals.Add(checklistGoal);
                        break;
                }
            }
        }

        _totalScore = CalculateTotalScore();
        Console.WriteLine("Goals loaded successfully!");
        DisplayTotalScore();
        DisplayGoals();
    }
}

