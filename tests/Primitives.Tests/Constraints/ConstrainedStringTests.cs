using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using Bstm.Primitives.Constraints;
using Xunit;
using static System.Environment;

namespace Bstm.Primitives.Tests.Constraints
{
    public sealed class ConstrainedStringTests
    {
        [Theory]
        [AutoData]
        public void PublicSurfaceShouldNotAllowNullArgs(GuardClauseAssertion assertion) =>
            assertion.Verify(typeof(String2));

        [Fact]
        public void ToStringShouldReturnValue()
        {
            // Fixture setup
            var string2 = new String2("12");

            // Exercise system and verify outcome
            string2.ToString().Should().Be(string2.Value);
        }

        [Fact]
        public void ExceptionShouldBeThrownIfValueDoesNotMatchConstraints()
        {
            // Fixture setup
            // ReSharper disable once ObjectCreationAsStatement
            Action call = () =>  new String2("ABC");

            var message = "String length must be '2' but '3'.";
            message += $"{NewLine}String must contains only digit symbols.";
            message += $"{NewLine}Actual value was ABC.";

            // Exercise system and verify outcome
            call.Should().Throw<ArgumentOutOfRangeException>().WithMessage(message);
        }

        [Fact]
        public void ImplicitCastToStringShouldBeCorrect()
        {
            // Fixture setup

            // Exercise system
            string actual = new String2("12");

            // Verify outcome
            actual.Should().Be("12");
        }

        [Fact]
        public void ImplicitCastToStringShouldBeThrowException()
        {
            // Fixture setup
            string actual;

            // Exercise system
            // ReSharper disable once ExpressionIsAlwaysNull
            Action call = () => actual = default(String2)!;

            // Verify outcome
            call.Should().Throw<ArgumentNullException>();
        }

        private class String2 : ConstrainedString
        {
            public String2(string value)
                : base(value, new StringLengthConstraint(2), new DigitStringConstraint())
            {
            }
        }
    }
}