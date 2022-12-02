using System.Diagnostics;
using Two.RockPaperScissors.Models;

namespace Two.RockPaperScissors.Utils;

internal static class HandUtils
{
    internal static Hand CalculateHandToPlay(Hand elfHand, Outcome indicatedOutcome)
        => elfHand switch
        {
            Hand.Rock => indicatedOutcome switch
            {
                Outcome.Win => Hand.Paper,
                Outcome.Draw => Hand.Rock,
                Outcome.Loose => Hand.Scissors,
                _ => throw new UnreachableException()
            },
            Hand.Paper => indicatedOutcome switch
            {
                Outcome.Win => Hand.Scissors,
                Outcome.Draw => Hand.Paper,
                Outcome.Loose => Hand.Rock,
                _ => throw new UnreachableException()
            },
            Hand.Scissors => indicatedOutcome switch
            {
                Outcome.Win => Hand.Rock,
                Outcome.Draw => Hand.Scissors,
                Outcome.Loose => Hand.Paper,
                _ => throw new UnreachableException()
            },
            _ => throw new UnreachableException()
        };

    internal static Hand GetElfHand(char value)
        => value switch
        {
            'A' => Hand.Rock,
            'B' => Hand.Paper,
            'C' => Hand.Scissors,
            _ => throw new UnreachableException()
        };

    internal static Hand GetOwnHand(char value)
        => value switch
        {
            'X' => Hand.Rock,
            'Y' => Hand.Paper,
            'Z' => Hand.Scissors,
            _ => throw new UnreachableException()
        };

}