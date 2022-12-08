namespace Template.Models;

public record Directory(string Name)
{
    public Directory? Parent { get; set; }
    public List<Directory> Children { get; } = new();
    public List<File> Files { get; } = new();

    public int TotalFileSizeWithDescendants
        => TotalFileSize + TotalFileSizeInDescendants;
           

    public bool HasChildWithName(string directoryName) => Children.Any(x => x.Name == directoryName);
    public Directory? GetChildByName(string directoryName) => Children.FirstOrDefault(x => x.Name == directoryName);
    private int TotalFileSize => Files.Select(x => x.Size).Sum();
    private int TotalFileSizeInDescendants => Children.Select(x => x.TotalFileSizeWithDescendants).Sum();
}