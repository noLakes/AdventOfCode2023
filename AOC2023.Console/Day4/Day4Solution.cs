using AOC2023.Console.Helpers;
using System.Text.RegularExpressions;

namespace AOC2023.Console.Day4;

public class Day4Solution : ISolution
{
    public int Day => 4;
    public string Solve(string[] input)
    {
        /*
        input = new string[]
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };
        */

        var totalScore = 0;

        foreach (var line in input)
        {
            var score = 0;
            var parsedInput = ParseScratchCard(line);
            var winningNums = 0;
            foreach (var num in parsedInput[..10])
            {
                if (parsedInput[10..].Contains(num)) winningNums++;
            }
            
            for (int i = 0; i < winningNums; i++) score = i == 0 ? 1 : score * 2;
            totalScore += score;
        }
        

        return totalScore.ToString();
    }

    private string[] ParseScratchCard(string input)
    {
        var nums = Regex.Matches(input, @"\s+(\d+)(?!:)")
            .Select(m => m.Groups[1].Value).ToArray();
        //var nums2 = nums.Select(int.Parse).ToArray();
        return nums;
    }
}