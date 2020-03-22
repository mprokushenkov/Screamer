﻿using System.Linq;
using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using FsCheck;
using Screamer.Primitives.Constraints;
using Xunit;

namespace Screamer.Primitives.Tests.Constraints
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
            var generator = from s in Arb.Generate<string>() where s != null && !s.Any(char.IsDigit) select s;
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
            var generator = from n in Arb.Generate<uint>() select n.ToString();
            var constraint = new RegexConstraint(pattern);

            // Exercise system and verify outcome
            Prop.ForAll(
                    generator.ToArbitrary(),
                    s => constraint.Check(s).Violated.Should().BeFalse())
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void Foo()
        {
            // Fixture setup
            var constraint = new RegexConstraint(pattern);

            // Exercise system and verify outcome
            constraint.Check("A");
            constraint.Check("B");
            constraint.Check("C");
        }
    }
}