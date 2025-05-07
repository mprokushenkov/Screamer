using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using FsCheck.Fluent;
using Bstm.Primitives.Constraints;
using Xunit;

namespace Bstm.Primitives.Tests.Constraints
{
    public class StringLengthConstraintTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(StringLengthConstraint));

        [Fact]
        public void StringWithCorrectLengthShouldNeverViolateConstraint()
        {
            // Fixture setup
            const uint length = 10;

            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && s.Length == length
                select s;

            var constraint = new StringLengthConstraint(length);

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void StringWithIncorrectLengthShouldAlwaysViolateConstraint()
        {
            // Fixture setup
            const uint length = 10;

            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && s.Length != length
                select s;

            var constraint = new StringLengthConstraint(length);

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                var result = constraint.Check(s);
                result.Violated.Should().BeTrue();
                result.Message.Should().Be($"String length must be '{length}' but '{s.Length}'.");
            }).QuickCheckThrowOnFailure();
        }
    }
}