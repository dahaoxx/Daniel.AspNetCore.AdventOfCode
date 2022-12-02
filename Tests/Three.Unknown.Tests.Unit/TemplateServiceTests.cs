using Template.Services;
using Xunit;

namespace Tree.Unknown.Tests.Unit;

public class TemplateServiceTests
{
    private const string MockFolderName = "MockFiles";
    
    [Theory]
    [InlineData("input1.txt", 0)]
    [InlineData("input2.txt", 0)]
    [InlineData("input3.txt", 0)]
    public void Part1_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"{MockFolderName}/{fileName}";
        
        // Act
        var actual = TemplateService.Part1(filePath);
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("input1.txt", 0)]
    [InlineData("input2.txt", 0)]
    [InlineData("input3.txt", 0)]
    public void Part2_ShouldReturnExpectedInt_WhenInputFromFileName(string fileName, int expected)
    {
        // Arrange
        var filePath = $"{MockFolderName}/{fileName}";

        // Act
        var actual = TemplateService.Part2(filePath);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}