
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _responses;

    public ListingActivity()
        : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "What are some things that make you happy?",
            "Who are some of your personal heroes?"
        };

        _responses = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing your answers. Press ENTER after each one.");

        _responses.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");

            int remaining = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds);

            if (remaining <= 0)
                break;

            string response = Console.ReadLine();

            if (response == null)
                break;

            if (!string.IsNullOrWhiteSpace(response))
                _responses.Add(response);
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_responses.Count} items!");
        
        DisplayEndingMessage();
    }
}
