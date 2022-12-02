using System.Diagnostics;
using Two.RockPaperScissors.Models;

namespace Two.RockPaperScissors;

internal static class OutcomeExtensions
{
    internal static int ToScore(this Outcome outcome)
        => outcome switch
        {
            Outcome.Win => 6,
            Outcome.Draw => 3,
            Outcome.Loose => 0,
            _ => throw new UnreachableException()
        };
}