using Template.Enums;
using Template.Models;

namespace Template.Extensions;

public static class CommandLineExtensions
{
    public static LineType AsCommandLineType(this string line) => line[0] == '$' ? LineType.Command : LineType.Print;

    public static CommandType AsCommand(this string line) =>
        line.Split(" ")[1] switch
        {
            "cd" => CommandType.ChangeDirectory,
            "ls" => CommandType.List,
            _ => throw new ArgumentOutOfRangeException(nameof(line), line, null)
        };
    
    public static PrintType AsPrint(this string line) =>
        line.Split(" ")[0] switch
        {
            "dir" => PrintType.Directory,
             _ => PrintType.File,
        };

    public static ChangeDirectory AsChangeDirectoryCommand(this string line)
        => line.Split(" ")[2] switch
        {
            ".." => ChangeDirectory.ToParent,
            _ => ChangeDirectory.ToChild
        };

}