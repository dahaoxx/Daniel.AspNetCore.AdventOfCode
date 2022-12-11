using System.Diagnostics;
using Template.Models;

namespace Template.Extensions;

public static class StringExtensions
{
    public static Direction AsDirection(this string input)
        => input switch
        {
            "U" => Direction.Up,
            "R" => Direction.Right,
            "D" => Direction.Down,
            "L" => Direction.Left,
            _ => throw new UnreachableException()
        };

}