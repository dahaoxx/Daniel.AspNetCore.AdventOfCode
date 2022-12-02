using System.Diagnostics;
using AdventOfCode.Two.Models;

namespace AdventOfCode.Two;

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