using System;

string playAgain = "yes";
while (playAgain == "yes")
{
    Random random = new Random();
    int magicNumber = random.Next(1, 101);
    int guess = 0;
    int count = 0;

    while (guess != magicNumber)
    {
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        count++;

        if (guess < magicNumber) Console.WriteLine("Higher");
        else if (guess > magicNumber) Console.WriteLine("Lower");
        else Console.WriteLine("You guessed it!");
    }

    Console.WriteLine($"You guessed {count} times.");
    Console.Write("Would you like to play again? ");
    playAgain = Console.ReadLine().ToLower();
}