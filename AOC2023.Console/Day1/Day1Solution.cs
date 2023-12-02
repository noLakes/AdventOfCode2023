using System.Diagnostics;
using AOC2023.Console.Helpers;
using System.Text.RegularExpressions;

namespace AOC2023.Console.Day1;

public class Day1Solution : ISolution
{
    public int Day => 1;
    
    private readonly Dictionary<string, string> _alphaNums = new()
    {
        { "one", "1" }, { "two","2" }, { "three","3" }, { "four","4" },
        { "five","5" }, { "six","6" }, { "seven","7" }, { "eight","8" }, { "nine","9" } 
    };

    public string Solve(string[] input)
    {
        int result = 0;

        foreach (var line in input)
        {
            var parsedLine = ParseForDigitsInOrder(line);
            var reducedResult = ReduceToFirstAndLast(String.Join("", parsedLine));
            result += int.Parse(reducedResult);
        }
        
        return result.ToString();
    }

    private string ReduceToFirstAndLast(string input)
    {
        if (input.Length == 0) return "";
        if (input.Length == 1) return input + input;
        
        var chars = input.ToCharArray();
        
        return $"{chars[0]}{chars[^1]}";
    }
    
    private List<string> ParseForDigitsInOrder(string input)
    {
        var results = new List<string>();
        
        for (var i = 0; i < input.Length; i++)
        {
            // if we encounter a lone digit, add it to the result list
            if(Char.IsDigit(input[i])) results.Add(input.Substring(i, 1));
            
            // read from i to end of string in increments looking for matches
            for (var j = i + 1; j < input.Length; j++)
            {
                var subStr = input.Substring(i, (j - i) + 1);
                if (!_alphaNums.TryGetValue(subStr, out var s)) continue;
                
                // if match is found, add to results
                results.Add(s);
                
                // neutralize all letters of match except last to allow for conjoined digits and no duplicates
                input.Replace(input.Substring(i, j - i),
                    new string('-', j - i));
            }
        }

        return results;
    }
}