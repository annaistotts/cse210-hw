public class ChecklistGoal : Goal
{
    private int _pointsPerCompletion;
    private int _bonusPoints;
    private int _targetCount;
    private int _timesCompleted;

    public ChecklistGoal(string name, string description, int pointsPerCompletion, int bonusPoints, int targetCount, int timesCompleted = 0) 
        : base(name, description, pointsPerCompletion)
    {
        _pointsPerCompletion = pointsPerCompletion;
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _timesCompleted = timesCompleted;
    }

    public int GetTimesCompleted() => _timesCompleted;
    public int GetTargetCount() => _targetCount;
    public int GetBonusPoints() => _bonusPoints;
    public void SetTimesCompleted(int times) => _timesCompleted = times;

    public override void RecordProgress()
    {
        if (_timesCompleted < _targetCount)
        {
            _timesCompleted++;
            AddPoints(_pointsPerCompletion);
            Console.WriteLine($"Progress recorded for '{GetName()}'. ({_timesCompleted}/{_targetCount})");

            if (_timesCompleted == _targetCount)
            {
                AddPoints(_bonusPoints);
                Console.WriteLine($"Completed! Bonus {_bonusPoints} points awarded!");
            }
        }
        else
        {
            Console.WriteLine($"'{GetName()}' is already completed.");
        }
    }

    public override string DisplayStatus()
    {
        return _timesCompleted >= _targetCount
            ? $"✅ {GetName()} - {GetDescription()} ({GetPointsWorth()} Points) (Completed {_timesCompleted}/{_targetCount})"
            : $"⬜ {GetName()} - {GetDescription()} ({GetPointsWorth()} Points) (Completed {_timesCompleted}/{_targetCount})";
    }

    public bool IsComplete()
    {
        return _timesCompleted >= _targetCount;
    }
}



