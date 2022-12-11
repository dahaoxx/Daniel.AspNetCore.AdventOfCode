namespace Template.Models;

public record Rope
{
    public Rope()
    {
        Tail.UniquePositionsVisited.Add(new Position());
    }
    public Head Head { get; set; } = new();
    public Tail Tail { get; set; } = new();
}