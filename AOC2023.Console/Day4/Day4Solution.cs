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
            "Card 147: 1 2 3 4 5 6 7 8 9 10 | 9 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45"
        };
        */

        var totalScore = 0;

        foreach (var line in input)
        {
            var score = 0;
            var parsedInput = ParseScratchCard(line);
            var winningNums = 0;
            System.Console.WriteLine($"{string.Join(" ", parsedInput[..10])}\n{string.Join(" ", parsedInput[10..])}");
            foreach (var num in parsedInput[10..])
            {
                if (parsedInput[..10].Contains(num)) winningNums++;
            }

            if (winningNums == 0)
            {
                continue;
            }
            for (int i = 0; i < winningNums; i++) score = i == 0 ? 1 : score * 2;
            totalScore += score;
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