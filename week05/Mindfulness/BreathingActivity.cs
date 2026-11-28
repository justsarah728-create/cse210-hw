
using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(Math.Min(4, GetRemainingSeconds(endTime)));

            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountDown(Math.Min(4, GetRemainingSeconds(endTime)));
        }

        DisplayEndingMessage();
    }

    private int GetRemainingSeconds(DateTime endTime)
    {
        return Math.Max(1, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds));
    }
}
