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

            // Check if H and T has same X or Y, but too far away
            var headPosition = rope.Head.Position;
            var tailPosition = rope.Tail.Position;
            
            var isHeadTooFarAway = IsHeadTooFarAway(headPosition, tailPosition);
            if (!isHeadTooFarAway)
            {
                continue;
            }
            
            var isInSameYAxis = headPosition.Y == tailPosition.Y;
            var isInSameXAxis = headPosition.X == tailPosition.X;
            var isInSameAxis = isInSameXAxis || isInSameYAxis;
            if (isInSameAxis)
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
                } else if (isInSameXAxis)
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
            else
            {
                var isTopTop = rope.Head.Position.Y == rope.Tail.Position.Y + 2;
                var isRightRight = rope.Head.Position.X == rope.Tail.Position.X + 2;
                var isBotBot = rope.Head.Position.Y == rope.Tail.Position.Y - 2;
                var isLeftLeft = rope.Head.Position.X == rope.Tail.Position.X - 2;

                var isTop = rope.Head.Position.Y == rope.Tail.Position.Y + 1;
                var isRight = rope.Head.Position.X == rope.Tail.Position.X + 1;
                var isBot = rope.Head.Position.Y == rope.Tail.Position.Y - 1;
                var isLeft = rope.Head.Position.X == rope.Tail.Position.X - 1;

                if (IsHeadTopRight(isTopTop, isRight, isTop, isRightRight))
                {
                    MoveTailTopRight(rope);
                }
                    
                if (IsHeadBotRight(isBotBot, isRight, isBot, isRightRight))
                {
                    MoveTailBotRight(rope);
                }
                    
                if (IsHeadBotLeft(isBotBot, isLeft, isBot, isLeftLeft))
                {
                    MoveTailBotLeft(rope);
                }
                    
                if (IsHeadTopLeft(isTopTop, isLeft, isTop, isLeftLeft))
                {
                    MoveTailTopLeft(rope);
                }
            }
            // Add position to UniquePositionList if unique
            if (!rope.Tail.UniquePositionsVisited.Any(x => x.X == rope.Tail.Position.X && x.Y == rope.Tail.Position.Y))
            {
                var position = new Position()
                {
                    X = rope.Tail.Position.X,
                    Y = rope.Tail.Position.Y,
                };
                rope.Tail.UniquePositionsVisited.Add(position);
            }
        }
        
        return rope.Tail.UniquePositionsVisited.Count;
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

    private static void MoveTailTopRight(Rope rope)
    {
        rope.Tail.Position.X++;
        rope.Tail.Position.Y++;
    }

    private static void MoveTailBotRight(Rope rope)
    {
        rope.Tail.Position.X++;
        rope.Tail.Position.Y--;
    }

    private static void MoveTailBotLeft(Rope rope)
    {
        rope.Tail.Position.X--;
        rope.Tail.Position.Y--;
    }

    private static void MoveTailTopLeft(Rope rope)
    {
        rope.Tail.Position.X--;
        rope.Tail.Position.Y++;
    }

    private static bool IsTooFarAwayUp(Position headPosition, Position tailPosition) 
        => Math.Abs(headPosition.X - tailPosition.X) > 1;
    
    private static bool IsTooFarAwayInYAxis(Position headPosition, Position tailPosition) 
        => Math.Abs(headPosition.Y - tailPosition.Y) > 1;

    private static bool IsHeadTooFarAway(Position headPosition, Position tailPosition) 
        => IsTooFarAwayUp(headPosition, tailPosition) ||
           IsTooFarAwayInYAxis(headPosition, tailPosition);

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
    
    #region Part 2
    
    public static int Part2(string inputFileName)
    {
        return 2;
    }
    
    #endregion
}