using AdventOfCode.Two.Services;
using Xunit;

namespace AdventOfCode.Two.Tests.Unit;

public class ElfFoodServiceTests
{
    [Fact]
    public void CalculateScore_ShouldReturn15_WhenInputFromFile1()
    {
        // Arrange
        const string filePath = "MockFiles/Input1.txt";
        
        // Act
        var score = RockPaperScissorsService.CalculateScorePart1(filePath);
        
        // Assert
        Assert.Equal(15, score);
    }
    
    
    [Fact]
    public void CalculateScore_ShouldReturn30_WhenInputFromFile2()
    {
        // Arrange
        const string filePath = "MockFiles/Input2.txt";
        
        // Act
        var score = RockPaperScissorsService.CalculateScorePart1(filePath);
        
        // Assert
        Assert.Equal(30, score);
    }
    
    [Fact]
    public void CalculateScore_ShouldReturn60_WhenInputFromFile3()
    {
        // Arrange
        const string filePath = "MockFiles/Input3.txt";
        
        // Act
        var score = RockPaperScissorsService.CalculateScorePart1(filePath);
        
        // Assert
        Assert.Equal(60, score);
    }
    
    [Fact]
    public void CalculateScoreParTwo_ShouldReturn12_WhenInputFromFile1()
    {
        // Arrange
        const string filePath = "MockFiles/Input1.txt";
        
        // Act
        var score = RockPaperScissorsService.CalculateScorePart2(filePath);
        
        // Assert
        Assert.Equal(12, score);
    }
    
    [Fact]
    public void CalculateScoreParTwo_ShouldReturn24_WhenInputFromFile2()
    {
        // Arrange
        const string filePath = "MockFiles/Input2.txt";
        
        // Act
        var score = RockPaperScissorsService.CalculateScorePart2(filePath);
        
        // Assert
        Assert.Equal(24, score);
    }
    
    [Fact]
    public void CalculateScoreParTwo_ShouldReturn48_WhenInputFromFile3()
    {
        // Arrange
        const string filePath = "MockFiles/Input3.txt";
        
        // Act
        var score = RockPaperScissorsService.CalculateScorePart2(filePath);
        
        // Assert
        Assert.Equal(48, score);
    }
}