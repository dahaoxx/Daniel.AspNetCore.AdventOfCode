namespace Four.CleaningCamp.Services;

public static class CleaningCampService
{
    #region Part 1

    public static int GetNumberOfSubsets(string inputFileName)
    {
        var elfPairs = GetElfPairsFromFile(inputFileName);

        var numberOfSubsets = 0;
        foreach (var elfPair in elfPairs)
        {
            var (elfOneIds, elfTwoIds) = GetElfIds(elfPair);
            if (IsSubsetOfOtherList(elfOneIds, elfTwoIds))
            {
                numberOfSubsets++;
            }
            
        }

        return numberOfSubsets;
    }
    
    private static bool IsSubsetOfOtherList(ICollection<int> list1, ICollection<int> list2) 
        => list1.All(list2.Contains) || list2.All(list1.Contains);


    #endregion
    
    #region Part 2
    
    public static int GetNumberOfDuplicateIds(string inputFileName)
    {
        var elfPairs = GetElfPairsFromFile(inputFileName);
        
        var numberOfDuplicateIds = 0;
        foreach (var elfPair in elfPairs)
        {
            var (elfOneIds, elfTwoIds) = GetElfIds(elfPair);
            if (IsIdsDuplicated(elfOneIds, elfTwoIds))
            {
                numberOfDuplicateIds++;
            }
        }

        return numberOfDuplicateIds;
    }

    private static bool IsIdsDuplicated(IEnumerable<int> list1, IEnumerable<int> list2)
        => list1.Select(x => x).Intersect(list2).Any();
    
    #endregion
    
    #region Helpers

    private static IEnumerable<string[]> GetElfPairsFromFile(string fileName) 
        => File.ReadAllLines(fileName)
            .Select(elfPairLine => elfPairLine.Split(","));

    private static (List<int> elfOneIds, List<int> elfTwoIds) GetElfIds(IReadOnlyList<string> elfPair)
    {
        var (elfOnePerimeter, elfTwoPerimeter) = GetElfPairIdPerimeters(elfPair);

        return (GetAllIdsInPerimeter(elfOnePerimeter),  GetAllIdsInPerimeter(elfTwoPerimeter));
    }
    
    private static (string[] ElfOnePerimeter, string[] ElfTwoPerimeter) GetElfPairIdPerimeters(IReadOnlyList<string> elfPair)
    {
        return (elfPair[0].Split("-"), elfPair[1].Split("-") );
    }

    private static List<int> GetAllIdsInPerimeter(IReadOnlyList<string> elf)
    {
        var firstId = int.Parse(elf[0]);
        var lastId = int.Parse(elf[1]);
        var idRange = Enumerable.Range(firstId, lastId - firstId + 1).ToList();
        return idRange;
   
    }
    
    #endregion

}