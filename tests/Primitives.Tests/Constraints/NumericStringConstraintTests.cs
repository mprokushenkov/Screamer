using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
{
    public class NumericStringConstraintTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(NumericStringConstraint));

        [Fact]
        public void NumericStringShouldNeverViolateConstraint()
        {
            // Fixture setup
            var generator = from n in Arb.Generate<uint>() select n.ToString();
            var constraint = new NumericStringConstraint();

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void NotNumericStringStringShouldAlwaysViolateConstraint()
        {
            // Fixture setup
            var generator = from s in Arb.Generate<string>() where s != null select s;
            var constraint = new NumericStringConstraint();

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                var result = constraint.Check(s);
                result.Violated.Should().BeTrue();
                result.Message.Should().Be("String must contains only digit symbols.");
            }).QuickCheckThrowOnFailure();
        }
    }
}