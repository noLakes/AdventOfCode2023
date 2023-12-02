using AOC2023.Console.Helpers;
using System.Text.RegularExpressions;

namespace AOC2023.Console.Day2;

public class Day2Solution : ISolution
{
    public int Day => 2;
    
    private int _redThreshold = 12;
    private int _greenThreshold = 13;
    private int _blueThreshold = 14;
    
    public string Solve(string[] input)
    {
        var games = new List<Game>();

        foreach (var line in input) games.Add(new Game(line));

        // ----- solution 1 start
        /*
        int sum = games
            .Where(g => g.RedMax <= _redThreshold && g.GreenMax <= _greenThreshold && g.BlueMax <= _blueThreshold)
            .Sum(g => g.ID);

        return sum.ToString();
        */
        // ----- solution 1 end

        // ----- solution 2 start
        
        var total = games.Sum(g => g.Power);
        return total.ToString();
        
        // ----- solution 2 end
    }
    
}

public class Game
{
    public readonly int ID;
    public int BlueMax;
    public int RedMax;
    public int GreenMax;
    public int Power => RedMax * BlueMax * GreenMax;
    
    public Game(string input)
    {
        ID = int.Parse(Regex.Match(input, @"\d+").Groups[0].Value); // works
        CalculateMaxValues(input);
    }

    private void CalculateMaxValues(string input)
    {
        // blue
        var blueStrings = Regex.Matches(input, @"(\d+)\s+(?=\bblue\b)")
            .Select(m => m.Groups[1].Value).ToArray();
        var blueValues = blueStrings.Select(int.Parse).ToArray().OrderByDescending(x => x).ToArray();
        BlueMax = blueValues[0];
        
        // red
        var redStrings = Regex.Matches(input, @"(\d+)\s+(?=\bred\b)")
            .Select(m => m.Groups[1].Value).ToArray();
        var redValues = redStrings.Select(int.Parse).ToArray().OrderByDescending(x => x).ToArray();
        RedMax = redValues[0];
        
        // green
        var greenStrings = Regex.Matches(input, @"(\d+)\s+(?=\bgreen\b)")
            .Select(m => m.Groups[1].Value).ToArray();
        var greenValues = greenStrings.Select(int.Parse).ToArray().OrderByDescending(x => x).ToArray();
        GreenMax = greenValues[0];
    }
}