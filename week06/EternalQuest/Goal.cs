namespace EternalQuest;

/// <summary>Shared identity, completion state, and scoring contract for every goal.</summary>
public abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;
    private bool _isComplete;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public bool IsComplete => _isComplete;
    public abstract string Type { get; }

    public abstract int RecordEvent();
    public abstract string ToSaveString();

    protected void MarkComplete() => _isComplete = true;
    protected void SetComplete(bool complete) => _isComplete = complete;
    protected static string Clean(string value) => (value ?? "").Replace("|", "/").Replace("\r", " ").Replace("\n", " ");

    public virtual string GetStatus() => _isComplete ? "[X]" : "[ ]";
    public override string ToString() => $"{GetStatus()} {Name} ({Description})";

    protected string SaveBase() => $"{Clean(_name)}|{Clean(_description)}|{_points}|{_isComplete}";
}
