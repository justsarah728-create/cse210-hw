
using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity: The user can practise with a scripture and choose
        // to hide three new words each time to make memorization easier.

        Reference reference = new Reference("John", 3, 16);

        string text = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}