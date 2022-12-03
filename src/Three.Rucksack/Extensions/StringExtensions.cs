namespace Three.Rucksack.Extensions;

public static class StringExtensions
{
    public static string FistHalf(this string input) => input[..(input.Length / 2)];

    public static string SecondHalf(this string input)
    {
        var halfLenght = input.Length / 2;
        return input.Substring(halfLenght, halfLenght);
    }
}