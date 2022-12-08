using One.ElfCalories.Exceptions;
using Template.Enums;
using Template.Models;

namespace Template.Extensions;

public static class CommandLineExtensions
{
    public static LineType AsCommandLineType(this List<string> line) 
        => line[0] == "$" ? LineType.Command : LineType.Print;

    public static CommandType AsCommand(this List<string> line) 
        => line[1] switch
        {
            "cd" => CommandType.ChangeDirectory,
            "ls" => CommandType.List,
            _ => throw new ElfIsLyingException("Unknown command type")
        };
    
    public static PrintType AsPrint(this List<string> line) 
        => line[0] switch
        {
            "dir" => PrintType.Directory,
             _ => PrintType.File,
        };

    public static ChangeDirectoryCommandType AsChangeDirectoryCommand(this List<string> line)
        => line[2] switch
        {
            ".." => ChangeDirectoryCommandType.ToParent,
            _ => ChangeDirectoryCommandType.ToChild
        };

}