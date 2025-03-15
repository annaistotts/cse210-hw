public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int pointsPerCompletion)
        : base(name, description, pointsPerCompletion)
    {
        _timesRecorded = 0;
    }

    public override void RecordProgress()
    {
        AddPoints(GetPointsWorth()); 
        _timesRecorded++;
        Console.WriteLine($"Progress recorded for '{GetName()}'. You've earned {GetPointsWorth()} points! ({_timesRecorded} times)");
    }

    public override string DisplayStatus()
    {
        return $"🔄 {GetName()} - {GetDescription()} ({GetPointsWorth()} Points) (Recorded {_timesRecorded} times)";
    }
}
