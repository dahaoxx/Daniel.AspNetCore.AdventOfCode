using Two.RockPaperScissors.Extensions;
using Two.RockPaperScissors.Models;
using Two.RockPaperScissors.Utils;

namespace Two.RockPaperScissors.Services;

public static class RockPaperScissorsService
{
    #region Part 1

    public static int CalculateScorePart1(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);

        return lines.Sum(line => 
            CalculateRoundScorePart1(
                HandUtils.GetElfHand(LineParser.GetFirstChar(line)), 
                HandUtils.GetOwnHand(LineParser.GetLastChar(line))));
    }
    
    private static int CalculateRoundScorePart1(Hand elfHand, Hand ownHand)
    {
        var outcome = OutcomeUtils.CalculateRoundOutcome(elfHand, ownHand);
        var outcomeScore = outcome.ToScore();
        var handScore = ownHand.ToScore();
        
        return outcomeScore + handScore;
    }

    #endregion
    
    #region Part 2
    
    public static int CalculateScorePart2(string inputFileName)
    {
        var lines = File.ReadAllLines(inputFileName);

        return lines.Sum(line => 
            CalculateRoundScorePart2(
                HandUtils.GetElfHand(LineParser.GetFirstChar(line)), 
                OutcomeUtils.GetIndicatedOutcome(LineParser.GetLastChar(line))));
    }
    
    private static int CalculateRoundScorePart2(Hand elfHand, Outcome indicatedOutcome)
    {
        var handToPlay = HandUtils.CalculateHandToPlay(elfHand, indicatedOutcome);
        var handScore = handToPlay.ToScore();
        var outcomeScore = indicatedOutcome.ToScore();
        
        return outcomeScore + handScore;
    }

    #endregion
}