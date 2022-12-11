namespace Template.Models;

public class Tail : Knot
{
    public Tail()
    {
        Name = "Tail";
    }
    
    public List<Position> UniquePositionsVisited { get; set; } = new();
};