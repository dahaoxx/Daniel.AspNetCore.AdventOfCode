using Two.RockPaperScissors.Services;

const string fileName = "input.txt";

var answerPartOne = RockPaperScissorsService.CalculateScorePart1(fileName);
var answerPartTwo = RockPaperScissorsService.CalculateScorePart2(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");