using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
{
    public class CheckResultTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(CheckResult));

        [Fact]
        public void ViolatedShouldByFalseByDefault()
        {
            // Fixture setup
            var result = new CheckResult();

            // Exercise system

            // Verify outcome
            result.Violated.Should().BeFalse();
        }
    }
}