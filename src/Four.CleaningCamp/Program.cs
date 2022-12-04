using Four.CleaningCamp.Services;

const string fileName = "input.txt";

var answerPartOne = CleaningCampService.GetNumberOfSubsets(fileName);
var answerPartTwo = CleaningCampService.GetNumberOfDuplicateIds(fileName);

Console.WriteLine($"Answer Part 1: {answerPartOne}");
Console.WriteLine($"Answer Part 2: {answerPartTwo}");
