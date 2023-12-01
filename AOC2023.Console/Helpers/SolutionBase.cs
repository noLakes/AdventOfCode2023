namespace AOC2023.Console.Helpers;

public interface ISolution
{
    public int Day { get; }
    public string Solve(string[] input);

}