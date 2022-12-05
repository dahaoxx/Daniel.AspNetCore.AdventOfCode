using Five.MovingCrates.Models;

namespace Five.MovingCrates.Services;

public static class TemplateService
{
    #region Part 1

    public static string CrateMover9000(string inputFileName)
    {
        var crateStack = CratesStartingOrder();
        var moveCommands = GetMoveCommands(inputFileName);

        foreach (var moveCommand in moveCommands)
        {   
            MoveCratesWithCrateMover9000(crateStack, moveCommand);
        }
        
        return FirstInEachStackToString(crateStack);
    }

    private static void MoveCratesWithCrateMover9000(IReadOnlyList<Stack<char>> crateStack, MoveCommand moveCommand)
    {
        var targetStack = crateStack[moveCommand.TargetStackIndex];
        var destinationStack = crateStack[moveCommand.DestinationStackIndex];

        for (var i = 0; i < moveCommand.Amount; i++)
        {
            destinationStack.Push(targetStack.Pop());
        }
    }
    
    #endregion
    
    #region Part 2
    
    public static string CrateMover9001(string inputFileName)
    {
        var crateStack = CratesStartingOrder();
        var moveCommands = GetMoveCommands(inputFileName);
        foreach (var moveCommand in moveCommands)
        {
            MoveCratesWithCrateMover9001(crateStack, moveCommand);
        }

        return FirstInEachStackToString(crateStack);
    }

    private static void MoveCratesWithCrateMover9001(IReadOnlyList<Stack<char>> crateStack, MoveCommand moveCommand)
    {
        var targetStack = crateStack[moveCommand.TargetStackIndex];
        var destinationStack = crateStack[moveCommand.DestinationStackIndex];

        var cratesToMove = new Stack<char>();
        for (var i = 0; i < moveCommand.Amount; i++)
        {
            cratesToMove.Push(targetStack.Pop());
        }

        foreach (var crate in cratesToMove)
        {
            destinationStack.Push(crate);
        }
    }
    
    #endregion

    #region Helpers

    private static IEnumerable<MoveCommand> GetMoveCommands(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);
        var moveCommands = lines.Select(x => new MoveCommand(x.Split(" ")));
        return moveCommands;
    }
     
    private static string FirstInEachStackToString(IEnumerable<Stack<char>> crateStack)
        => crateStack.Aggregate("", (current, stack) => current + stack.Pop());

    private static List<Stack<char>> CratesStartingOrder()
        => new()
        {
            new Stack<char>(new List<char> {'B', 'S', 'V', 'Z', 'G', 'P', 'W'}),        // 1
            new Stack<char>(new List<char> {'J', 'V', 'B', 'C', 'Z', 'F'}),             // 2
            new Stack<char>(new List<char> {'V', 'L', 'M', 'H', 'N', 'Z', 'D', 'C'}),   // 3
            new Stack<char>(new List<char> {'L', 'D', 'M', 'Z', 'P', 'F', 'J', 'B'}),   // 4
            new Stack<char>(new List<char> {'V', 'F', 'C', 'G', 'J', 'B', 'Q', 'H'}),   // 5
            new Stack<char>(new List<char> {'G', 'F', 'Q', 'T', 'S', 'L', 'B'}),        // 6
            new Stack<char>(new List<char> {'L', 'G', 'C', 'Z', 'V'}),                  // 7
            new Stack<char>(new List<char> {'N', 'L', 'G'}),                            // 8
            new Stack<char>(new List<char> {'J', 'F', 'H', 'C'}),                       // 9
        };

    #endregion
}