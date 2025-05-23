using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using FsCheck.Fluent;
using Bstm.Primitives.Constraints;
using Xunit;

namespace Bstm.Primitives.Tests.Constraints
{
    public class RegexConstraintTests
    {
        private const string pattern = @"^\d+$";

        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(RegexConstraint));

        [Fact]
        public void NotNumericStringStringShouldAlwaysViolateConstraint()
        {
            // Fixture setup
            var generator = from s in ArbMap.Default.GeneratorFor<string>()
                where s != null && !s.Any(char.IsDigit)
                select s;

            var constraint = new RegexConstraint(pattern);

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                var result = constraint.Check(s);
                result.Violated.Should().BeTrue();
                result.Message.Should().Be($"String does not match pattern '{pattern}'.");
            }).QuickCheckThrowOnFailure();
        }

        [Fact]
        public void NumericStringShouldNeverViolateConstraint()
        {
            // Fixture setup
            var generator = from n in ArbMap.Default.GeneratorFor<uint>() select n.ToString();
            var constraint = new RegexConstraint(pattern);

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }
    }
}