using AdventOfCode.Domain.Contracts;
using AdventOfCode.Domain.Services;
using Xunit;

namespace AdventOfCode.One.Tests.Unit;

public class ElfFoodServiceTests
{
    private readonly IElfFoodService _sut;

    public ElfFoodServiceTests()
    {
        _sut = new ElfFoodService();
    }

    [Fact]
    public void GetHighestCaloriesCount_ShouldReturn24000_WhenInputFromFile1()
    {
        // Arrange
        const string filePath = "MockFiles/Input1.txt";
        
        // Act
        var max = _sut.GetHighestCaloriesCount(filePath);
        
        // Assert
        Assert.Equal(24000, max);
    }
    
    [Fact]
    public void GetHighestCaloriesCount_ShouldReturn3333_WhenInputFromFile2()
    {
        // Arrange
        const string filePath = "MockFiles/input2.txt";
        
        // Act
        var max = _sut.GetHighestCaloriesCount(filePath);
        
        // Assert
        Assert.Equal(3333, max);
    }
    
    [Fact]
    public void GetHighestCaloriesCount_ShouldReturn110000_WhenInputFromFile2()
    {
        // Arrange
        const string filePath = "MockFiles/input3.txt";
        
        // Act
        var max = _sut.GetHighestCaloriesCount(filePath);
        
        // Assert
        Assert.Equal(110000, max);
    }
}