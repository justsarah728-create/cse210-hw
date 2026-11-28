namespace EternalQuest;

internal static class Program
{
    private const string DefaultSaveFile = "eternal-quest-save.txt";

    private static void Main()
    {
        var manager = new GoalManager();
        Console.WriteLine("Welcome to Eternal Quest!");
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nScore: {manager.Score} | Level: {manager.Level} | Goals completed: {manager.CompletedCount}");
            Console.WriteLine("1. Create new goal\n2. List goals\n3. Record goal event\n4. Save goals\n5. Load goals\n6. View achievements\n7. Quit");
            Console.Write("Choose an option: ");
            switch (Console.ReadLine()?.Trim())
            {
                case "1": CreateGoal(manager); break;
                case "2": ListGoals(manager); break;
                case "3": RecordEvent(manager); break;
                case "4": Save(manager); break;
                case "5": Load(manager); break;
                case "6": ShowAchievements(manager); break;
                case "7": running = false; break;
                default: Console.WriteLine("Please choose a number from 1 to 7."); break;
            }
        }
        Console.WriteLine("Keep going on your quests!");
    }

    private static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Goal type: 1. Simple  2. Eternal  3. Checklist");
        string? type = ReadRequired("Choose a type: ");
        if (type is not ("1" or "2" or "3")) { Console.WriteLine("Unknown goal type."); return; }
        string name = ReadRequired("Goal name: ")!;
        string description = ReadRequired("Description: ")!;
        int points = ReadInt("Points per event: ", 0);
        Goal goal = type switch
        {
            "1" => new SimpleGoal(name, description, points),
            "2" => new EternalGoal(name, description, points),
            _ => new ChecklistGoal(name, description, points,
                ReadInt("How many times to complete it? ", 1), ReadInt("Bonus points at completion: ", 0))
        };
        manager.AddGoal(goal);
        Console.WriteLine("Goal added.");
    }

    private static void ListGoals(GoalManager manager)
    {
        if (manager.Goals.Count == 0) { Console.WriteLine("No goals yet. Create one to get started."); return; }
        for (int i = 0; i < manager.Goals.Count; i++)
            Console.WriteLine($"{i + 1}. {manager.Goals[i]} — {manager.Goals[i].Points} points");
    }

    private static void RecordEvent(GoalManager manager)
    {
        if (manager.Goals.Count == 0) { Console.WriteLine("Add a goal before recording an event."); return; }
        ListGoals(manager);
        int choice = ReadInt("Which goal did you work on? ", 1);
        if (choice > manager.Goals.Count) { Console.WriteLine("That goal number does not exist."); return; }
        int previousLevel = manager.Level;
        int earned = manager.RecordEvent(choice - 1);
        if (earned == 0) { Console.WriteLine("That goal is already complete."); return; }
        Console.WriteLine($"Great work! You earned {earned} points. Total score: {manager.Score}.");
        if (manager.Level > previousLevel) Console.WriteLine($"Level up! You reached level {manager.Level}!");
    }

    private static void Save(GoalManager manager)
    {
        string path = ReadOptional("Save file name (Enter for eternal-quest-save.txt): ", DefaultSaveFile);
        try { manager.Save(path); Console.WriteLine($"Progress saved to {Path.GetFullPath(path)}."); }
        catch (IOException ex) { Console.WriteLine($"Could not save: {ex.Message}"); }
    }

    private static void Load(GoalManager manager)
    {
        string path = ReadOptional("Save file name (Enter for eternal-quest-save.txt): ", DefaultSaveFile);
        try { manager.Load(path); Console.WriteLine("Progress loaded successfully."); }
        catch (Exception ex) when (ex is IOException or FormatException)
        { Console.WriteLine($"Could not load progress: {ex.Message}"); }
    }

    private static void ShowAchievements(GoalManager manager)
    {
        Console.WriteLine($"Level {manager.Level} — {manager.Score % 500}/500 points toward the next level.");
        string[] achievements = manager.GetAchievements().ToArray();
        if (achievements.Length == 0) Console.WriteLine("No badges yet. Keep questing!");
        else foreach (string badge in achievements) Console.WriteLine($"★ {badge}");
    }

    private static string? ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? value = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(value) && !value.Contains('|')) return value;
            Console.WriteLine("Please enter a value without the | character.");
        }
    }

    private static string ReadOptional(string prompt, string fallback)
    {
        Console.Write(prompt);
        string? value = Console.ReadLine()?.Trim();
        return string.IsNullOrWhiteSpace(value) ? fallback : value;
    }

    private static int ReadInt(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= minimum) return value;
            Console.WriteLine($"Enter a whole number that is at least {minimum}.");
        }
    }
}
