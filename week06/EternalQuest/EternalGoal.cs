namespace EternalQuest;

/// <summary>A repeatable goal that awards points every time it is recorded.</summary>
public sealed class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points) => _timesRecorded = timesRecorded;

    public int TimesRecorded => _timesRecorded;
    public override string Type => "Eternal";

    public override int RecordEvent()
    {
        _timesRecorded++;
        return Points;
    }

    public override string GetStatus() => $"[∞] ({_timesRecorded} times)";
    public override string ToSaveString() => $"{Type}|{SaveBase()}|{_timesRecorded}";
}
