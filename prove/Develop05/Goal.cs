public abstract class Goal
{
    private string _name;
    private string _description;
    private int _pointsWorth;
    private int _earnedPoints; 

    public Goal(string name, string description, int pointsWorth)
    {
        _name = name;
        _description = description;
        _pointsWorth = pointsWorth;
        _earnedPoints = 0;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPointsWorth() => _pointsWorth;
    public int GetEarnedPoints() => _earnedPoints; 

    protected void AddPoints(int points)
    {
        _earnedPoints += points;
    }

    public abstract void RecordProgress();
    public abstract string DisplayStatus();
}
