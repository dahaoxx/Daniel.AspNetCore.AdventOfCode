using Three.Rucksack.Models;

namespace Three.Rucksack.Services;

public static class BackpackService
{
    #region Part 1

    public static int CalculateTotalPriority(string inputFileName) =>
        File.ReadAllLines(inputFileName)
            .Select(line => new Backpack(line))
            .Select(backpack => backpack.Priority)
            .Sum();

    #endregion
    
    #region Part 2
    
    public static int CalculateTotalTeamPriority(string inputFileName) =>
        File.ReadAllLines(inputFileName)
            .Select(t => new Backpack(t))
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 3)
            .Select(x => x.Select(v => v.Value))
            .Select(backpackGroup => new ElfTeam(backpackGroup.ToList()))
            .Sum(elfTeam => elfTeam.Priority);

    #endregion
}