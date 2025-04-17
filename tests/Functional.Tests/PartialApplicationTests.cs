using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;

namespace Bstm.Functional.Tests;

public class PartialApplicationTests
{
    [Theory]
    [AutoData]
    public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion)
        => assertion.Verify(typeof(PartialApplication));

    [Fact]
    public void Apply1Test()
    {
        // Fixture setup
        var f = (int a) => a;
        var id = f.Apply(1);

        // Exercise system
        var result = id();

        // Verity outcome
        result.Should().Be(1);
    }

    [Fact]
    public void Apply2Test()
    {
        // Fixture setup
        var f = (int a, int b) => a + b;
        var addTo1 = f.Apply(1);

        // Exercise system
        var result = addTo1(2);

        // Verity outcome
        result.Should().Be(3);
    }

    [Fact]
    public void Apply3Test()
    {
        // Fixture setup
        var f = (int a, int b, int c) => a + b + c;
        var addTo3 = f.Apply(1).Apply(2);

        // Exercise system
        var result = addTo3(2);

        // Verity outcome
        result.Should().Be(5);
    }

    [Fact]
    public void Apply4Test()
    {
        // Fixture setup
        var f = (int a, int b, int c, int d) => a + b + c + d;
        var addTo5 = f.Apply(1).Apply(2).Apply(3);

        // Exercise system
        var result = addTo5(2);

        // Verity outcome
        result.Should().Be(8);
    }

    [Fact]
    public void Apply5Test()
    {
        // Fixture setup
        var f = (int a, int b, int c, int d, int e) => a + b + c + d + e;
        var addTo10 = f.Apply(1).Apply(2).Apply(3).Apply(4);

        // Exercise system
        var result = addTo10(2);

        // Verity outcome
        result.Should().Be(12);
    }

    [Fact]
    public void Apply6Test()
    {
        // Fixture setup
        var f = (int a, int b, int c, int d, int e, int f) => a + b + c + d + e + f;
        var addTo15 = f.Apply(1).Apply(2).Apply(3).Apply(4).Apply(5);

        // Exercise system
        var result = addTo15(2);

        // Verity outcome
        result.Should().Be(17);
    }

    [Fact]
    public void Apply7Test()
    {
        var f = (int a, int b, int c, int d, int e, int f, int g) => a + b + c + d + e + f + g;
        var addTo21 = f.Apply(1).Apply(2).Apply(3).Apply(4).Apply(5).Apply(6);

        // Exercise system
        var result = addTo21(2);

        // Verity outcome
        result.Should().Be(23);
    }

    [Fact]
    public void Apply8Test()
    {
        var f = (int a, int b, int c, int d, int e, int f, int g, int h) => a + b + c + d + e + f + g + h;
        var addTo28 = f.Apply(1).Apply(2).Apply(3).Apply(4).Apply(5).Apply(6).Apply(7);

        // Exercise system
        var result = addTo28(2);

        // Verity outcome
        result.Should().Be(30);
    }
}
