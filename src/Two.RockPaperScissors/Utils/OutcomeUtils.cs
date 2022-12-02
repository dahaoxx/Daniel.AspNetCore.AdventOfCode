using System.Diagnostics;
using Two.RockPaperScissors.Models;

namespace Two.RockPaperScissors.Utils;

internal static class OutcomeUtils
{
    internal static Outcome CalculateRoundOutcome(Hand elfHand, Hand ownHand) =>
        elfHand switch
        {
            Hand.Rock => ownHand switch
            {
                Hand.Rock => Outcome.Draw,
                Hand.Paper => Outcome.Win,
                Hand.Scissors => Outcome.Loose,
                _ => throw new UnreachableException()
            },
            Hand.Paper => ownHand switch
            {
                Hand.Rock => Outcome.Loose,
                Hand.Paper => Outcome.Draw,
                Hand.Scissors => Outcome.Win,
                _ => throw new UnreachableException()
            },
            Hand.Scissors => ownHand switch
            {
                Hand.Rock => Outcome.Win,
                Hand.Paper => Outcome.Loose,
                Hand.Scissors => Outcome.Draw,
                _ => throw new UnreachableException()
            },
            _ => throw new UnreachableException()
        };
    
    
    internal static Outcome GetIndicatedOutcome(char value)
        => value switch
        {
            'X' => Outcome.Loose,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Win,
            _ => throw new UnreachableException()
        };
}