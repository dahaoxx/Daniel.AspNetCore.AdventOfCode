using System.Diagnostics;
using Template.Extensions;
using Template.Models;

namespace Template.Services;

public static class TemplateService
{
    #region Part 1

    public static int Part1(string inputFileName)
    {
        // Get all steps from file
        var steps = GetStepsFromFile(inputFileName);
        var rope = new Rope();

        // Loop through all steps
        foreach (var step in steps)
        {
            // Move H based on Step.Direction
            MoveHead(step, rope);

            var headPosition = rope.Head.Position;
            var tailPosition = rope.Tail.Position;
            
            // Check if H and T is not too far apart
            if (!IsNextKnotTooFarAway(headPosition, tailPosition))
            {
                continue;
            }
            
            MoveCurrentKnotPosition(headPosition, tailPosition);
            
            // Add position to UniquePositionList if unique
            AddUniqueTailPosition(rope, tailPosition);
        }
        
        return rope.Tail.UniquePositionsVisited.Count;
    }

    private static void AddUniqueTailPosition(Rope rope, Position tailPosition)
    {
        if (rope.Tail.UniquePositionsVisited.Any(x => x.X == tailPosition.X && x.Y == tailPosition.Y))
        {
            return;
        }
        
        var position = new Position
        {
            X = tailPosition.X,
            Y = tailPosition.Y,
        };
        rope.Tail.UniquePositionsVisited.Add(position);
    }

    private static void MoveCurrentKnotInSameAxis(bool isInSameYAxis, Position tailPosition, Position headPosition,
        bool isInSameXAxis)
    {
        if (isInSameYAxis)
        {
            var isTailLeftForHead = tailPosition.X < headPosition.X;
            if (isTailLeftForHead)
            {
                tailPosition.X++;
            }
            else
            {
                tailPosition.X--;
            }
        }
        else if (isInSameXAxis)
        {
            var isTailUnderHead = tailPosition.Y < headPosition.Y;
            if (isTailUnderHead)
            {
                tailPosition.Y++;
            }
            else
            {
                tailPosition.Y--;
            }
        }
    }

    #endregion
    
    #region Part 2
    
    public static int Part2(string inputFileName)
    {
        var steps = GetStepsFromFile(inputFileName);
        var rope = new Rope
        {
            IntermediateKnots =
            {
                new Knot { Name = "1"},
                new Knot { Name = "2"},
                new Knot { Name = "3"},
                new Knot { Name = "4"},
                new Knot { Name = "5"},
                new Knot { Name = "6"},
                new Knot { Name = "7"},
                new Knot { Name = "8"},
            }
        };
        
        foreach (var step in steps)
        {
            // Move H based on Step.Direction
            MoveHead(step, rope);

            var nextKnotPosition = rope.Head.Position;
            
            // Check if H and T is too far apart
            foreach (var currentKnotPosition in rope.IntermediateKnots.Select(currentKnot => currentKnot.Position))
            {
                if (IsNextKnotTooFarAway(nextKnotPosition, currentKnotPosition))
                {
                    MoveCurrentKnotPosition(nextKnotPosition, currentKnotPosition);
                }
                nextKnotPosition = currentKnotPosition;
            }

            var tailPosition = rope.Tail.Position;
            if (IsNextKnotTooFarAway(nextKnotPosition, tailPosition))
            {
                MoveCurrentKnotPosition(nextKnotPosition, tailPosition);
                AddUniqueTailPosition(rope, tailPosition);
            }
        }
        
        return rope.Tail.UniquePositionsVisited.Count;
    }

    private static void MoveCurrentKnotPosition(Position nextKnotPosition, Position currentKnotPosition)
    {
        // Check if H and T has a shared axis
        var isInSameYAxis = nextKnotPosition.Y == currentKnotPosition.Y;
        var isInSameXAxis = nextKnotPosition.X == currentKnotPosition.X;
        var isInSameAxis = isInSameXAxis || isInSameYAxis;
        if (isInSameAxis)
        {
            MoveCurrentKnotInSameAxis(isInSameYAxis, currentKnotPosition, nextKnotPosition, isInSameXAxis);
        }
        else // H and T are too far apart diagonally
        {
            MoveCurrentKnotDiagonally(nextKnotPosition, currentKnotPosition);
        }
    }

    #endregion

    #region Helpers
    
    private static void MoveCurrentKnotDiagonally(Position nextKnotPosition, Position currentKnotPosition)
    {
        var isTopTop = nextKnotPosition.Y == currentKnotPosition.Y + 2;
        var isRightRight = nextKnotPosition.X == currentKnotPosition.X + 2;
        var isBotBot = nextKnotPosition.Y == currentKnotPosition.Y - 2;
        var isLeftLeft = nextKnotPosition.X == currentKnotPosition.X - 2;

        var isTop = nextKnotPosition.Y == currentKnotPosition.Y + 1;
        var isRight = nextKnotPosition.X == currentKnotPosition.X + 1;
        var isBot = nextKnotPosition.Y == currentKnotPosition.Y - 1;
        var isLeft = nextKnotPosition.X == currentKnotPosition.X - 1;

        if (IsHeadTopRight(isTopTop, isRight, isTop, isRightRight))
        {
            MoveTailTopRight(currentKnotPosition);
        }

        if (IsHeadBotRight(isBotBot, isRight, isBot, isRightRight))
        {
            MoveTailBotRight(currentKnotPosition);
        }

        if (IsHeadBotLeft(isBotBot, isLeft, isBot, isLeftLeft))
        {
            MoveTailBotLeft(currentKnotPosition);
        }

        if (IsHeadTopLeft(isTopTop, isLeft, isTop, isLeftLeft))
        {
            MoveTailTopLeft(currentKnotPosition);
        }
    }
    
    private static bool IsHeadTopRight(bool isTopTop, bool isRight, bool isTop, bool isRightRight)
    {
        var isTopTopRight = isTopTop && isRight;
        var isTopRightRight = isTop && isRightRight;
        return isTopRightRight || isTopTopRight;
    }

    private static bool IsHeadBotRight(bool isBotBot, bool isRight, bool isBot, bool isRightRight)
    {
        var isBotBotRight = isBotBot && isRight;
        var isBotRightRight = isBot && isRightRight;
        return isBotBotRight || isBotRightRight;
    }

    private static bool IsHeadBotLeft(bool isBotBot, bool isLeft, bool isBot, bool isLeftLeft)
    {
        var isBotBotLeft = isBotBot && isLeft;
        var isBotLeftLeft = isBot && isLeftLeft;
        return isBotBotLeft || isBotLeftLeft;
    }

    private static bool IsHeadTopLeft(bool isTopTop, bool isLeft, bool isTop, bool isLeftLeft)
    {
        var isTopTopLeft = isTopTop && isLeft;
        var isTopLeftLeft = isTop && isLeftLeft;
        return isTopTopLeft || isTopLeftLeft;
    }

    private static void MoveTailTopRight(Position currentKnotPosition)
    {
        currentKnotPosition.X++;
        currentKnotPosition.Y++;
    }

    private static void MoveTailBotRight(Position currentKnotPosition)
    {
        currentKnotPosition.X++;
        currentKnotPosition.Y--;
    }

    private static void MoveTailBotLeft(Position currentKnotPosition)
    {
        currentKnotPosition.X--;
        currentKnotPosition.Y--;
    }

    private static void MoveTailTopLeft(Position currentKnotPosition)
    {
        currentKnotPosition.X--;
        currentKnotPosition.Y++;
    }

    private static bool IsTooFarAwayUp(Position nextKnot, Position currentKnot) 
        => Math.Abs(nextKnot.X - currentKnot.X) > 1;
    
    private static bool IsTooFarAwayInYAxis(Position nextKnot, Position currentKnot) 
        => Math.Abs(nextKnot.Y - currentKnot.Y) > 1;

    private static bool IsNextKnotTooFarAway(Position nextKnot, Position currentKnot) 
        => IsTooFarAwayUp(nextKnot, currentKnot) ||
           IsTooFarAwayInYAxis(nextKnot, currentKnot);

    private static void MoveHead(Step step, Rope rope)
    {
        switch (step.Direction)
        {
            case Direction.Up:
                rope.Head.Position.Y++;
                break;
            case Direction.Right:
                rope.Head.Position.X++;
                break;
            case Direction.Down:
                rope.Head.Position.Y--;
                break;
            case Direction.Left:
                rope.Head.Position.X--;
                break;
            default:
                throw new UnreachableException();
        }
    }

    private static List<Step> GetStepsFromFile(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);

        var stepList = new List<Step>();
        foreach (var line in lines)
        {
            var split = line.Split(" ");
            var direction = split[0].AsDirection();
            var stepsCount = int.Parse(split[1]);

            var i = 0;
            while (i < stepsCount)
            {
                stepList.Add(new Step(direction));
                i++;
            }
        }

        return stepList;
    }

    #endregion
}