using Three.Rucksack.Services;

const string fileName = "input.txt";

var answerPartOne = BackpackService.CalculateTotalPriority(fileName);
var answerPartTwo = BackpackService.CalculateTotalTeamPriority(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
