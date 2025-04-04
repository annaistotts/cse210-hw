abstract class Activity
// Using km, kph, and min per km
{
    private string _date;
    private int _lengthInMinutes;

    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public int GetLength() => _lengthInMinutes;
    public string GetDate() => _date;

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();     

    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_lengthInMinutes} min): " +
               $"Distance {GetDistance():0.0} km, " +
               $"Speed {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.00} min per km";
    }
}
