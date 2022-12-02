using AdventOfCode.Domain.Contracts;
using AdventOfCode.Domain.Services;
using Xunit;

namespace AdventOfCode.Two.Tests.Unit;

public class ElfFoodServiceTests
{
    private readonly IElfFoodService _sut;

    public ElfFoodServiceTests()
    {
        _sut = new ElfFoodService();
    }

    [Fact]
    public void GetTopThreeCaloriesCount_ShouldReturn45000_WhenInputFromFile1()
    {
        // Arrange
        const string filePath = "MockFiles/Input1.txt";
        
        // Act
        var max = _sut.GetTopThreeCaloriesCount(filePath);
        
        // Assert
        Assert.Equal(45000, max);
    }
    
    [Fact]
    public void GetTopThreeCaloriesCount_ShouldReturn45000_WhenInputFromFile2()
    {
        // Arrange
        const string filePath = "MockFiles/Input2.txt";
        
        // Act
        var max = _sut.GetTopThreeCaloriesCount(filePath);
        
        // Assert
        Assert.Equal(6676, max);
    }
    
    [Fact]
    public void GetTopThreeCaloriesCount_ShouldReturn45000_WhenInputFromFile3()
    {
        // Arrange
        const string filePath = "MockFiles/Input3.txt";
        
        // Act
        var max = _sut.GetTopThreeCaloriesCount(filePath);
        
        // Assert
        Assert.Equal(240000, max);
    }
}