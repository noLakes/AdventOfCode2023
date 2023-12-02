using System.Diagnostics;
using AOC2023.Console.Helpers;
using System.Text.RegularExpressions;

namespace AOC2023.Console.Day1;

public class Day1Solution : ISolution
{
    public int Day => 1;
    private readonly List<string> _alphaNums = new(){ "one", "two", "three", "four",
        "five", "six", "seven", "eight", "nine" };

    public string Solve(string[] input)
    {
        int total = input.Sum(line => int.Parse(ReduceToFirstAndLast(ReduceStringToNumbers(line))));

        return total.ToString();
    }

    private string ReduceStringToNumbers(string input)
    {
        var result = "";
        
        foreach (var c in input.ToCharArray())
        {
            if (int.TryParse(c.ToString(), out var i)) result += c;
        }

        return result;
    }
    
    private string ReduceToFirstAndLast(string input)
    {
        if (input.Length == 1) return input + input;
        
        var chars = input.ToCharArray();
        
        return $"{chars[0]}{chars[^1]}";
    }

    //-------------------------------------
    // unused methods for part two (in progress)
    //-------------------------------------
    
    private string AlphaNumericalToNumerical(string input)
    {
        if (_alphaNums.Contains(input)) return (_alphaNums.IndexOf(input) + 1).ToString();
        return input;
    }
    
    private string ReplaceAlphaNumerical(string input)
    {
        var result = input;

        foreach (var num in _alphaNums)
        {
            result = result.Replace(num, AlphaNumericalToNumerical(num));
        }
        
        return result;
    }
}