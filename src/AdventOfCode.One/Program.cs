using AdventOfCode.One.Services;

const string fileName = "input.txt";
var elfFoodService = new ElfFoodService();
var answerOneOne = elfFoodService.GetHighestCaloriesCount(fileName);
var answerOneTwo = elfFoodService.GetTopThreeCaloriesCount(fileName);

Console.WriteLine($"Answer 1.1: {answerOneOne}");
Console.WriteLine($"Answer 1.2: {answerOneTwo}");
