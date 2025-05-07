using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using FsCheck.Fluent;
using Bstm.Primitives.Constraints;
using Xunit;

namespace Bstm.Primitives.Tests.Constraints
{
    public class MinStringLengthConstraintTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(MinStringLengthConstraint));

        [Fact]
        public void LongerStringShouldNeverViolateConstraint()
        {
            // Fixture setup
            const uint minLength = 10;

            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && s.Length >= minLength
                select s;

            var constraint = new MinStringLengthConstraint(minLength);

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void ShorterStringShouldAlwaysViolateConstraint()
        {
            // Fixture setup
            const uint minLength = 10;

            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && s.Length < minLength
                select s;

            var constraint = new MinStringLengthConstraint(minLength);

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                var result = constraint.Check(s);
                result.Violated.Should().BeTrue();
                result.Message.Should().Be($"String length must be greater or equal '{minLength}' but '{s.Length}'.");
            }).QuickCheckThrowOnFailure();
        }
    }
}