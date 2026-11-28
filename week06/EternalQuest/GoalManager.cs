namespace EternalQuest;

/// <summary>Owns the player's goals and score, and handles persistence and progress.</summary>
public sealed class GoalManager
{
    private readonly List<Goal> _goals = new();
    private int _score;

    public int Score => _score;
    public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
    public int CompletedCount => _goals.Count(goal => goal.IsComplete);
    public int Level => 1 + _score / 500;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public int RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count) return 0;
        int earned = _goals[index].RecordEvent();
        _score += earned;
        return earned;
    }

    // Creativity feature: levels and achievement badges turn the running score into visible milestones.
    public IEnumerable<string> GetAchievements()
    {
        if (_score >= 100) yield return "First Century — earn 100 points";
        if (_score >= 500) yield return "Questing Champion — earn 500 points";
        if (CompletedCount >= 1) yield return "First Quest — complete a goal";
        if (CompletedCount >= 5) yield return "Quest Collector — complete 5 goals";
    }

    public void Save(string path)
    {
        var lines = new List<string> { _score.ToString() };
        lines.AddRange(_goals.Select(goal => goal.ToSaveString()));
        File.WriteAllLines(path, lines);
    }

    public void Load(string path)
    {
        if (!File.Exists(path)) throw new FileNotFoundException("Save file was not found.", path);
        string[] lines = File.ReadAllLines(path);
        if (lines.Length == 0 || !int.TryParse(lines[0], out int loadedScore) || loadedScore < 0)
            throw new FormatException("Save file has an invalid score.");

        var loadedGoals = new List<Goal>();
        foreach (string line in lines.Skip(1))
        {
            string[] part = line.Split('|');
            if (part.Length < 5 || !int.TryParse(part[3], out int points) ||
                !bool.TryParse(part[4], out bool complete) || points < 0)
                throw new FormatException("A goal entry in the save file is invalid.");

            switch (part[0])
            {
                case "Simple" when part.Length == 5:
                    loadedGoals.Add(new SimpleGoal(part[1], part[2], points, complete));
                    break;
                case "Eternal" when part.Length == 6 && int.TryParse(part[5], out int times) && times >= 0:
                    loadedGoals.Add(new EternalGoal(part[1], part[2], points, times));
                    break;
                case "Checklist" when part.Length == 8 && int.TryParse(part[5], out int target) &&
                    int.TryParse(part[6], out int bonus) && int.TryParse(part[7], out int count) &&
                    target > 0 && bonus >= 0 && count >= 0 && count <= target:
                    loadedGoals.Add(new ChecklistGoal(part[1], part[2], points, target, bonus, count));
                    break;
                default:
                    throw new FormatException("A goal entry in the save file has an unknown type or invalid data.");
            }
        }

        _goals.Clear();
        _goals.AddRange(loadedGoals);
        _score = loadedScore;
    }
}
