namespace EternalQuest;

/// <summary>A goal with a completion target and one bonus awarded at the target.</summary>
public sealed class ChecklistGoal : Goal
{
    private readonly int _targetCount;
    private readonly int _bonus;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = Math.Max(1, targetCount);
        _bonus = Math.Max(0, bonus);
        _currentCount = Math.Clamp(currentCount, 0, _targetCount);
        if (_currentCount >= _targetCount) MarkComplete();
    }

    public int TargetCount => _targetCount;
    public int Bonus => _bonus;
    public int CurrentCount => _currentCount;
    public override string Type => "Checklist";

    public override int RecordEvent()
    {
        if (IsComplete) return 0;
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            MarkComplete();
            return Points + _bonus;
        }
        return Points;
    }

    public override string GetStatus() => $"[{(IsComplete ? "X" : " ")}] ({_currentCount}/{_targetCount})";
    public override string ToSaveString() => $"{Type}|{SaveBase()}|{_targetCount}|{_bonus}|{_currentCount}";
}
