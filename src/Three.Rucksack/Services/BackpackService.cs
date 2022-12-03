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
            .Select(x => new Backpack(x))
            .Chunk(3)
            .Select(x => new ElfTeam(x.ToList()))
            .Sum(elfTeam => elfTeam.Priority);

    #endregion
}