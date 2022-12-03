using Three.Rucksack.Extensions;
using Three.Rucksack.Models;
using Three.Rucksack.Services;
using Xunit;

namespace Tree.Rucksack.Tests.Unit;

public class RucksackTests
{
    private const string MockFolderName = "MockFiles";
    
    [Theory]
    [InlineData("input1.txt", 157)]
    [InlineData("input2.txt", 93)]
    public void Part1_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"{MockFolderName}/{fileName}";
        
        // Act
        var actual = BackpackService.CalculateTotalPriority(filePath);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("input1.txt", 70)]
    public void CalculateTotalTeamPriority_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"{MockFolderName}/{fileName}";
    
        // Act
        var actual = BackpackService.CalculateTotalTeamPriority(filePath);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData('a', 1)]
    [InlineData('k', 11)]
    [InlineData('y', 25)]
    [InlineData('z', 26)]
    [InlineData('A', 27)]
    [InlineData('F', 32)]
    [InlineData('K', 37)]
    [InlineData('L', 38)]
    [InlineData('Y', 51)]
    [InlineData('Z', 52)]
    public void ToPriority_ShouldReturnExpectedInt_WhenInputFromArgument(char value, int expected)
    {
        // Arrange

        // Act
        var actual = value.ToPriority();
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p')]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L')]
    [InlineData("PmmdzqPrVvPwwTWBwg", 'P')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v')]
    [InlineData("ttgJtRGJQctTZtZT", 't')]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's')]
    [InlineData("ABAC", 'A')]
    [InlineData("aAaB", 'a')]
    public void GetDiff_ShouldReturnExpectedChar_WhenInputFromArgument(string input, char expected)
    {
        // Arrange
        var backpack = new Backpack(input);
            
        // Act
        var actual = backpack.CompartmentsDiff();
        
        // Assert
        Assert.Equal(expected, actual);
    }
}