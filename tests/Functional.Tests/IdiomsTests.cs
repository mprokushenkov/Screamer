using AutoFixture.Xunit2;
using FluentAssertions;
using static Bstm.Functional.Idioms;

namespace Bstm.Functional.Tests
{
    public class IdiomsTests
    {
        [Theory]
        [AutoData]
        public void IdShouldReturnSubject(string[] ar) =>
            // Fixture setup
            // Exercise system
            // Verity outcome
            ar.OrderBy(Id).Should().BeEquivalentTo(ar);
    }
}
