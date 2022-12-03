namespace Three.Rucksack.Extensions;

public static class CharExtensions
{
    public static int ToPriority(this char value)
    {
        var currentAsciiCode = (int) value;
        
        const int aUpperCase = 'A';
        const int zUpperCase = 'Z';
        const int upperCaseAsciiOffset = zUpperCase + 27;
        if(currentAsciiCode is >= aUpperCase and <= zUpperCase)
        {
            return currentAsciiCode - upperCaseAsciiOffset;
        }
        
        const int aLowerCase = 'a';
        const int zLowerCase = 'z';
        const int lowerCaseAsciiOffset = zLowerCase + 1;
        if (currentAsciiCode is >= aLowerCase and <= zLowerCase)
        {
            return currentAsciiCode - lowerCaseAsciiOffset;
        }

        throw new ArgumentException("Value must be of a-z or A-Z");
    }
}