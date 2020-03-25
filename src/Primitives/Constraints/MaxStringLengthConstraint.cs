using static System.String;
using static Screamer.Primitives.Constraints.CheckResult;
using static Screamer.Primitives.Constraints.Messages;
using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public sealed class MaxStringLengthConstraint : IConstraint<string>
    {
        private readonly uint maxLength;

        public MaxStringLengthConstraint(uint maxLength) => this.maxLength = maxLength;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length <= maxLength
                ? Succeeded
                : CreateViolated(Format(MaxStringLengthConstraint_Violation, maxLength, value.Length));
        }
    }
}