using AdventOfCode.One.Services;

const string fileName = "input.txt";

var answerOneOne = ElfFoodService.GetHighestCaloriesCount(fileName);
var answerOneTwo = ElfFoodService.GetTopThreeCaloriesCount(fileName);

Console.WriteLine($"Answer 1.1: {answerOneOne}");
Console.WriteLine($"Answer 1.2: {answerOneTwo}");
