using System;
using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
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
            var string2 = new String2("AB");

            // Exercise system and verify outcome
            string2.ToString().Should().Be(string2.Value);
        }

        [Fact]
        public void ExceptionShouldBeThrownIfValueDoesNotMatchRequiredLength()
        {
            // Fixture setup
            var generator = from s in Arb.Generate<string>()
                where s != null && s.Length != 2
                select s;

            // Exercise system and verify outcome
            Prop.ForAll(generator.ToArbitrary(), s =>
            {
                // ReSharper disable once ObjectCreationAsStatement
                Action call = () => new String2(s);
                call.Should().Throw<ArgumentOutOfRangeException>();
            }).QuickCheckThrowOnFailure();
        }

        [Fact]
        public void ImplicitCastToStringShouldBeCorrect()
        {
            // Fixture setup

            // Exercise system
            string actual = new String2("AB");

            // Verify outcome
            actual.Should().Be("AB");
        }

        [Fact]
        public void ImplicitCastToStringShouldBeSuccessIfSourceIsNull()
        {
            // Fixture setup

            // Exercise system
            // ReSharper disable once ExpressionIsAlwaysNull
            string actual = default(String2)!;

            // Verify outcome
            actual.Should().BeNull();
        }

        private class String2 : ConstrainedString
        {
            public String2(string value)
                : base(value, new MinStringLengthConstraint(2), new MaxStringLengthConstraint(2))
            {
            }
        }
    }
}