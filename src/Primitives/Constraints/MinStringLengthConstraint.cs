using static System.String;
using static Screamer.Primitives.Constraints.CheckResult;
using static Screamer.Primitives.Guard;
using static Screamer.Primitives.Constraints.Messages;

namespace Screamer.Primitives.Constraints
{
    public sealed class MinStringLengthConstraint : IConstraint<string>
    {
        private readonly uint minLength;

        public MinStringLengthConstraint(uint minLength) => this.minLength = minLength;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length >= minLength
                ? Succeeded
                : CreateViolated(Format(MinStringLengthConstraint_Violation, minLength, value.Length));
        }
    }
}