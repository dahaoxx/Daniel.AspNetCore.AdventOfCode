using AdventOfCode.Two.Services;

const string fileName = "input.txt";

var answerTwoOne = RockPaperScissorsService.CalculateScorePart1(fileName);
var answerTwoTwo = RockPaperScissorsService.CalculateScorePart2(fileName);

Console.WriteLine($"Answer 2.1: {answerTwoOne}");
Console.WriteLine($"Answer 2.2: {answerTwoTwo}");
