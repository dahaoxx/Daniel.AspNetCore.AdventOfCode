using AdventOfCode.Two.Services;
using Xunit;

namespace AdventOfCode.Two.Tests.Unit;

public class ElfFoodServiceTests
{
    [Theory]
    [InlineData("input1.txt", 15)]
    [InlineData("input2.txt", 30)]
    [InlineData("input3.txt", 60)]
    public void CalculateScore_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"MockFiles/{fileName}";
        
        // Act
        var actual = RockPaperScissorsService.CalculateScorePart1(filePath);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("input1.txt", 12)]
    [InlineData("input2.txt", 24)]
    [InlineData("input3.txt", 48)]
    public void CalculateScoreParTwo_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"MockFiles/{fileName}";
        
        // Act
        var actual = RockPaperScissorsService.CalculateScorePart2(filePath);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}