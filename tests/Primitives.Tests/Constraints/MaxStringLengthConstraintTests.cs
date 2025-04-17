using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using FsCheck.Fluent;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
{
    public class MaxStringLengthConstraintTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(MaxStringLengthConstraint));

        [Fact]
        public void ShorterStringShouldNeverViolateConstraint()
        {
            // Fixture setup
            const uint maxLength = 20;

            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && s.Length <= maxLength
                select s;

            var constraint = new MaxStringLengthConstraint(maxLength);

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void LongerStringShouldAlwaysViolateConstraint()
        {
            // Fixture setup
            const uint maxLength = 20;

            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && s.Length > maxLength
                select s;

            var constraint = new MaxStringLengthConstraint(maxLength);

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                var result = constraint.Check(s);
                result.Violated.Should().BeTrue();
                result.Message.Should().Be($"String length must be smaller or equal '{maxLength}' but '{s.Length}'.");
            }).QuickCheckThrowOnFailure();
        }
    }
}