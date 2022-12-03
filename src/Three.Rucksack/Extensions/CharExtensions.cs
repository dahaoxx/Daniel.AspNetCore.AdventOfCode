using One.ElfCalories.Exceptions;

namespace Three.Rucksack.Extensions;

public static class CharExtensions
{
    private const int LowerCaseAsciiOffset = 'a';  // => 97
    private const int UpperCaseAsciiOffset = 'A';  // => 65
    
    public static int ToPriority(this char value) =>
        value switch
        {
            >= 'a' and <= 'z' => value - LowerCaseAsciiOffset + 1,
            >= 'A' and <= 'Z' => value - UpperCaseAsciiOffset + 27,
            _ => throw new ElfIsLyingException("Some input is other than a-z and A-Z")
        };
}