using One.ElfCalories.Services;

const string fileName = "input.txt";

var answerPartOne = ElfFoodService.GetHighestCaloriesCount(fileName);
var answerPartTwo = ElfFoodService.GetTopThreeCaloriesCount(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
