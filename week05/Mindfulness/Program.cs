
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        // Creativity feature:
        // The program tracks completed activities during the current session
        // and displays a summary when the user exits.

        List<string> activityHistory = new List<string>();

        Console.WriteLine("Welcome to the Mindfulness Program!");

        while (choice != 4)
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityHistory.Add("Breathing Activity");
                    break;

                case 2:
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    activityHistory.Add("Reflecting Activity");
                    break;

                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityHistory.Add("Listing Activity");
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program!");

                    Console.WriteLine();
                    Console.WriteLine("Your Session Summary:");
                    Console.WriteLine($"Total activities completed: {activityHistory.Count}");

                    foreach (string activity in activityHistory)
                    {
                        Console.WriteLine($"- {activity}");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Have a wonderful day!");
                    break;

                default:
                    Console.WriteLine("Please select an option between 1 and 4.");
                    break;
            }
        }
    }
}
