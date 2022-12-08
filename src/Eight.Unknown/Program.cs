using Eight.TreeHouse.Services;

const string fileName = "input.txt";

var answerPartOne = TreeHouseService.GetNumberOfVisibleTrees(fileName);
var answerPartTwo = TreeHouseService.GetMaximumScenicScore(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
