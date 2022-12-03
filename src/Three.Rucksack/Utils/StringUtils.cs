namespace Three.Rucksack.Utils;

public static class StringUtils
{
    public static string GetFistHalf(string input) => input[..(input.Length / 2)];

    public static string GetSecondHalf(string input) => input.Substring(input.Length / 2, input.Length / 2);
}