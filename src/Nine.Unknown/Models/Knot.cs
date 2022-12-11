namespace Template.Models;

public class Knot
{
    public string Name { get; set; } = string.Empty;
    public Position Position { get; } = new();
}