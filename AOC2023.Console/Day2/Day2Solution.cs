using AOC2023.Console.Helpers;
using System.Text.RegularExpressions;

namespace AOC2023.Console.Day2;

public class Day2Solution : ISolution
{
    public int Day => 2;

    // test sample for part 2
    private string[] _test = new[]
    {
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
    };

    private int _redThreshold = 12;
    private int _greenThreshold = 13;
    private int _blueThreshold = 14;
    
    public string Solve(string[] input)
    {
        var games = new List<Game>();

        foreach (var line in input) games.Add(new Game(line));

        // ----- solution 1 start
        int sum = games
            .Where(g => g.RedMax <= _redThreshold && g.GreenMax <= _greenThreshold && g.BlueMax <= _blueThreshold)
            .Sum(g => g.GameValue);

        return sum.ToString();
        // ----- solution 1 end
    }
    
}

public class Game
{
    public readonly int GameValue;
    public int BlueMax;
    public int RedMax;
    public int GreenMax;
    
    public Game(string input)
    {
        GameValue = int.Parse(Regex.Match(input, @"\d+").Groups[0].Value); // works
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