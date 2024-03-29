﻿using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
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

            var generator = from s in Arb.Generate<string>()
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

            var generator = from s in Arb.Generate<string>()
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