using AdventOfCode.Domain.Services;

const string fileName = "input.txt";
var elfFoodService = new ElfFoodService();
var answerDayTwo = elfFoodService.GetTopThreeCaloriesCount(fileName);

Console.WriteLine($"Answer Day Two: {answerDayTwo}");