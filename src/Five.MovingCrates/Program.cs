using Five.MovingCrates.Services;

const string fileName = "input.txt";

var answerPartOne = TemplateService.CrateMover9000(fileName);
var answerPartTwo = TemplateService.CrateMover9001(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
