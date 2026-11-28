namespace EternalQuest;

/// <summary>A one-time goal that awards points only on its first completion.</summary>
public sealed class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points) => SetComplete(isComplete);

    public override string Type => "Simple";

    public override int RecordEvent()
    {
        if (IsComplete) return 0;
        MarkComplete();
        return Points;
    }

    public override string ToSaveString() => $"{Type}|{SaveBase()}";
}
