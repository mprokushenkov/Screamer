using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;

namespace Bstm.Functional.Tests;

public class CombinationTests
{
    [Theory]
    [AutoData]
    public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion)
        => assertion.Verify(typeof(Combination));


    [Fact]
    public void Combine1Test()
    {
        // Fixture setup
        var fNum = (int a) => a;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fNum.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(42);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine2Test()
    {
        // Fixture setup
        var fAdd = (int a, int b) => a + b;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(2, 40);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine3Test()
    {
        // Fixture setup
        var fAdd = (int a, int b, int c) => a + b + c;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(2, 35, 5);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine4Test()
    {
        // Fixture setup
        var fAdd = (int a, int b, int c, int d) => a + b + c + d;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(2, 35, 3, 2);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine5Test()
    {
        // Fixture setup
        var fAdd = (int a, int b, int c, int d, int e) => a + b + c + d + e;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(2, 30, 3, 2, 5);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine6Test()
    {
        // Fixture setup
        var fAdd = (int a, int b, int c, int d, int e, int f) => a + b + c + d + e + f;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(2, 20, 3, 2, 5, 10);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine7Test()
    {
        // Fixture setup
        var fAdd = (int a, int b, int c, int d, int e, int f, int g) => a + b + c + d + e + f + g;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(2, 18, 3, 2, 5, 10, 2);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }

    [Fact]
    public void Combine8Test()
    {
        // Fixture setup
        var fAdd = (int a, int b, int c, int d, int e, int f, int g, int h) => a + b + c + d + e + f + g + h;
        var fConvert = (int a) => $"'{a}'";
        var fFormat = (string answer) => $"The Ultimate Question of Life is {answer}.";
        var getAnswer = fAdd.Combine(fConvert).Combine(fFormat);

        // Exercise system
        var result = getAnswer(1, 18, 3, 2, 5, 10, 2, 1);

        // Verity outcome
        result.Should().Be("The Ultimate Question of Life is '42'.");
    }
}
