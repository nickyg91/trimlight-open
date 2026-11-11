namespace Trimlight.Models.Request;

public record CurrentDate
{
    private readonly DateTime _currentDate = DateTime.UtcNow;
    
    public int Year => int.Parse(_currentDate.ToString("yy"));
    public int Month => _currentDate.Month;
    public int Day => _currentDate.Day;
    public int Weekday => ((int)_currentDate.DayOfWeek) + 1;
    public int Hour => _currentDate.Hour;
    public int Minute => _currentDate.Minute;
    public int Second => _currentDate.Second;
}