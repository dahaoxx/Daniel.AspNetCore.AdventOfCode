using Template.Enums;
using Template.Extensions;
using Directory = Template.Models.Directory;
using File = Template.Models.File;

namespace Template.Services;

public static class TemplateService
{
    private static readonly Directory RootDirectory = new("/");
    private static Directory _currentDirectory = RootDirectory;
    private static readonly List<Directory> AllDirectories = new() {_currentDirectory};
    
    #region Part 1

    public static int Part1(string inputFileName)
    {
        var lines = System.IO.File.ReadAllLines(inputFileName).Skip(1);

        foreach (var line in lines)
        {
            var lineType = line.AsCommandLineType();
            switch (lineType)
            {
                case LineType.Command:
                {
                    var commandType = line.AsCommand();
                    switch (commandType)
                    {
                        case CommandType.ChangeDirectory:
                        {
                            var cdCommand = line.AsChangeDirectoryCommand();
                            switch (cdCommand)
                            {
                                case ChangeDirectory.ToParent:
                                {
                                    _currentDirectory = _currentDirectory.Parent!;
                                    break;
                                }
                                case ChangeDirectory.ToChild:
                                {
                                    var childDirectory = GetChildDirectory(line);
                                    if (childDirectory is not null)
                                    {
                                        _currentDirectory = childDirectory;
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                        case CommandType.List:
                            continue;
                    }
                    break;
                }
                case LineType.Print:
                {
                    var printType = line.AsPrint();
                    switch (printType)
                    {
                        case PrintType.Directory:
                            AddNewDirectory(line);
                            break;
                        case PrintType.File:
                            AddFileToCurrentDirectory(line);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                }
            }
        }

        var sum = AllDirectories
            .Select(uniqueDirectory => uniqueDirectory.TotalFileSizeWithDescendants)
            .Where(totalFileSizeWithDescendants => totalFileSizeWithDescendants <= 100000)
            .Sum();
        return sum;
    }
    
  

    #endregion
    
    #region Part 2
    
    public static int Part2(string inputFileName)
    {        
        const int discSize = 70000000; // 70 000 000
        const int totalNeededDiscSpace = 30000000; // 30 000 000
        
        var usedDiscSpace = RootDirectory.TotalFileSizeWithDescendants; // 47 052 440
        var availableDiscSpace = discSize - usedDiscSpace; // 22 947 560
        var neededDiscSpace = totalNeededDiscSpace - availableDiscSpace; // 7 052 440

        var deleteCandidates = AllDirectories.Where(x => x.TotalFileSizeWithDescendants > neededDiscSpace);
        var delete = deleteCandidates.OrderBy(x => Math.Abs(neededDiscSpace - x.TotalFileSizeWithDescendants)).First();
        var deleteSize = delete.TotalFileSizeWithDescendants;
        
        return deleteSize;
    }
    
    #endregion

    #region Helper
    private static Directory? GetChildDirectory(string line)
    {
        var directoryName = line.Split(" ")[2];
        return _currentDirectory.GetChildByName(directoryName) ?? null;
    }

    private static void AddNewDirectory(string line)
    {
        var directoryName = line.Split(" ")[1];
        var isDirectoryCreated = _currentDirectory.HasChildWithName(directoryName);
        if (isDirectoryCreated)
        {
            Console.WriteLine("Directory already exists");
        }

        var newDirectory = new Directory(directoryName)
        {
            Parent = _currentDirectory
        };
        _currentDirectory.Children.Add(newDirectory);
        AllDirectories.Add(newDirectory);
    }
    
    private static void AddFileToCurrentDirectory(string line)
    {
        var fileSize = int.Parse(line.Split(" ")[0]);
        var fileName = line.Split(" ")[1];
        var file = new File(fileSize, fileName);
        _currentDirectory.Files.Add(file);
    }

    #endregion
}