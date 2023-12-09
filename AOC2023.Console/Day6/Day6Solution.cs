using System.Text.RegularExpressions;
using AOC2023.Console.Helpers;

namespace AOC2023.Console.Day6;

public class Day6Solution : ISolution
{
    public int Day => 6;
    public string Solve(string[] input)
    {
        //return SolvePart1(input);
        return SolvePart2(input);
    }

    private string SolvePart1(string[] input)
    {
        int[] times = Regex.Matches(input[0], @"(\d+)")
            .Select(m => int.Parse(m.Groups[1].Value)).ToArray();
        
        int[] distances = Regex.Matches(input[1], @"(\d+)")
            .Select(m => int.Parse(m.Groups[1].Value)).ToArray();

        var results = new List<int>(); 
        
        for (var i = 0; i < times.Length; i++)
        {
            var time = times[i];
            var possibleDistances = new int[time + 1];
            
            for (var speed = 0; speed <= time; speed++) possibleDistances[speed] = speed * (time - speed);

            int winningCombos = 0;
            foreach (var dist in possibleDistances)
                if (dist > distances[i])
                    winningCombos++;
            results.Add(winningCombos);
        }
        
        return (results[0] * results[1] * results[2] * results[3]).ToString();
    }
    
    private string SolvePart2(string[] input)
    {
        long time = long.Parse(string.Join("", Regex.Matches(input[0], @"(\d+)")
            .Select(m => m.Groups[1].Value).ToArray()));
        
        
        long record = long.Parse(string.Join("", Regex.Matches(input[1], @"(\d+)")
            .Select(m => m.Groups[1].Value).ToArray()));
        
        var result = 0;

        for (long speed = 0; speed <= time; speed++)
        {
            if (speed * (time - speed) > record) result++;
        }
        
        return result.ToString();
    }
}