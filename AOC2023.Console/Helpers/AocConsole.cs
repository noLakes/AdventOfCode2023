using System.Reflection;

namespace AOC2023.Console.Helpers;

public static class AocConsole
{
    public static void Start()
    {
        var baseType = typeof(ISolution);
        var allSolutions = Assembly.GetAssembly(baseType)!.GetTypes()
            .Where(myType => myType.IsClass && myType.GetInterfaces().Contains(baseType));

        var instances = allSolutions
            .Select(t => (ISolution)Activator.CreateInstance(t)!)
            .ToDictionary(s => s.Day);

        ISolution? solution = null;
        while (solution is null)
        {
            System.Console.WriteLine("Please enter a day:");
            var chosenDay = System.Console.ReadLine();
            if (int.TryParse(chosenDay, out var result) && instances.ContainsKey(result))
            {
                solution = instances[result];
                continue;
            }
            System.Console.WriteLine($"Day {chosenDay} not found...");
            System.Console.WriteLine();
        }

        var input = GetInput(solution);
        var solutionResult = solution.Solve(input);
        System.Console.WriteLine($"The solution to day{solution.Day} is:");
        System.Console.WriteLine(solutionResult);
        System.Console.WriteLine();
        System.Console.WriteLine("Enter any key to quit");
        System.Console.Read();
    }

    public static string[] GetInput(ISolution solution)
    {
        var path = Path.Combine($"Day{solution.Day}", "input.txt");
        var input = File.ReadAllLines(path);
        return input;
    }
}