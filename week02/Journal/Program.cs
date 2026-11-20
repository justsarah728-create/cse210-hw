
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: Added a journal statistics feature that counts
        // entries and encourages users to keep journaling.
        // Also added an empty-journal message and file-not-found handling.

        List<string> prompts = new List<string>
        {
            "What was the best part of my day?",
            "Who made me smile today?",
            "What new thing did I learn today?",
            "What am I grateful for today?",
            "What is one thing I could improve tomorrow?",
            "What was the most interesting thing that happened today?",
            "How did I help someone today?",
            "What is one thing I am looking forward to?"
        };

        Random randomGenerator = new Random();
        Journal myJournal = new Journal();

        string choice = "";

        while (choice != "7")
        {
            Console.WriteLine("\n===== MY PERSONAL JOURNAL =====");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Load journal");
            Console.WriteLine("4. Save journal");
            Console.WriteLine("5. View journal statistics");
            Console.WriteLine("6. View a writing reminder");
            Console.WriteLine("7. Quit");

            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                int index = randomGenerator.Next(prompts.Count);
                string prompt = prompts[index];

                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");

                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry(date, prompt, response);

                myJournal.AddEntry(newEntry);

                Console.WriteLine("Your journal entry has been added!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n===== YOUR JOURNAL ENTRIES =====");
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();

                myJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();

                myJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("\n===== JOURNAL STATISTICS =====");
                Console.WriteLine($"Total journal entries: {myJournal.GetEntryCount()}");
            }
            else if (choice == "6")
            {
                Console.WriteLine("\nRemember: Every day has a story worth writing.");
                Console.WriteLine("Take a few minutes to reflect on your day!");
            }
            else if (choice == "7")
            {
                Console.WriteLine("Thank you for using My Personal Journal!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1-7.");
            }
        }
    }
}
