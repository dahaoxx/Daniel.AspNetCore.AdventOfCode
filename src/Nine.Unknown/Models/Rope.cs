namespace Template.Models;

public record Rope
{
    public Rope()
    {
        Tail.UniquePositionsVisited.Add(new Position()); // Add start position
    }
    public Head Head { get; set; } = new();
    public List<Knot> IntermediateKnots { get; set; } = new();
    public Tail Tail { get; set; } = new();
}