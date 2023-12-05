using AOC2023.Console.Helpers;
using System.Text.RegularExpressions;

namespace AOC2023.Console.Day4;

public class Day4Solution : ISolution
{
    public int Day => 4;
    public string Solve(string[] input)
    {
        return SolvePart2(input);
    }

    private string SolvePart1(string[] input)
    {
        var totalScore = 0;

        foreach (var line in input)
        {
            var score = 0;
            var parsedInput = ParseScratchCard(line);
            var winningNums = parsedInput[10..].Count(num => parsedInput[..10].Contains(num));

            if (winningNums == 0)
            {
                continue;
            }
            for (int i = 0; i < winningNums; i++) score = i == 0 ? 1 : score * 2;
            totalScore += score;
        }

        return totalScore.ToString();
    }

    private string SolvePart2(string[] input)
    {
        var totalScore = 0;
        var duplicates = new int[input.Length];
        
        for (var i = 0; i < input.Length; i++)
        {
            var parsedInput = ParseScratchCard(input[i]);
            var winningNums = parsedInput[10..].Count(num => parsedInput[..10].Contains(num));

            for (var d = 0; d <= duplicates[i]; d++)
            {
                for (var j = 1; j <= winningNums; j++)
                {
                    if (i + j >= input.Length) break;
                    duplicates[i + j]++;
                }
            
                totalScore ++;
            }
        }
        
        return totalScore.ToString();
    }

    private string[] ParseScratchCard(string input)
    {
        var nums = Regex.Matches(input.Split(":")[1], @"\s+(\d+)(?!:)")
            .Select(m => m.Groups[1].Value).ToArray();
        return nums;
    }
}