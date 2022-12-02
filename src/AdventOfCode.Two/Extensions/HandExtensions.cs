using System.Diagnostics;
using AdventOfCode.Two.Models;

namespace AdventOfCode.Two;

internal static class HandExtensions
{
    internal static int ToScore(this Hand hand)
        => hand switch
        {
            Hand.Rock => 1,
            Hand.Paper => 2,
            Hand.Scissors => 3,
            _ => throw new UnreachableException()
        };
}