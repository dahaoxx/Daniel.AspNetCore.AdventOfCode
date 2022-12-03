using Four.Unknown.Models;
using Four.Unknown.Services;

const string fileName = "input.txt";

var answerPartOne = TemplateService.Part1(fileName);
var answerPartTwo = TemplateService.Part2(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
