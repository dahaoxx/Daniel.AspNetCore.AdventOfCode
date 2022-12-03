using System.Diagnostics;
using Two.RockPaperScissors.Models;

namespace Two.RockPaperScissors.Extensions;

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