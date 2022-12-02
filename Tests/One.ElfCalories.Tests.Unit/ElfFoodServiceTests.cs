using One.ElfCalories.Services;
using Xunit;

namespace One.ElfCalories.Tests.Unit;

public class ElfFoodServiceTests
{
    [Theory]
    [InlineData("input1.txt", 24000)]
    [InlineData("input2.txt", 3333)]
    [InlineData("input3.txt", 110000)]
    public void GetHighestCaloriesCount_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"MockFiles/{fileName}";

        // Act
        var actual = ElfFoodService.GetHighestCaloriesCount(filePath);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("input1.txt", 45000)]
    [InlineData("input2.txt", 6676)]
    [InlineData("input3.txt", 240000)]
    public void GetTopThreeCaloriesCount_ShouldExpectedInt0_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"MockFiles/{fileName}";
        
        // Act
        var actual = ElfFoodService.GetTopThreeCaloriesCount(filePath);

        // Assert
        Assert.Equal(expected, actual);
    }
}
