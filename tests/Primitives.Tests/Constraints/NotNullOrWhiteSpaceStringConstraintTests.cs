using System.Linq;
using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using FsCheck.Fluent;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
{
    public class NotNullOrWhiteSpaceStringConstraintTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(NotNullOrWhiteSpaceStringConstraint).GetConstructors());

        [Fact]
        public void NonWhiteSpaceStringStringShouldNeverViolateConstraint()
        {
            // Fixture setup
            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where !string.IsNullOrWhiteSpace(s)
                select s;

            var constraint = new NotNullOrWhiteSpaceStringConstraint();

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void WhiteSpaceStringConstraintStringShouldAlwaysViolateConstraint()
        {
            // Fixture setup
            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where string.IsNullOrWhiteSpace(s)
                select s;

            var constraint = new NotNullOrWhiteSpaceStringConstraint();

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                var result = constraint.Check(s);
                result.Violated.Should().BeTrue();
                result.Message.Should().Be("String must not be null or white space.");
            }).QuickCheckThrowOnFailure();
        }
    }
}