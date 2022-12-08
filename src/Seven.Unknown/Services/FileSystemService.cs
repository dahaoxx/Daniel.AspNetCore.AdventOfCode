using One.ElfCalories.Exceptions;
using Seven.FileSystem.Enums;
using Seven.FileSystem.Extensions;
using Directory = Seven.FileSystem.Models.Directory;
using File = Seven.FileSystem.Models.File;

namespace Seven.FileSystem.Services;

public sealed class FileSystemService
{
    private readonly Directory _rootDirectory = new("/");
    private readonly List<Directory> _allDirectories;
    private Directory _currentDirectory;

    public FileSystemService(string inputFileName)
    {
        _currentDirectory = _rootDirectory;
        _allDirectories = new List<Directory> {_currentDirectory};
        CreateDirectoryTree(inputFileName);
    }

    #region Part 1

    public int Part1() =>
        _allDirectories
            .Select(uniqueDirectory => uniqueDirectory.TotalFileSizeWithDescendants)
            .Where(totalFileSizeWithDescendants => totalFileSizeWithDescendants <= 100000)
            .Sum();

    #endregion
    
    #region Part 2
    
    public int Part2(int discSize, int totalNeededDiscSpace)
    {
        var usedDiscSpace = _rootDirectory.TotalFileSizeWithDescendants;
        var availableDiscSpace = discSize - usedDiscSpace;
        var neededDiscSpace = totalNeededDiscSpace - availableDiscSpace;

        var deleteCandidates = _allDirectories.Where(x => x.TotalFileSizeWithDescendants > neededDiscSpace);
        var delete = deleteCandidates.OrderBy(x => Math.Abs(neededDiscSpace - x.TotalFileSizeWithDescendants)).First();
        var deleteSize = delete.TotalFileSizeWithDescendants;
        
        return deleteSize;
    }
    
    #endregion

    #region Helper
    
    private void CreateDirectoryTree(string inputFileName)
    {        
        var lines = System.IO.File.ReadAllLines(inputFileName).Skip(1);
        foreach (var line in lines)
        {
            var lineSplit = line.Split(" ").ToList();
            
            var lineType = lineSplit.AsCommandLineType();
            switch (lineType)
            {
                case LineType.Command:
                {
                    HandleCommandInput(lineSplit);
                    continue;
                }
                case LineType.Print:
                {
                    HandlePrintOutput(lineSplit);
                    continue;
                }
                default:
                    throw new ElfIsLyingException();
            }
        }
    }
    
    private void HandleCommandInput(List<string> line)
    {
        var commandType = line.AsCommand();
        switch (commandType)
        {
            case CommandType.ChangeDirectory:
            {
                ChangeDirectory(line);
                return;
            }
            case CommandType.List: // This command is ignored in current implementation
                return;
            default:
                throw new ElfIsLyingException();
        }
    }
    
    private void HandlePrintOutput(List<string> line)
    {
        var printType = line.AsPrint();
        switch (printType)
        {
            case PrintType.Directory:
                AddDirectory(line);
                return;
            case PrintType.File:
                AddFile(line);
                return;
            default:
                throw new ElfIsLyingException();
        }
    }
    

    private void ChangeDirectory(List<string> line)
    {
        var commandType = line.AsChangeDirectoryCommand();
        switch (commandType)
        {
            case ChangeDirectoryCommandType.ToParent:
            {
                ChangeDirectoryToParent();
                return;
            }
            case ChangeDirectoryCommandType.ToChild:
            {
                ChangeDirectoryToChild(line);
                return;
            }
            default:
                throw new ElfIsLyingException();
        }
    }

    private void ChangeDirectoryToChild(List<string> line)
    {
        _currentDirectory = GetTargetDirectory(line)
                            ?? throw new ElfIsLyingException("Trying to cd into a non existing child directory");
    }

    private void ChangeDirectoryToParent()
    {
        _currentDirectory = _currentDirectory.Parent 
                            ?? throw new ElfIsLyingException("Trying to cd to a non existing parent parent");
    }

    private Directory? GetTargetDirectory(List<string> line)
    {
        var directoryName = line[2];
        return _currentDirectory.GetChildByName(directoryName) ?? null;
    }

    private void AddDirectory(List<string> line)
    {
        var directoryName = line[1];
        ThrowIfDirectoryNameIsTaken(directoryName);
        
        var newDirectory = new Directory(directoryName)
        {
            Parent = _currentDirectory
        };
        _currentDirectory.Children.Add(newDirectory);
        _allDirectories.Add(newDirectory);
    }

    private void ThrowIfDirectoryNameIsTaken(string directoryName)
    {
        if (_currentDirectory.HasChildWithName(directoryName))
        {
            throw new ElfIsLyingException($"Trying to create a folder with name: {directoryName}, " +
                                          $"but it already exists in the current directory: {_currentDirectory.Name}");
        }
    }
    
    private void ThrowIfFileNameIsTaken(string fileName)
    {
        if (_currentDirectory.HasFileWithName(fileName))
        {
            throw new ElfIsLyingException($"Trying to create a file with name: {fileName}, " +
                                          $"but it already exists in the current directory: {_currentDirectory.Name}");
        }
    }

    private void AddFile(List<string> line)
    {
        var fileName = line[1];
        ThrowIfFileNameIsTaken(fileName);
        
        var fileSize = int.Parse(line[0]);
        var file = new File(fileSize, fileName);
        _currentDirectory.Files.Add(file);
    }

    #endregion
}