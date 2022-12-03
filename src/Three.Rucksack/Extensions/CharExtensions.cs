namespace Three.Rucksack.Extensions;

public static class CharExtensions
{
    public static int ToPriority(this char value)
    {
        var currentAsciiCode = (int) value;
        
        const int aUpperCase = 'A';
        const int zUpperCase = 'Z';
        const int upperCasePriorityOffset = 38;
        if(currentAsciiCode is >= aUpperCase and <= zUpperCase)
        {
            return currentAsciiCode - upperCasePriorityOffset;
        }
        
        const int aLowerCase = 'a';
        const int zLowerCase = 'z';
        const int lowerCasePriorityOffset = 96;
        if (currentAsciiCode is >= aLowerCase and <= zLowerCase)
        {
            return currentAsciiCode - lowerCasePriorityOffset;
        }

        throw new ArgumentException("Value must be of a-z or A-Z");
    }
}