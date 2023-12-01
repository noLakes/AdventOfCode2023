using AOC2023.Console.Day1;

namespace AOC2023.Test;

public class Day1ExampleTest
{
    [Fact]
    public void Test1()
    {
        //arrange
        var sut = new Day1Solution();
        var input = new string[] { "123", "456" };
        //act
        var result = sut.Solve(input);
        //assert
        result.Should().NotBeNull();
        result.Should().Be("Not yet solved");
    }
}