using AOC2023.Console.Helpers;

namespace AOC2023.Console.Day3;

public class Day3Solution : ISolution
{
    public int Day => 3;

    private (int, int)[] _coords = {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)};

    public string Solve(string[] input)
    {
        input = new string[]
        {
            "467..114.......",
            "...*...........",
            "..35..633......",
            "......#........",
            "617*...........",
            ".....+.58......",
            "..592..........",
            "......755......",
            "...$.*.........",
            ".664.598......."
        };
        
        //return SolvePart1(input);
        return SolvePart2(input);
    }
    
    private string SolvePart1(string[] input)
    {
        var total = 0;
        
        for (var row = 0; row < input.Length; row++)
        {
            bool match = false;
            var digits = "";
            
            for (var col = 0; col < input[row].Length; col++)
            {
                if (!char.IsDigit(input[row][col]))
                {
                    if (match && digits.Length > 0)
                    {
                        total += int.Parse(digits);
                    }
                    match = false;
                    digits = "";
                    continue;
                }

                digits += input[row][col];
                if (!match) match = CheckForSymbols(input, (row, col)); // check for match

                if (col == input[row].Length - 1 && match && digits.Length > 0)
                {
                    total += int.Parse(digits);
                }
            }
        }
        
        return total.ToString();
    }
    
    private string SolvePart2(string[] input)
    {
        int result = 0;
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if(input[row][col] != '*') continue;
                var gears = CollectAdjacentGears(input, (row, col));
                if (gears.Count == 2) result += gears[0] * gears[1];
            }
        }
        
        return result.ToString();
    }
    
    private bool CheckForSymbols(string[] input, (int, int) pos)
    {
        foreach (var coord in _coords)
        {
            var newPos = (Y: pos.Item1 + coord.Item1, X: pos.Item2 + coord.Item2);
            if (newPos.Y < 0 || newPos.Y >= input.Length || newPos.X < 0 || newPos.X >= input[0].Length) continue;
            var c = input[newPos.Y][newPos.X];
            if (!char.IsDigit(c) && c != '.') return true;
        }
        
        return false;
    }

    private List<int> CollectAdjacentGears(string[] input, (int, int) pos)
    {
        var gears = new List<int>();

        // solution to isolating adjacent numbers and adding to gear list
        
        return gears;
    }
    
}