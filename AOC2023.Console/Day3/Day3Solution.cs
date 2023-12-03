using AOC2023.Console.Helpers;

namespace AOC2023.Console.Day3;

public class Day3Solution : ISolution
{
    public int Day => 3;

    private (int, int)[] _coords = {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)};

    public string Solve(string[] input)
    {
        return $"Part 1: {SolvePart1(input)}\nPart 2: {SolvePart2(input)}";
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

                if (col == input[row].Length - 1 && match && digits.Length > 0) total += int.Parse(digits);
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
    
    private bool CheckForSymbols(string[] input, (int Y, int X) pos)
    {
        foreach (var coord in _coords)
        {
            var newPos = (Y: pos.Y + coord.Item1, X: pos.X + coord.Item2);
            if (newPos.Y < 0 || newPos.Y >= input.Length || newPos.X < 0 || newPos.X >= input[0].Length) continue;
            var c = input[newPos.Y][newPos.X];
            if (!char.IsDigit(c) && c != '.') return true;
        }
        
        return false;
    }

    private List<int> CollectAdjacentGears(string[] input, (int Y, int X) pos)
    {
        var data = new List<(string num, int startX, int endX)>();
        
        var row = pos.Y - 1;
        for (var i = 0; i < 3; i++)
        {
            if (row >= input.Length || row < 0)
            {
                row++;
                continue;
            }

            string digits = "";
            for (int col = 0; col < input[row].Length; col++)
            {
                if (!char.IsDigit(input[row][col]))
                {
                    if (digits.Length > 0)
                    {
                        data.Add((digits, pos.X - (col - digits.Length), pos.X - (col - 1)));
                    }
                    digits = "";
                    continue; 
                }

                digits += input[row][col];
                if (col == input[row].Length - 1) data.Add((digits, pos.X - (col - digits.Length), pos.X - (col - 1)));
            }
            
            row++;
        }

        return data.Where(d => MathF.Abs(d.startX) == 0 || MathF.Abs(d.startX) == 1 || 
                               MathF.Abs(d.endX) == 0 || MathF.Abs(d.endX) == 1)
            .Select(d => int.Parse(d.num)).ToList();
    }
    
}