public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int pointsWorth, bool isComplete = false)
        : base(name, description, pointsWorth)
    {
        _isComplete = isComplete;
    }

    public override void RecordProgress()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            AddPoints(GetPointsWorth());
            Console.WriteLine($"Goal '{GetName()}' completed! You earned {GetPointsWorth()} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{GetName()}' is already completed.");
        }
    }

    public override string DisplayStatus()
    {
        return _isComplete
            ? $"✅ {GetName()} - {GetDescription()} ({GetPointsWorth()} Points) (Completed)"
            : $"⬜ {GetName()} - {GetDescription()} ({GetPointsWorth()} Points)";
    }

    public bool IsComplete() => _isComplete;
}



