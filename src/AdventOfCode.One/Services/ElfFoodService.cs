using AdventOfCode.One.Models;

namespace AdventOfCode.One.Services;

public static class ElfFoodService
{
    public static int GetHighestCaloriesCount(string inputFileName) 
        => GetElfCollection(inputFileName)
            .Select(x => x.Sum())
            .Max();

    public static int GetTopThreeCaloriesCount(string inputFileName)
        => GetElfCollection(inputFileName)
            .Select(x => x.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

    private static IEnumerable<ElfFoodCollection> GetElfCollection(string inputFileName)
        => CreateElfCollection(File.ReadAllLines(inputFileName));
    

    private static IEnumerable<ElfFoodCollection> CreateElfCollection(
        IEnumerable<string> lines)
    {
        var elfCollection = new List<ElfFoodCollection> { new() };

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                AddNewElf(elfCollection);
                continue;
            }

            AddToLastElf(elfCollection, line);
        }

        return elfCollection;
    }

    private static void AddNewElf(ICollection<ElfFoodCollection> elfCollection)
    {
        elfCollection.Add(new ElfFoodCollection());
    }

    private static void AddToLastElf(IEnumerable<ElfFoodCollection> elfCollection, string line)
    {
        elfCollection.Last().Add(int.Parse(line));
    }
}