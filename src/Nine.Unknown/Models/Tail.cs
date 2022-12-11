namespace Template.Models;

public record Tail
{
    public Position Position { get; set; } = new();
    public List<Position> UniquePositionsVisited { get; set; } = new();
};