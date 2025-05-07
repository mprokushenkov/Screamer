using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using Bstm.Primitives.Constraints;
using Xunit;

namespace Bstm.Primitives.Tests.Constraints
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