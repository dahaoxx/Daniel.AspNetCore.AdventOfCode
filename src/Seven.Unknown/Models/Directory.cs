namespace Template.Models;

public record Directory(string Name)
{
    public Directory? Parent { get; init; }
    public List<Directory> Children { get; } = new();
    public List<File> Files { get; } = new();

    public int TotalFileSizeWithDescendants
        => TotalFileSize + TotalFileSizeInDescendants;
           

    public bool HasChildWithName(string directoryName) => Children.Any(x => x.Name == directoryName);
    public bool HasFileWithName(string fileName) => Files.Any(x => x.Name == fileName);
    public Directory? GetChildByName(string directoryName) => Children.FirstOrDefault(x => x.Name == directoryName);
    private int TotalFileSize => Files.Select(x => x.Size).Sum();
    private int TotalFileSizeInDescendants => Children.Select(x => x.TotalFileSizeWithDescendants).Sum();
}