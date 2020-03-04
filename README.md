# Mastermind in C# #
This repository contains my implementation of Mastermind using a simple console application written in C# using .NET Core 3.1.

## Solution Overview
This solution contains two projects:
1. **Mastermind** - The actual game implementation
2. **Mastermind.Tests** - Nowhere near complete test coverage, but used to test some of the core elements of the project.

A simple implementation of the `Swaszek` solver was added more or less for the fun of it.

I had a hard time deciding where to draw the line when it comes to complexity.  Given the position I'm interviewing for I wanted to demonstrate at least a few design patterns.

I did start a more complex version of this project.  You can find it in the `add-mvc` branch.  It is mostly functional, but I ultimately decided it was overly complex for the purpose.

## The Important code
You'll find the main game loop in `Program.Run()`.  It takes care of initializing the `Game` object and running it through to completion:
```
private void Run()
{
    // Let the IoC container take care of injecting the things the Game object
    // needs to run.
    Game game = _container.GetInstance<Game>();

    game.Init();
    game.DisplayRules();

    while (!game.IsOver)
    {
        game.Play();
    }

    game.DisplayResults();

    if (!game.WasSuccessful)
        game.ShowHowItsDone(); // <-- run the Solver

    // Give the user a moment to accept the outcome... for better or worse.
    game.PauseForEffect();
}
```
The next important bit would be where we actually test a guess against a known answer in `Combination.Try(string guess, string answer)`:
```
public GuessResult Try(string guess, string answer)
{
    GuessResult result = new GuessResult();

    // We need to make sure that we successfully handle duplicate digits
    // in the possible answer and guess.  To handle that we add any digits
    // that are not perfect matches to the two lists below.
    List<char> answerValues = new List<char>();
    List<char> guessValues = new List<char>();

    for (int i = 0; i < guess.Length; i++)
    {
        if (answer[i] != guess[i])
        {
            // Not a perfect answer, Add to lists for a later check.
            answerValues.Add(answer[i]);
            guessValues.Add(guess[i]);
        }
        else
            result.ExactlyRight++;
    }

    foreach (char c in guessValues)
    {
        if(answerValues.Contains(c))
        {
            result.SortaRight++;

            // This is how we handle duplicates.  Once we've used up a given
            // digit we remove it from the list of potential answers.
            answerValues.Remove(c);
        }
        else
            result.CompletelyWrong++;
    }

    return result;
}
```
