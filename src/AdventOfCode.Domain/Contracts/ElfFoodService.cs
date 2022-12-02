namespace AdventOfCode.Domain.Contracts;

public interface IElfFoodService
{
    public int GetHighestCaloriesCount(string inputFileName);

    public int GetTopThreeCaloriesCount(string inputFileName);
}