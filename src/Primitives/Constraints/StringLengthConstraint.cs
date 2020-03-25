using static System.String;
using static Screamer.Primitives.Constraints.CheckResult;
using static Screamer.Primitives.Constraints.Messages;
using static Screamer.Primitives.Guard;

namespace Screamer.Primitives.Constraints
{
    public sealed class StringLengthConstraint : IConstraint<string>
    {
        private readonly uint length;

        public StringLengthConstraint(uint length) => this.length = length;

        public CheckResult Check(string value)
        {
            CheckNull(value, nameof(value));

            return value.Length == length
                ? Succeeded
                : CreateViolated(Format(StringLengthConstraint_Violation, length, value.Length));
        }
    }
}