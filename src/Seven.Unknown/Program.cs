using Seven.FileSystem.Services;

const string fileName = "input.txt";

var templateService = new FileSystemService(fileName);
var answerPartOne = templateService.Part1();
var answerPartTwo = templateService.Part2(70000000, 30000000);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
