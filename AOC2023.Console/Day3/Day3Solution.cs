using AOC2023.Console.Helpers;

namespace AOC2023.Console.Day3;

public class Day3Solution : ISolution
{
    public int Day => 3;

    private (int, int)[] _coords = {(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)};

    public string Solve(string[] input)
    {
        /*
        input = new string[]
        {
            "467..114.......",
            "...*...........",
            "..35..633......",
            "......#........",
            "617*...........",
            ".....+.58......",
            "..592..........",
            "......755...*33",
            "...$.*.........",
            ".664.598......."
        };
        */

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
                if (!match) match = CheckForSymbols(input, row, col); // check for match

                if (col == input[row].Length - 1 && match && digits.Length > 0)
                {
                    total += int.Parse(digits);
                }
            }
        }
        
        return total.ToString();
    }
    
    private bool CheckForSymbols(string[] input, int y, int x)
    {
        foreach (var coord in _coords)
        {
            var posY = y + coord.Item1;
            var posX = x + coord.Item2;

            if (posY < 0 || posY >= input.Length || posX < 0 || posX >= input[0].Length) continue;

            char c = input[posY][posX];
            if (!char.IsDigit(c) && c != '.') return true;
        }
        
        return false;
    }
    
}